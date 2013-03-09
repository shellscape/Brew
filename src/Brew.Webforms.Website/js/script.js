$(function(){

	$('a.donate').click(function (e) {
		$(this).prev('form').submit();
		e.preventDefault();
	});

	$('h2.control').append($('<span/>').html('control'));
	$('h2.interaction').append($('<span/>').html('interaction'));
	$('h2.utility').append($('<span/>').html('utility'));
});