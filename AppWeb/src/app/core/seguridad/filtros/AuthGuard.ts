import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AppSettings } from "app/core/constantes/app-settings";
import { LocalStorageHelper } from "app/core/util/LocalStorageHelper";
import { Observable } from "rxjs/Observable";
import { AplicacionServicio } from "app/core/seguridad/servicio/AplicacionServicio";
import { UtilityService } from "app/core/services/utility.service";

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(public utilityService: UtilityService,
        private aplicacionServicio: AplicacionServicio) {

    }

    canActivate() {
        let urlActual = location.hash;
        if (!this.aplicacionServicio.esUsuarioAutenticado()) {
            if (urlActual == '#/cuenta/login') {
                LocalStorageHelper.set('urlActual', this.utilityService.urlActual());
                let timer = Observable.timer(1);
                timer.subscribe(t => this.utilityService.navegarAIngreso());
            } else {
                let timer = Observable.timer(1);
                timer.subscribe(t => window.location.href = '/assets/pages/landing.html');
                //timer.subscribe(t => window.location.href = '/sitio/index.html');
            }
            return false;
        } else {
            return true;
        }
    }
}