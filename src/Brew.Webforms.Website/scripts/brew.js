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
	};

	function attrfix(data, widgetName) { // $.data() returns all attributes lowercase. doesn't jive with jquery ui.

		var options;

		if (widgetName == "datepicker") {
			options = $.datepicker._defaults
		}
		else {
			options = $.ui[widgetName].prototype.options;
		}

		$.each(options, function (label) {
			var lower = label.toLowerCase();
			if (!data.hasOwnProperty(label) && data.hasOwnProperty(lower)) {
				data[label] = data[lower];
				delete data[lower];
			}
		});

		return data;
	};

	function ready() {

		$('brew widget').each(function () {
			var widget = $(this),
				_for = widget.attr('for'),
				name = widget.attr('name'),
				options = widget.data(),
				postbacks = widget.data('postbacks'),
				uniqueId = widget.data('uniqueid');

			options = attrfix(options, name);

			$.each(postbacks, function (event) {
				var postback = this;

				options[event] = function (event, ui) {
					window.__doPostBack(uniqueId, postback);
				};
			});

			if (name == 'dialog'){
				if (options.trigger) {
					$(options.trigger).click(function (e) {
						$('#' + _for).dialog('open');
						e.preventDefault();
					});
				}

				if (options.buttons) {
					$.each(options.buttons, function (label) {
						options.buttons[label] = eval(this);
					});
				}
			}

			$('#' + _for)[name](options);
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
				var widget = $(this);
				var _for = widget.attr('for');
				var name = widget.attr('name');
				var element = $('#' + _for);
				var ui = element.data("ui-" + name);
				var data = $.extend({}, ui.options);

				if (!ui) {
					return;
				}

				$.each(data, function (label) {
					if (typeof(this) == "string") {
						data[label] = htmlEncode(this);
					}
				});

				options.push({ id: _for, widgetName: name, options: data });
			});

			input.val(JSON.stringify(options));
		},

		closedialog: function () {
			$(this).dialog("close");
		}
	};
	
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