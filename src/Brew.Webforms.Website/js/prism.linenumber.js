// Line wrapping plugin for Prism (to allow line numbering with CSS)
// Documentation: http://bililite.com/blog/2012/08/05/line-numbering-plugin-for-prism/
// Version: 1.0
// Copyright (c) 2012 Daniel Wachsstock
// MIT license:
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:

// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

Prism.hooks.add('after-highlight', function(env){
	var el = env.element;
	if (!(el.hasAttribute('data-linenumber'))) return;
	var startNumber = parseInt(el.getAttribute('data-linenumber'))||1;
	el.style.counterReset = getComputedStyle(el).counterReset.replace(/\d+/, startNumber-1);
	var text = el.textContent.split('\n');
	var range = document.createRange();
	var pointer = 0; // start of text
	el.textContent.split('\n').forEach(function(line, i){
		var len = line.length;
		setBounds (pointer, pointer+len);
		var wrapper = document.createElement('span');
		wrapper.setAttribute('class', 'line');
		wrapper.appendChild(range.extractContents());
		range.insertNode(wrapper);
		pointer += len+1; // skip the newline
	});
	// now, we're left with a bunch of empty spans/other elements that were split across lines and the browser divided them into three parts
	// those mess up the odd/even calculations. Replace them with plain text.
	for (var node = el.firstChild; node; node = node.nextSibling){
		if (node.nodeType != 3 && node.getAttribute('class') != 'line'){
			var replacement = document.createTextNode(node.textContent);
			el.replaceChild(replacement, node);
			node = replacement;
		}
	}
	
	function setBounds (start, end){
		// since the browser throws an error if we try to move the beginning past the end (unlike IE, which just adusts the end)
		// we have to reset the range to cover the entire element, then move the start, then move the end to the start, then move the end
		range.selectNodeContents(el);
		moveBoundary (start, 'start');
		range.collapse (true);
		moveBoundary (end-start, 'end');
	}
	function moveBoundary (n, start){
		// move the boundary n characters forward, up to the end of the element. Forward only!
		//  start is 'start' or 'end', and is used to create the appropriate method names ('startContainer' or 'endContainer' etc.)
		// if the start is moved after the end, then an exception is raised
		if (n <= 0) return;
		var startNode = range[start+'Container'];
		// we may be starting somewhere into the text
		if (startNode.nodeType == 3) n += range[start+'Offset'];
		// nodeIterators from http://www.w3.org/TR/DOM-Level-2-Traversal-Range/traversal.html
		var iter = document.createNodeIterator(el, 4 /* SHOW_TEXT */), node;
		while (node = iter.nextNode()){
			if (startNode.compareDocumentPosition(node) & 2 /* DOCUMENT_POSITION_PRECEDING */ ) continue;
			if (n <= node.nodeValue.length){
				// we found the last character!
				range[start == 'start' ? 'setStart' :'setEnd'](node, n);
				return;
			}else{
				n -= node.nodeValue.length; // eat these characters
			}
		}
	}
});

