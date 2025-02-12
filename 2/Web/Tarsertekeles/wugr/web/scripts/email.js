function sendEmail() {
	var subject = 
        ((document.getElementById("Urgent").checked) ? "[URGENT] " : "") + 
        ((document.getElementById("Business").checked) ? "[B] " : "[P] ") +
        document.getElementById("Subject").value;
	var body = document.getElementById("Message").value;
	window.open("mailto:wfrh7n@inf.elte.hu?subject=" + subject + "&body=" + body);
}
