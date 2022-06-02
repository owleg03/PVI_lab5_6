function userInfo(login, password) {
    console.log("login: " + login.value + ", password: " + password.value);
}

function removeRedBorder(element) {
    element.style.borderColor = "";
}

function addRedBorder(element) {
    element.style.borderColor = "red";
}

function loginAction(event) {
    const form = document.getElementById('log-in');
    const login = form['login'];
    if (login.value === "") {
        alert('Please provide a login.');
        event.preventDefault();
        addRedBorder(login);
        return false;
    }
    if (login.value.length > 10) {
        alert('Login cant not be longer than 10 symbols.');
        event.preventDefault();
        addRedBorder(login);
        return false;
    }
    const password = form['password'];
    if (password.value === "") {
        alert('Please provide a password.');
        event.preventDefault();
        addRedBorder(password);
        return false;
    }
    if (password.value.length < 5 || password.value.length > 15) {
        alert('Password must be 5-15 symbols long.');
        event.preventDefault();
        addRedBorder(password);
        return false;
    }
    let regEx = /^[a-zA-Z0-9]+$/;
    if (!regEx.test(password.value))
    {
        alert('Password can only contain upper and lower case letters, numbers.');
        event.preventDefault();
        addRedBorder(login);
        return false;
    }
    userInfo(login, password);
}

function registerAction() {
    location.href = "register.html";
}
