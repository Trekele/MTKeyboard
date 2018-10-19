function dragResize(edge) {
  overwolf.windows.getCurrentWindow(function(result) {
    if (result.status == "success") {
      overwolf.windows.dragResize(result.window.id, edge);
    }
  });
}

function dragMove() {
  overwolf.windows.getCurrentWindow(function(result) {
    if (result.status == "success" && result.window.state !== "Maximized") {
      overwolf.windows.dragMove(result.window.id);
    }
  });
}

function closeWindow() {
  overwolf.windows.getCurrentWindow(function(result) {
    if (result.status == "success") {
      overwolf.windows.close(result.window.id);
    }
  });
}

function minimize() {
  overwolf.windows.getCurrentWindow(function(result) {
    if (result.status == "success") {
      overwolf.windows.minimize(result.window.id);
    }
  });
}

function toggleMaximize() {
  let element = document.querySelector(".maximize-restore-selector"),
    root = document.documentElement;

  overwolf.windows.getCurrentWindow(function(result) {
    if (result.status !== "success") {
      return;
    }

    if (element.checked) {
      overwolf.windows.restore(result.window.id);
      root.classList.remove("maximized");
    } else {
      overwolf.windows.maximize(result.window.id);
      root.classList.add("maximized");
    }
  });
}

function showSupport() {
  window.location.href = "overwolf://settings/support";
}

function openSubWindow() {
  alert("the subwindow will only be visible inside a game");
  overwolf.windows.obtainDeclaredWindow("SubWindow", function(result) {
    if (result.status == "success") {
      overwolf.windows.restore(result.window.id, function(result) {
        console.log(result);
      });
    }
  });
}

function takeScreenshot() {
  overwolf.media.takeScreenshot(function(result) {
    if (result.status == "success") {
      var img = document.getElementById("screenshot");
      img.src = result.url;
      img.onload = function() {
        overwolf.media.shareImage(img, "Screen Shot");
      };
    }
  });
}

function runTeamSpeak() {
  overwolf.extensions.launch("lmkhofgknaclgcdplfkgcahdkdmomimaoklioonf");
}
