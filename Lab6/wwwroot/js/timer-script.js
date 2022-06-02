const timerButton = document.getElementById('timer-button');
const timerCountdown = document.getElementById('timer-countdown');
let timer = null;

function timerButtonClicked() {
    if (timerButton.innerText === 'Start Timer') startTimer();
    else if (timerButton.innerText === 'Stop Timer') stopTimer();
}

function startTimer(){
    timerButton.innerText = 'Stop Timer';
    let timerMinutes = document.getElementById('timer-input-minutes').value;
    let timerSeconds = timerMinutes * 60 + parseInt(document.getElementById('timer-input-seconds').value);
    timer = setInterval(() => {
        updateCountdown(timerSeconds);
        --timerSeconds;
        if (timerSeconds < 0) {
            stopTimer();
            alert('Time is up.');
        }
    }, 1000);
}

function updateCountdown(seconds) {
    let minutes = Math.floor(seconds / 60);
    seconds -= minutes * 60;
    minutes = minutes < 10 ? '0' + minutes : minutes;
    seconds = seconds < 10 ? '0' + seconds : seconds;
    timerCountdown.innerText = minutes + ':' + seconds;
}

function stopTimer() {
    clearInterval(timer);
    timerButton.innerText = 'Start Timer';
    timerCountdown.innerText = '---';
}
