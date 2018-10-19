function gameLaunched(gameInfoResult) {
    if (!gameInfoResult) {
        return false;
    }

    if (!gameInfoResult.gameInfo) {
        return false;
    }

    if (!gameInfoResult.runningChanged && !gameInfoResult.gameChanged) {
        return false;
    }

    if (!gameInfoResult.gameInfo.isRunning) {
        return false;
    }

    // NOTE: we divide by 10 to get the game class id without it's sequence number
    if (Math.floor(gameInfoResult.gameInfo.id / 10) != 10798) {
        return false;
    }

    console.log(gameInfoResult.gameInfo.title, 'was launched');

    return true;
}

function gameRunning(gameInfo) {
    console.log("gameRunning: " + gameInfo);
    if (!gameInfo) {
        return false;
    }

    if (!gameInfo.isRunning) {
        return false;
    }

    // NOTE: we divide by 10 to get the game class id without it's sequence number
    if (Math.floor(gameInfo.id / 10) != 10798) {
        return false;
    }

    console.log(gameInfo.title, 'is running');
    return true;
}

function setFeatures(requestedFeatures) {
    console.log("In setFeatures");
    overwolf.games.events.setRequiredFeatures(requestedFeatures, function (
        info
    ) {
        if (info.status == "error") {
            console.log("Could not set required features: " + info.reason);
            console.log("Trying in 2 seconds");
            window.setTimeout(setFeatures, 2000);
            return;
        }

        console.log("Set required features:");
        console.log(JSON.stringify(info));
    });
}