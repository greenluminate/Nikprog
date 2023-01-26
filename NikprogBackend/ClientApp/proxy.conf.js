const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `${env.ASPNETCORE_HTTPS_PORT}` : // https://localhost:7224
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:32265';

const PROXY_CONFIG = [
  {
    context: [
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
      "/_framework"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
