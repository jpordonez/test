"use strict";
var LocalStorageHelper_1 = require('../../util/LocalStorageHelper');
//import {JwtHelper} from 'angular2-jwt';
var AuthServiceHelper = (function () {
    function AuthServiceHelper() {
    }
    //private static _tokenBody:any = LocalStorageHelper.get('authTokenBody');
    AuthServiceHelper.init = function () {
        //if (this._token && this.jwtHelper.isTokenExpired(this._token)) {
        //this.token = null;
        //}
    };
    AuthServiceHelper.extendHeaders = function (headers) {
        if (headers === void 0) { headers = {}; }
        if (this._token) {
            if (LocalStorageHelper_1.LocalStorageHelper.get('usuarioActual') && !LocalStorageHelper_1.LocalStorageHelper.get('esLogin')) {
                headers['X-Auth-Token'] = this._token;
            }
            else {
                headers['Authorization'] = 'Basic ' + this._token;
            }
        }
        return headers;
    };
    Object.defineProperty(AuthServiceHelper, "token", {
        get: function () {
            return this._token;
        },
        set: function (newToken) {
            if (!newToken) {
                this._token = null;
            }
            else {
                this._token = newToken;
            }
            LocalStorageHelper_1.LocalStorageHelper.set('authToken', this._token);
            //LocalStorageHelper.set('authTokenBody', this._tokenBody);
        },
        enumerable: true,
        configurable: true
    });
    //static jwtHelper = new JwtHelper();
    AuthServiceHelper._token = LocalStorageHelper_1.LocalStorageHelper.get('authToken');
    return AuthServiceHelper;
}());
exports.AuthServiceHelper = AuthServiceHelper;
//# sourceMappingURL=AuthServiceHelper.js.map