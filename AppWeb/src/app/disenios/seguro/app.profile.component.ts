import { Component, Input, OnInit, EventEmitter, ViewChild, trigger, state, transition, style, animate, Inject, forwardRef } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/primeng';
import { AplicacionServicio } from "app/core/seguridad/servicio/AplicacionServicio";
import { SeguroComponent } from "app/disenios/seguro/seguro.component";

enum MenuOrientation {
    STATIC,
    OVERLAY,
    HORIZONTAL
};

@Component({
    selector: 'inline-profile',
    template: `
        <div class="profile" [ngClass]="{'profile-expanded':active}">
            <!--<div class="profile-image"></div>-->
            <div style="text-align: center;">
                <img [src]="ImagenPerfil" alt="Imagen Perfil" height="70" width="70">
            </div>
            <a href="#/perfil"> <!--(click)="onClick($event)">-->
                <span class="profile-name">{{nombresYApellidosUsuarioActual}}</span>
                <span>como {{rolActual}}</span>
                <i class="material-icons" *ngIf="false">keyboard_arrow_down</i>
            </a>
        </div>

        <ul class="ultima-menu profile-menu" [@menu]="active ? 'visible' : 'hidden'" *ngIf="false">
            <li role="menuitem">
                <a href="#" class="ripplelink" [attr.tabindex]="!active ? '-1' : null">
                    <i class="material-icons">person</i>
                    <span>Profile</span>
                </a>
            </li>
            <li role="menuitem">
                <a href="#" class="ripplelink" [attr.tabindex]="!active ? '-1' : null">
                    <i class="material-icons">security</i>
                    <span>Privacy</span>
                </a>
            </li>
            <li role="menuitem">
                <a href="#" class="ripplelink" [attr.tabindex]="!active ? '-1' : null">
                    <i class="material-icons">settings_application</i>
                    <span>Settings</span>
                </a>
            </li>
            <li role="menuitem">
                <a (click)="salir()" href="#" class="ripplelink" [attr.tabindex]="!active ? '-1' : null">
                    <i class="material-icons">power_settings_new</i>
                    <span>Salir</span>
                </a>
            </li>
        </ul>
    `,
    animations: [
        trigger('menu', [
            state('hidden', style({
                height: '0px'
            })),
            state('visible', style({
                height: '*'
            })),
            transition('visible => hidden', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)')),
            transition('hidden => visible', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)'))
        ])
    ]
})
export class InlineProfileComponent {

    constructor( @Inject(forwardRef(() => SeguroComponent)) public app: SeguroComponent,
        private aplicacionServicio: AplicacionServicio) {

    }

    active: boolean;

    onClick(event) {
        this.active = !this.active;
        event.preventDefault();
    }

    salir() {
        this.aplicacionServicio.salir();

        /*Codigo para ocultar el menu al salir del sistema*/
        if (this.app.layoutMode === MenuOrientation.OVERLAY) {
            this.app.overlayMenuActive = false;
        }
        else {
            if (this.app.isDesktop())
                this.app.staticMenuDesktopInactive = false;
            else
                this.app.staticMenuMobileActive = false;
        }
    }

    get nombresYApellidosUsuarioActual() {
        if (this.aplicacionServicio.esUsuarioAutenticado()) {
            var usuario = this.aplicacionServicio.getUsuarioActual();
            return usuario.usuNombres + ' ' + usuario.usuApellidos;
        } else {
            return 'Anonimo';
        }
    }

    get rolActual() {
        if (this.aplicacionServicio.esUsuarioAutenticado()) {
            var rol = this.aplicacionServicio.getRolActual();
            if (rol) {
                return rol.rolNombre;
            } else {
                return 'Anonimo';
            }
        } else {
            return 'Anonimo';
        }
    }

    get ImagenPerfil() {
        let imagenPorDefecto = 'assets/layout/images/avatar1.png';
        if (this.aplicacionServicio.esUsuarioAutenticado()) {
            var usuario = this.aplicacionServicio.getUsuarioActual();
            if (usuario.ImagenPerfil) {
                return usuario.ImagenPerfil;
            } else {
                return imagenPorDefecto;
            }

        } else {
            return imagenPorDefecto;
        }
    }

}