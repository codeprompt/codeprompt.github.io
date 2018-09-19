var EncodeRot13 = function() {
	
	//get input
	var textIn = document.getElementById(fileOutputId).value;
	textIn = textIn.replace(/\r/gi, '');
	textIn = textIn.split('\n');
	
	//set vars
	var keyarr = key.split('');
	var letters = '';
	var lettersout = new Array();
	var textout = new Array();
				
	for (i = 0; i < textIn.length; i++) {
		letters = textIn[i].split('');
		for (j = 0; j < letters.length; j++) {
			if (!letters[j].toLowerCase().match(/[a-z]/)) {
				lettersout[j] = letters[j];
			} else {
				if (letters[j].match(/[a-z]/)) {
					lettersout[j] = keyarr[letters[j].charCodeAt(0) - 97]; 
				} else {
					lettersout[j] = keyarr[letters[j].charCodeAt(0) - 65].toUpperCase();
				}
			}
		}
					
		textout[i] = lettersout.join('');
		lettersout = new Array();
	}
					
	//output
	textout = textout.join('\n');
	document.getElementById(fileOutputId).value = textout;
}