/**
 * tabview服务，获取注册页面数组
 * Created by giscafer on 2017-07-20.
 */


import { Injectable, Type } from '@angular/core';

import { TabItem } from "./tab-item";
import { AuditoriaComponent } from 'app/core/componentes/auditoria/auditoria.component';
import { CatalogoComponent } from 'app/core/componentes/catalogo/catalogo.component';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { Peticion } from 'app/core/nucleo/modelo/peticion';

@Injectable()
export class TabViewService extends BaseServicio {
    tabs: TabItem[] = [];

    constructor() {
        super(null);
    }

    actualizarTabs(componente: Type<any>, nombre: string) {
        this.agregarUnicoComponente(componente, nombre);
        let peticion = new Peticion();
        peticion.data = {
            tabs: this.tabs
        };
        peticion.emisor = 'TABVIEWSERVICE';
        peticion.receptor = 'UITabView';
        this.notificarPeticion(peticion);
    }

    private agregarUnicoComponente(componente: Type<any>, nombre: string) {        
        let tabEncontrado = false;
        for (let tab of this.tabs) {
            if (tab.component && tab.component.name === componente.name) {
                tab.data.selected = true;
                tabEncontrado = true;
            } else {
                tab.data.selected = false;
            }
        }
        let tabs = [];
        for (var i = 0; i < this.tabs.length; i++) {
            tabs.push(this.tabs[i]);
        }
        if(!tabEncontrado){
            tabs.push(new TabItem(componente, { name: nombre, selected: true }));
        }
        
        this.tabs = [];
        this.tabs = tabs;
        return;
    }

}
