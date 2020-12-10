import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageHelper } from '../util/LocalStorageHelper';
import { Alerta } from '../nucleo/modelo/Alerta';
import { MenuItem, Message } from 'primeng/primeng';

@Injectable()
export class UtilityService {

    private _router: Router;
    private alerta: Alerta;
    private mensajes: Message[];
    private menuItems: MenuItem[];
    private esVisibleMascaraProcesando: boolean;

    constructor(router: Router) {
        this._router = router;
        this.alerta = {
            titulo: "",
            mensaje: "",
            esVisible: false,
            esBloquear: false
        };
        this.esVisibleMascaraProcesando = false;
    }

    convertDateTime(date: Date) {
        var _formattedDate = new Date(date.toString());
        return _formattedDate.toDateString();
    }

    navegar(ruta: string) {
        this._router.navigate([ruta]);
    }

    navegarAIngreso() {
        this.navegar('/cuenta/login');
    }

    navegarASeleccionarRol() {
        this.navegar('/cuenta/seleccionar_rol');
    }

    urlActual() {
        return this._router.url;
    }

    resetearSesion() {
        LocalStorageHelper.remove('usuarioActual');
        LocalStorageHelper.remove('rolActual');
        this.menuItems = [];
    }

    mostrarMensaje(mensaje: string, severidad?: string, titulo?: string, enAlerta?: boolean) {
        if (titulo) {
            this.alerta.titulo = titulo;
        } else {
            this.alerta.titulo = "Mensaje";
        }
        if (!enAlerta) {
            if (!severidad) {
                severidad = 'success';
            }
            this.mensajes = [];
            this.mensajes.push({ severity: severidad, summary: titulo, detail: mensaje });
        } else {
            this.alerta.mensaje = mensaje;
            this.alerta.esVisible = true;
        }
    }

    getAlerta(): Alerta {
        return this.alerta;
    }

    getMensajes(): Message[] {
        return this.mensajes;
    }

    getItemsMenu(): MenuItem[] {
        return this.menuItems;
    }

    setItemsMenu(menuItems: MenuItem[]) {
        this.menuItems = menuItems;
    }

    getEsVisibleMascaraProcesando() {
        return this.esVisibleMascaraProcesando;
    }

    setEsVisibleMascaraProcesando(esVisibleMascaraProcesando: boolean) {
        return this.esVisibleMascaraProcesando = esVisibleMascaraProcesando;
    }

}