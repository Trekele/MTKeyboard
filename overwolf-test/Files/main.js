"use strict";

let MTKeyboardPlugin = null;

const REQUESTED_FEATURES = ["stats", "roster", "match", "me"];

let state = {};

function registerEvents() {
  // general events errors
  overwolf.games.events.onError.addListener(handleError);

  // "static" data changed (total kills, username, steam-id)
  // This will also be triggered the first time we register
  // for events and will contain all the current information
  overwolf.games.events.onInfoUpdates2.addListener(handleInfoUpdates2);

  // an event triggerd
  overwolf.games.events.onNewEvents.addListener(handleNewEvents);
}

async function handleError(info) {
  console.log("handleError", JSON.stringify(info, null, 2));
  await new Promise(function(resolve, reject) {
    MTKeyboardPlugin.handleError(JSON.stringify(info), function(result) {
      console.log("MTKeyboardPlugin.handleError", result);
      if (result.success) {
        resolve(true);
      } else {
        reject(false);
      }
    });
  });
  return;
}

async function handleInfoUpdates2(info) {
  console.log("handleInfoUpdates2", JSON.stringify(info, null, 2));
  await new Promise(function(resolve, reject) {
    MTKeyboardPlugin.handleInfoUpdates2(JSON.stringify(info), function(result) {
      console.log("MTKeyboardPlugin.handleInfoUpdates2", result);
      if (result.success) {
        resolve(true);
      } else {
        reject(false);
      }
    });
  });
  return;
  switch (info.feature) {
    case "roster":
      switch (Object.keys(info.info)[0]) {
        case "playersInfo":
          Object.keys(info.info.playersInfo).forEach(k => {
            let a = JSON.parse(decodeURI(info.info.playersInfo[k]));
            console.log(a);
          });

          break;

        default:
          break;
      }
      break;
    case "me":
      let key = Object.keys(info.info.me)[0];
      switch (key) {
        case "steamId":
          console.log(info.me[key]);
          break;
        case "name":
          console.log(info.info.me[key]);
          break;
        case "goals":
          console.log(info.info.me[key]);
          break;
        case "score":
          console.log(info.info.me[key]);
          break;
        case "deaths":
          console.log(info.info.me[key]);
          break;
        case "team":
          console.log(info.info.me[key]);
          break;
        case "team_score":
          console.log(info.info.me[key]);
          console.log("Sending updateScore request");
          await updateScore(info.info.me[key]);
          break;
        default:
          break;
      }

    default:
      break;
  }
}

async function handleNewEvents(info) {
  console.log("handleNewEvents", JSON.stringify(info, null, 2));
  await new Promise(function(resolve, reject) {
    MTKeyboardPlugin.handleNewEvents(JSON.stringify(info), function(result) {
      console.log("MTKeyboardPlugin.handleNewEvents", result);
      if (result.success) {
        resolve(true);
      } else {
        reject(false);
      }
    });
  });
  return;
}

async function handleGameInfoUpdated(res) {
  console.log("handleGameInfoUpdated: " + JSON.stringify(res, null, 2));
  await new Promise(function(resolve, reject) {
    MTKeyboardPlugin.handleGameInfoUpdated(JSON.stringify(res), function(
      result
    ) {
      console.log("MTKeyboardPlugin.handleGameInfoUpdated", result);
      if (result.success) {
        resolve(true);
      } else {
        reject(false);
      }
    });
  });
  if (gameLaunched(res)) {
    registerEvents();
    setTimeout(setFeatures(REQUESTED_FEATURES), 1000);
  }
}

async function handleGetRunningGameinfo(res) {
  console.log("handleGetRunningGameinfo: " + JSON.stringify(res, null, 2));
  if (res == null){

  } else {
    await new Promise(function(resolve, reject) {
      MTKeyboardPlugin.handleGetRunningGameinfo(JSON.stringify(res), function(
        result
      ) {
        console.log("MTKeyboardPlugin.handleGetRunningGameinfo", result);
        if (result.success) {
          resolve(true);
        } else {
          reject(false);
        }
      });
    });
  }
  if (gameRunning(res)) {
    registerEvents();
    setTimeout(setFeatures(REQUESTED_FEATURES), 1000);
  }
}

function print(body) {
  console.log(body);
}

async function initPlugins() {
  console.log("initPlugins()");
  return new Promise(function(resolve, reject) {
    console.log("Promise(");
    overwolf.extensions.current.getManifest(result => {
      console.log("manifest", result);
    });
    overwolf.extensions.current.getExtraObject("mt-keyboard-plugin", result => {
      console.log("get object success");
      if (result.status == "success") {
        MTKeyboardPlugin = result.object;
        MTKeyboardPlugin.debug.addListener(print);
        console.log("Initialize");
        MTKeyboardPlugin.Initialize(function(result) {
          console.log("init result", result);
          if (result == "failed to initialize") {
            reject();
          } else {
            resolve();
          }
        });
      }
    });
  });
}

async function setColor(color) {
  return new Promise(function(resolve, reject) {
    MTKeyboardPlugin.setColor("Green", function(result) {
      console.log("result", result);
      if (result) {
        resolve(true);
      } else {
        reject(false);
      }
    });
  });
}

async function updateScore(score) {
  return new Promise(function(resolve, reject) {
    let body = {
      score: score
    };
    console.log("MTKeyboardPlugin", MTKeyboardPlugin);
    MTKeyboardPlugin.setScore(body, function(result) {
      console.log("result", result);
      if (result) {
        resolve(true);
      } else {
        reject(false);
      }
    });
  });
}

async function init() {
  // Start here
  console.log("init plugins");
  await initPlugins();
  console.log("after plugins");

  overwolf.games.onGameInfoUpdated.addListener(handleGameInfoUpdated);

  overwolf.games.getRunningGameInfo(handleGetRunningGameinfo);
}

async function main() {
  await init();
}

$(main);
