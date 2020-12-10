import {LocalStorageHelper} from '../../util/LocalStorageHelper';
//import {JwtHelper} from 'angular2-jwt';

export class AuthServiceHelper {
  //static jwtHelper = new JwtHelper();
  private static _token:string = LocalStorageHelper.get('authToken');
  //private static _tokenBody:any = LocalStorageHelper.get('authTokenBody');

  static init() {
    //if (this._token && this.jwtHelper.isTokenExpired(this._token)) {
      //this.token = null;
    //}
  }

  static extendHeaders(headers:any = {}):any {
    if (this._token) {
      if(LocalStorageHelper.get('usuarioActual')&&!LocalStorageHelper.get('esLogin')) {//Si es usuario autenticado envio token
        headers['token'] = this._token;
      } else {// Si no envio autorizacion basica o lo hago con un json en login como post
        //headers['Authorization'] = 'Basic ' + this._token;
        //headers['Authorization'] = 'Bearer ' + this._token;
      }      
      
    }
    return headers;
  }

  static get token() {
    return this._token;
  }

  static set token(newToken:string) {

    if (!newToken) {

      this._token = null;
      //this._tokenBody = null;

    } else {

      this._token = newToken;
      //this._tokenBody = AuthServiceHelper.jwtHelper.decodeToken(this._token);

    }

    LocalStorageHelper.set('authToken', this._token);
    //LocalStorageHelper.set('authTokenBody', this._tokenBody);

  }

  /*static get tokenBody():any {
    return this._tokenBody;
  }*/

  /*static set tokenBody(body:any) {
    console.error('Can\'t set token body');
  }*/

}