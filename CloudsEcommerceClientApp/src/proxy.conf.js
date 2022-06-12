const PROXY_CONFIG = {
  "/api": {
    target: "https://localhost:7065",
    secure: false
  }
}

module.exports = PROXY_CONFIG;
