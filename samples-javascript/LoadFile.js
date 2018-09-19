function LoadFile() {
	if (!window.FileReader) {
		document.getElementById(fileOutputId).value = loadErrorMessage;
	} else {
		var selectedFile = document.getElementById(fileInputId).files[0];
		var reader = new FileReader();
		reader.onload = function (fle) {
			var content = fle.target.result;
			document.getElementById(fileOutputId).value = content;
		}
		reader.readAsText(selectedFile);
		document.getElementById(loadFileNameId).value = selectedFile.name;
		document.getElementById(saveFileNameId).value = selectedFile.name;
	}
}