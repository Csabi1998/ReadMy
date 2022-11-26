const PROXY_CONFIG = [
  {
    "/api": {
      target: "https://localhost:7045",
      secure: false,
    },
  },
];

module.exports = PROXY_CONFIG;
