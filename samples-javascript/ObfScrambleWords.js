Array.prototype.sortrandom = function () {
	var text = this;

	function rsort() {
		return (Math.round(Math.random()) - 0.5);
	}

	text = text.sort(rsort);
	return text;
}

function scrambleWord(word) {
	var firstIsCapital = false;
	if (word.slice(0, 1).search(/[A-Z]/g) != -1) firstIsCapital = true;
	word = word.toLowerCase().split('').sortrandom().join('');
	if (firstIsCapital) word = word.slice(0, 1).toUpperCase() + word.slice(1);
	return word;
}

var ScrambleWords = function () {
	var text = document.getElementById(fileOutputId).value;
	text = text.replace(/\r/gi, '');
	text = text.replace(/([^a-z ])/gi, ' $1 ');
	text = text.split(' ');

	var arr = new Array();
	for (var x = 0; x < text.length; x++) {
		arr[x] = scrambleWord(text[x]);
	}

	text = arr.join(' ');
	text = text.replace(/ ([^a-z ]) /gi, '$1');
	document.getElementById(fileOutputId).value = text;
}