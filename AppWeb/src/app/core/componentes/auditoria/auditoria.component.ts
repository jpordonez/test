import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import {BaseCrudPaginaBuscador} from '../../../core/nucleo/controladores/base-crud-pagina-buscador';
import { UtilityService } from '../../../core/services/utility.service';
import {AuditoriaService} from '../../nucleo/servicios/auditoria/auditoria.service';
import {SelectItem} from 'primeng/primeng';

@Component({
  selector: 'app-auditoria',
  templateUrl: './auditoria.component.html',
  styleUrls: ['./auditoria.component.css']
})
export class AuditoriaComponent extends BaseCrudPaginaBuscador implements OnInit {

	constructor(public fb: FormBuilder,
				private utilityService: UtilityService,
				private auditoriaService: AuditoriaService) { 
		super(auditoriaService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Cuenta : new FormControl('', []),
			Identificador : new FormControl('', []),
			Funcionalidad : new FormControl('', []),
			Accion : new FormControl('', []),
			FechaInicio : new FormControl('', []),
			FechaFinal : new FormControl('', [])
		});

		this.entidadForm = this.fb.group({
			Id : new FormControl('', []),
			Mensaje : new FormControl('', []),
			Nivel : new FormControl('', []),
			Fecha : new FormControl('', []),
			Usuario : new FormControl('', []),
			Funcionalidad : new FormControl('', []),
			Accion : new FormControl('', []),
			Identificacion : new FormControl('', []),
			IpAddress : new FormControl('', [])         
		});

		this.alertaEntidad = {
			titulo : "Auditoría",
			mensaje : "",
			esVisible : false,
			esBloquear : false
		};		

	}

}
