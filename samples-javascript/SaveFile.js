function SaveFile() {
	if (!window.Blob) {
		alert(saveErrorMessage);
	} else {
		var text = document.getElementById(fileInputId).value;
					
		//replace new line characters if user is running Windows.
		if (isWindows() == true) text = text.replace(/\n/g, '\r\n');
					
		var textblob = new Blob([text], {type: 'text/plain'});
		var saveAs = document.getElementById(saveFileNameId).value;
					
		var link = document.createElement('a');
		link.download = saveAs;
		link.innerHTML = "Download File";
					
		if (window.webkitURL != null) {
			link.href = window.webkitURL.createObjectURL(textblob);
		} else {
			link.href = window.URL.createObjectURL(textblob);
			link.onclick = removeMe;
			link.style.display = 'none';
			document.body.appendChild(link);
		}
		link.click();
	}
}

function isWindows() {
	return navigator.platform.indexOf('Win') > -1
}

function removeMe(event) {
	document.body.removeChild(event.target);
}
		