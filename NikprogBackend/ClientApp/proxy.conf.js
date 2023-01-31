const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}/api` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:32265/api';

const PROXY_CONFIG = [
  {
    context: [
      /*      "/",*/
      //"/api/",
      //"/api",
      //"/api/*",
      //"/api/**",
      //"/*",
      "/**",
      "/*"
      //"/course",
      //"/module",
      //"/_configuration",
      //"/.well-known",
      //"/Identity",
      //"/connect",
      //"/ApplyDatabaseMigrations",
      //"/_framework"
    ],
    target: target, // "https://localhost:5137", // 7224
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
