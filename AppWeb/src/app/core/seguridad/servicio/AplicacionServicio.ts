import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions } from '@angular/http';
import { Excepcion } from '../../nucleo/modelo/Excepcion';
import { Usuario } from '../modelo/Usuario';
import { Rol } from '../modelo/Rol';
import { AplicacionRecurso } from '../recurso/AplicacionRecurso';
import { AuthServiceHelper } from '../util/AuthServiceHelper';
import { UtilityService } from '../../services/utility.service';
import { Observable } from 'rxjs';
import { LocalStorageHelper } from '../../util/LocalStorageHelper';
import { Base64 } from '../../util/Base64';
import { MenuItem } from 'primeng/primeng';
import { AppSettings } from '../../constantes/app-settings';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AplicacionServicio {

    newList: Excepcion[] = [];

    constructor(private http: HttpClient,
        private appRec: AplicacionRecurso,
        public utilityService: UtilityService) { }

    getCarsMedium() {
        return this.appRec.query({ pagina: 1, limite: 10 });
    }

    async getMenu(codigo: string): Promise<MenuItem[]> {
        if (this.esUsuarioAutenticado()) {
            var menu = await this.appRec.getMenu({ valor: codigo });
            return menu;
        } else {
            return [];
        }
    }

    ingresar(usuario: string, clave: string) {
        //let authToken = Base64.encode(usuario+':'+clave);
        //console.log(authToken);
        //AuthServiceHelper.token = authToken;        
        return this.appRec.ingresar({ Usuario: usuario, Password: clave });
        /*return this.http.post(AppSettings.API_ENDPOINT+'Cuenta/Ingresar',
            JSON.stringify({Usuario:usuario,Password:clave}), 
            { withCredentials: true,
                headers: new Headers({
                'Content-Type': 'application/x-www-form-urlencoded'
                })
            }
        );*/
    }

    setRol(rol: Rol): any {
        return this.appRec.setRol({ RolCodigo: rol.rolCodigo, IPClient: this.getIpCliente(), Token: AuthServiceHelper.token });
    }

    esUsuarioAutenticado(): boolean {
        var _user: Usuario = LocalStorageHelper.get('usuarioActual');
        if (_user != null)
            return true;
        else
            return false;
    }

    getUsuarioActual(): Usuario {
        var usuario: Usuario;

        if (this.esUsuarioAutenticado()) {
            usuario = LocalStorageHelper.get('usuarioActual');
        }

        return usuario;
    }

    getRolActual(): Rol {
        var rol: Rol;

        if (this.esUsuarioAutenticado()) {
            rol = LocalStorageHelper.get('rolActual');
        }

        return rol;
    }

    salir() {
        if (this.esUsuarioAutenticado()) {
            //Cierra sesion del lado del API Rest
            var resultado = this.appRec.salir({ valor: AuthServiceHelper.token });
            resultado
                .then(
                    (res: any) => {
                        this.utilityService.resetearSesion();
                        //let timer = Observable.timer(100);
                        //timer.subscribe(t=>this.utilityService.navegarAIngreso());
                        window.location.href = '/assets/pages/landing.html';               
                        //window.location.href = '/sitio/index.html';
                    }
                );
        }
    }

    recuperarCredencial(correo: string, accion: number): Promise<any> {
        return this.appRec.recuperarCredencial({ correo: correo, accion: accion });
    }

    limpiarCache(): Promise<any> {
        return this.appRec.limpiarCache();
    }

    recargarContextoEF(): Promise<any> {
        return this.appRec.recargarContextoEF();
    }

    getIpCliente(): string {
        var json = 'http://ipv4.myexternalip.com/json';
        var ip = '0.0.0.0';
        var resultado = this.http.get(json)
            .map((res: Response) => ip = res.json().ip);
        return ip;
    }

    recuperarClave(clave: string, param: string): Promise<any> {
        return this.appRec.cambiarClave({ clave: clave, param: param });
    }

}
