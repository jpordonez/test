import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';

import { Router } from '@angular/router';
import { Usuario } from '../../seguridad/modelo/Usuario';
import { NotificationService } from '../../services/notification.service';
import { UtilityService } from '../../services/utility.service';
import { AplicacionServicio } from '../../seguridad/servicio/AplicacionServicio';
import { Alerta } from '../../nucleo/modelo/Alerta';
import { Observable } from 'rxjs/Rx';
import { LocalStorageHelper } from '../../util/LocalStorageHelper';
import { AuthServiceHelper } from '../../seguridad/util/AuthServiceHelper';
import { SeleccionarRolComponent } from './seleccionar-rol/seleccionar-rol.component';
import { Validaciones } from "app/core/nucleo/validaciones/validaciones";

@Component({
    selector: 'app-login',
    templateUrl: './login.html',
    styleUrls: ['./login.css']
})
export class LoginComponent implements OnInit {

    public alertaRecuperacionCredenciales: Alerta;
    public loginForm: FormGroup;
    public recuperacionCredencialesForm: FormGroup;
    public olvidaste: string;
    public accion: number = -1;

    constructor(public notificationService: NotificationService,
        private utilityService: UtilityService,
        private aplicacionServicio: AplicacionServicio,
        public fb: FormBuilder) {

    }

    ngOnInit() {
        this.loginForm = this.fb.group({
            usuUsuario: new FormControl('', Validators.required),
            usuClave: new FormControl('', Validators.required),
            recordarme: false
        });
        this.recuperacionCredencialesForm = this.fb.group({
            Correo: new FormControl('', [Validators.required, Validaciones.Correo])
        });
        this.alertaRecuperacionCredenciales = {
            titulo: "",
            mensaje: "",
            esVisible: false,
            esBloquear: false
        };
    }

    login(usuario: Usuario, esValido: boolean): void {
        LocalStorageHelper.set('esLogin', true);
        let resultado = this.aplicacionServicio.ingresar(usuario.usuUsuario, usuario.usuClave);
        resultado
            .then(
                (usuarioRol: any) => {
                    LocalStorageHelper.set('esLogin', false);
                    let usuarioActual = usuarioRol.usuario;
                    let rolActual = usuarioRol.rol;
                    LocalStorageHelper.set('usuarioActual', usuarioActual);
                    AuthServiceHelper.token = usuarioRol.miToken;
                    if (rolActual == null) {
                        // Se debe elegir un rol
                        LocalStorageHelper.set('urlActual', '/inicio');
                        LocalStorageHelper.set('roles', usuarioRol.roles);
                        this.utilityService.navegarASeleccionarRol();
                    } else {
                        //this.utilityService.setItemsMenu(this.aplicacionServicio.getMenu('MENSISPRIN'));
                        // El usuario tiene un rol y se fija por defecto
                        //console.log("rolActual login:"+JSON.stringify(rolActual));
                        LocalStorageHelper.set('rolActual', rolActual);
                        let ruta = '/inicio';
                        this.utilityService.navegar(ruta);
                    }
                }
            )
            .catch((error: any) => {
                //Cuando se lanza un error se resetea el formulario
                this.loginForm.reset();
            });
    }

    olvidoClave() {
        this.olvidaste = 'Clave';
        this.alertaRecuperacionCredenciales.titulo = "¿Olvidaste tu Clave?";
        this.alertaRecuperacionCredenciales.esVisible = true;
        this.accion = 0;
    }

    olvidoUsuario() {
        this.olvidaste = 'Usuario';
        this.alertaRecuperacionCredenciales.titulo = "¿Olvidaste tu Usuario?";
        this.alertaRecuperacionCredenciales.esVisible = true;
        this.accion = 1;
    }

    procesarRecuperacion() {
        let correo = this.recuperacionCredencialesForm.controls['Correo'];
        let resultado = this.aplicacionServicio.recuperarCredencial(correo.value, this.accion);
        resultado
            .then(
                (res: any) => {
                    if (this.accion == 0) {
                        this.utilityService.mostrarMensaje('Revise su correo y siga los pasos que se le indica para cambiar su clave.');
                    }
                    this.alertaRecuperacionCredenciales.esVisible = false;
                }
            )
            .catch(
                (error: any) => {

                }
            );
    }

}