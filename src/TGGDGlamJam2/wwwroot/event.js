function doEvent(details) {
    const PLAY_SFX = "playSfx";
    let eventType = details.shift();
    if (eventType == PLAY_SFX) {
        let audio = document.getElementById(details.shift());
        audio.currentTime = 0;
        audio.play();
    }
}