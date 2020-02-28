
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const url = "https://localhost:44359/api/Users/";

function choosenAvatar(id) {
	document.getElementById("avatar").value = id
	document.getElementById("avatarImg").src = id
}


function signUp() {
	const formData = new FormData();

	var email = document.getElementById("email").value;
	var nickName = document.getElementById("nickName").value;
	var password = document.getElementById("password").value;
	var avatar = document.getElementById("avatar").value;

	formData.append("email", email);
	formData.append("nickName", nickName);
	formData.append("password", password);
	formData.append("avatar", avatar);

	fetch(`${url}`, {
		method: 'POST',		
		body: formData
	})
		.then(response => response.text())			
		.then(data => {
			alert(data);
		})
		.catch(error => console.error('Unable to get Account.', error));
}

function signIn() {
	const formData = new FormData();

	var email = document.getElementById("signInEmail").value;
	var password = document.getElementById("signInPassword").value;

	formData.append("signInEmail", email);
	formData.append("signInPassword", password);

	fetch(`${url}`, {
		method: 'PUT',
		body: formData
	})
		.then(response => response.text())
		.then(data => {
			localStorage.setItem("user", data);
			window.location.href = "/Home/MyPage";

		})
		.catch(error => console.error('Unable to get Account.', error));

}