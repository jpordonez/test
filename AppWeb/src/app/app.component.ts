import 'rxjs/add/operator/map';

import { Component, OnInit, Renderer } from '@angular/core';
import { Message } from 'primeng/primeng';

import { Alerta } from './core/nucleo/modelo/Alerta';
import { AplicacionServicio } from './core/seguridad/servicio/AplicacionServicio';
import { UtilityService } from './core/services/utility.service';

//enableProdMode();
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {    

    constructor(public utilityService: UtilityService,
        private aplicacionServicio: AplicacionServicio,
        public renderer: Renderer) {        
        /*let urlActual = location.hash;
        if (AppSettings.URLS_ANONIMAS.indexOf(urlActual) > -1) {
            //Se trata de una url anonima permitimos el paso sin autenticacion
            return;
        }
        if (!this.aplicacionServicio.esUsuarioAutenticado()) {
            if (urlActual == '#/cuenta/login') {
                LocalStorageHelper.set('urlActual', this.utilityService.urlActual());
                let timer = Observable.timer(1);
                timer.subscribe(t => this.utilityService.navegarAIngreso());
            } else {
                let timer = Observable.timer(1);
                timer.subscribe(t => window.location.href = '/assets/pages/landing.html');                
            }
        }*/
    }

    ngOnInit() {
        
    }   

    get alerta(): Alerta {
        return this.utilityService.getAlerta();
    }

    get mensajes(): Message[] {
        return this.utilityService.getMensajes();
    }

    set mensajes(mensajes: Message[]) {
        
    }

    get esVisibleMascaraProcesando() {
        return this.utilityService.getEsVisibleMascaraProcesando();
    }

    set esVisibleMascaraProcesando(esVisible: boolean) {
        
    }

}