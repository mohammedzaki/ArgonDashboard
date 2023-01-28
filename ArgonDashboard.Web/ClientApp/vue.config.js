// vue.config.js
const fs = require('fs');
const sslPath = require('./ssl-path-config.js');
const proxyConfig = require('./proxy.conf.js');

/**
 * @type {import('@vue/cli-service').ProjectOptions}
 */
module.exports = {
    devServer: {
        port: 44479,
        https: true,
        key: fs.readFileSync(sslPath.keyFilePath),
        cert: fs.readFileSync(sslPath.certFilePath),
        proxy: proxyConfig
    }
}