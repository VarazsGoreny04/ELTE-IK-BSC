function changeSize() {
	var content = document.getElementById("content");
	var p = document.querySelector("#content > p");

	if (content.style.fontSize == "") {
		content.style.fontSize = "x-large";
		p.style.fontSize = "x-large";
	} else {
		content.style.fontSize = "";
		p.style.fontSize = "";
	}
}
