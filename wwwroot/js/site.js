//rickydeptrai
const login = document.getElementById("login");
const signup = document.getElementById("signup");
const forgot = document.getElementById("forgot");
function showLogin() {
    signup.style.display = "none";
    forgot.style.display = "none";
    login.style.display = "block";
}
function showSignup() {
    login.style.display = "none";
    signup.style.display = "block";
}
function showForgotPass() {
    login.style.display = "none";
    forgot.style.display = "block";
}

function togglePassword(id, el) {
    const input = document.getElementById(id);
    if (input.type === 'password') {
        input.type = 'text';
        el.textContent = '🙈';
    } else {
        input.type = 'password';
        el.textContent = '🐵';
    }
}
