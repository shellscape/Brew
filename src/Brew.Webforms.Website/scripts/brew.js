(function ($) {
	'use strict';

	var _old = $.fn.attr,
		stateId = '__brewstate';

	$.fn.attr = function () {

		if (this[0] && arguments.length === 0) {
			var map = {}, i,
				attributes = this[0].attributes,
				length = attributes.length;

			for (i = 0; i < length; i++) {
				map[attributes[i].name.toLowerCase()] = attributes[i].value;
			}
			return map;
		}
		else {
			return _old.apply(this, arguments);
		}
	}

	function ready() {

		$('brew widget').each(function () {
			var widget = $(this),
				_for = widget.attr('for'),
				name = widget.attr('name'),
				data = widget.data();

			$('#' + _for)[name](data);
		});

		if (!$('#' + stateId).length) {
			$('<input />', { type: 'hidden', id: stateId, name: stateId }).appendTo(window.theForm); // theForm is defined by asp.net
		}
	};

	$(ready);
	Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () { ready(); }); // handles adding the jquery ui css on partial postback, if it hasn't been already.

	window.__brew = {
		onsubmit: function () {
			var input = $('#' + stateId),
				options = [];

			$('brew widget').each(function () {
				var widget = $(this),
					_for = widget.attr('for'),
					name = widget.attr('name'),
					element = $('#' + _for),
					ui = element.data(name),
					data = $.extend({}, uiWidget.options);

				if (!ui) {
					return;
				}

				$.each(data, function (label) {
					if (typeof(this).toLowerCase() == "string") {
						data[label] = htmlEncode(this);
					}
				});

				options.push({ id: widget.id, widgetName: widgetName, options: data });
			});

			input.val(JSON.stringify(options));
		}
	};

	//  ready = function () {
	//    if ( typeof ( window.JSON ) === 'undefined' ) {
	//      throw new Error( '__brew requires JSON support. Please ensure json2.js is referenced for downlevel browsers.' );
	//    }

	//    if (!$('#' + stateId).length) {
	//    	$('<input id="' + stateId + '" name="' + stateId + '" type="hidden" />')
	//			  .appendTo( window.theForm ); // theForm is defined by asp.net
	//    }

	//    $.each( __brew.widgets, function ( index, widget ) {
	//      var element = $( '#' + widget.id ),
	//        widgetName = widget.widgetName,
	//        events = {};

	//			if( !widgetName || !$.fn[widgetName] ) {
	//				return;
	//			}

	//			// map the event names to objects, merge with postBacks
	//			widget.events = $.map( widget.events, function( name ){
	//				return { name: name };
	//			});

	//			widget.postBacks = $.map( widget.postBacks, function( pb ){
	//				pb.causesPostBack = true;
	//				return pb;
	//			});

	//			widget.events = widget.events.concat( widget.postBacks );

	//      $.each( widget.events, function () {
	//        var event = this;
	//        events[event.name] = function ( jqEvent, ui ) {

	//        	// Submit a postback if handler emitted - wee server side events!
	//        	if ( event.causesPostBack ) {
	//        		window.__doPostBack(widget.uniqueId, event.dataChangedEvent ? '' : event.name);
	//        	}
	//        };
	//      });

	//			$.each( widget.options, function( prop ) {
	//				if( this.eval ){
	//					var on = this.on;

	//					try {
	//						widget.options[ prop ] = eval( '(' + this.on + ')' );
	//					}
	//					catch ( e ) { // if bad data/string is entered for the Eval property, an exception is thrown. Remove the bad data and prop.
	//						delete widget.options[ prop ];

	//						window.console && console.log && console.log( 'Brew Error > elementId: ' + widget.id + '. widget: "' + widgetName + '". Bad data in "' + prop + '" option.' );
	//					}
	//				}
	//			});

	//      // merge events with options
	//      $.extend( widget.options, events );

	//      // Invoke the jQuery UI extension method on the element with the options only if it hasn't already been called
	//      if ( !element.data( widgetName ) ) {
	//        element[widgetName]( widget.options );
	//      }

	//      // Wire up dispose method which update panels will call when element is destroyed
	//      element[0].dispose = function () {
	//        delete __brew.widgets[widget.id];
	//      };
	//    });
	//  },

	var htmlEncode = function (value) {
		return $('<div/>').text(value).html();
	};

	// The datepicker widget is "unique" in jQuery UI. It's internals aren't standardized like the other widgets.
	// Hence, it does not store an options hash natively. This extension provides that hash.
	// Credit - Scott Gonzales
	var _attachDatepicker = $.datepicker._attachDatepicker,
		_optionDatepicker = $.datepicker._optionDatepicker;

	$.datepicker._attachDatepicker = function (target) {
		var inst;
		_attachDatepicker.apply(this, arguments);
		inst = this._getInst(target);
		inst.options = {};
		this._refreshOptions(target);
	};

	$.datepicker._refreshOptions = function (target) {
		var inst = this._getInst(target);
		$.each(this._defaults, function (prop) {
			inst.options[prop] = $.datepicker._get(inst, prop);
		});
	};

	$.datepicker._optionDatepicker = function (target) {
		_optionDatepicker.apply(this, arguments);
		this._refreshOptions(target);
	};

	// The tabs widget triggers 'show' on create. Scott has stated that this behavior is unusual and won't be a part of 1.9.
	// Implementing a temporary workaround so that the tabs don't trigger a postback (if bound in codebehind) on page load.
	$.ui.tabs.prototype._created = false;

	var _tabify = $.ui.tabs.prototype._tabify,
		_trigger = $.ui.tabs.prototype._trigger;

	$.ui.tabs.prototype._tabify = function () {
		_tabify.apply(this, arguments);
		this._created = true;
	};

	$.ui.tabs.prototype._trigger = function (type) {
		if (type === "show" && !this._created) {
			return false;
		}
		return _trigger.apply(this, arguments);
	};

	// We need to proxy the ui.dialog._create method to assert that dialogs are appended to the end of the server form. 
	// Otherwise, any server controls within them will not retain their value during postback.

	var _create = $.ui.dialog.prototype._create;

	$.ui.dialog.prototype._create = function () {
		var result = _create.apply(this, arguments);
		var form = window.theForm || $('form:first');

		this.uiDialog.appendTo(form);

		return result;
	};

	// The autocomplete widget accepts a string and string array. This is problematic as we can't represent both 


})(jQuery);