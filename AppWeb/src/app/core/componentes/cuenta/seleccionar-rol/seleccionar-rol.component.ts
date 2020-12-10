import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import {SelectItem} from 'primeng/primeng';
import { Alerta } from '../../../nucleo/modelo/Alerta';
import {Observable} from 'rxjs/Rx';
import { Rol } from '../../../seguridad/modelo/Rol';
import {AplicacionServicio} from '../../../seguridad/servicio/AplicacionServicio';
import {LocalStorageHelper} from '../../../util/LocalStorageHelper';
import { UtilityService } from '../../../services/utility.service';
import { AuthServiceHelper } from '../../../seguridad/util/AuthServiceHelper';

@Component({
  selector: 'app-seleccionar-rol',
  templateUrl: './seleccionar-rol.component.html',
  styleUrls: ['./seleccionar-rol.component.css']
})
export class SeleccionarRolComponent implements OnInit {

	alertaRol: Alerta;
	rolesForm: FormGroup;
    roles: any;

	constructor(public fb: FormBuilder,
		private aplicacionServicio: AplicacionServicio,
		private utilityService: UtilityService) { }

	ngOnInit() {
		this.rolesForm = this.fb.group({
		    rolCodigo : new FormControl('', Validators.required)
		});
		this.alertaRol = {
            titulo : "",
            mensaje : "",
            esVisible : false,
            esBloquear : false
        };
        this.roles=LocalStorageHelper.get('roles');
        let timer = Observable.timer(100);
        timer.subscribe(t=>this.alertaRol.esVisible = true);        
	}

	setRol(rol: any, esValido: boolean): void {		         
        let resultado = this.aplicacionServicio.setRol(rol);
        resultado
          .$observable
          .subscribe(
            (res: any) => {                    
                //LocalStorageHelper.set('usuarioActual',res.usuario);
                LocalStorageHelper.set('rolActual',res.rol);
                LocalStorageHelper.remove('roles');                
                AuthServiceHelper.token = res.miToken;                
                //this.utilityService.setItemsMenu(this.aplicacionServicio.getMenu('MENSISPRIN'));
                let navegarA = LocalStorageHelper.get('urlActual')?LocalStorageHelper.get('urlActual'):'/inicio';
                this.utilityService.navegar(navegarA);                        
                this.alertaRol.esVisible = false;       
            }
          );   
    }

}
