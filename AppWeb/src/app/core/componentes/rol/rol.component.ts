import { Component, OnInit } from '@angular/core';
import { BaseCrudPaginaBuscador } from '../../nucleo/controladores/base-crud-pagina-buscador';
import { Validaciones } from '../../nucleo/validaciones/validaciones';
import { Validators, FormControl, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { UtilityService } from '../../../core/services/utility.service';
import { RolService } from '../../nucleo/servicios/rol/rol.service';
import { SelectItem } from 'primeng/primeng';
import { Accion } from '../../nucleo/enums/accion.enum';

@Component({
	selector: 'app-rol',
	templateUrl: './rol.component.html',
	styleUrls: ['./rol.component.css']
})
export class RolComponent extends BaseCrudPaginaBuscador implements OnInit {

	public funcionalidadesAcciones: any[];
	public permisos: any[];

	constructor(public fb: FormBuilder,
		private utilityService: UtilityService,
		private rolService: RolService) {
		super(rolService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Nombre: new FormControl('', [])
		});

		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			Codigo: new FormControl({ value: null }, [Validators.required, Validaciones.Codigo]),
			Nombre: new FormControl({ value: null }, [Validators.required, Validaciones.NombreEspecial]),
			EsAdministrador: new FormControl({ value: false }, [Validators.required]),
			EsExterno: new FormControl({ value: false }, [Validators.required]),
			Url: new FormControl({ value: null }, []),
			Parametros: new FormControl({ value: null }, []),
			Permisos: new FormControl({ value: null }, [])
		});

		this.alertaEntidad = {
			titulo: "Rol",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		this.permisos = [];

		var resultado = this.rolService.getDatosInicio();
		resultado
			.then(
				(res: any) => {
					this.funcionalidadesAcciones = [];
					this.funcionalidadesAcciones.push({ label: 'Seleccione', value: null });
					this.funcionalidadesAcciones = this.funcionalidadesAcciones.concat(res.funcionalidadesAcciones);
				}
			);

	}

	nuevo() {
		super.nuevo();
		//Fijar datos por defecto
		this.entidadForm.controls['EsAdministrador'].setValue(false);
		this.entidadForm.controls['EsExterno'].setValue(false);
		this.permisos = [];

	}

	editar(fila: number) {
		super.editar(fila);
		this.permisos = this.entidadForm.controls['Permisos'].value;
	}

	visualizar(fila: number) {
		super.visualizar(fila);
		this.permisos = this.entidadForm.controls['Permisos'].value;
	}

	eliminar(fila: number) {
		super.eliminar(fila);
		this.permisos = this.entidadForm.controls['Permisos'].value;
	}

	guardar(): void {
		if (this.accion == Accion.EDITAR && this.esValido()) {
			this.entidadForm.controls['Permisos'].setValue(this.permisos);
			super.guardar();
		} else {
			super.guardar();
		}
	}

	esValido(): boolean {
		for (var i = 0; i < this.permisos.length; i++) {
			for (var j = 0; j < this.permisos.length; j++) {
				let accionId = this.permisos[i].AccionId;
				if (!accionId) {
					this.utilityService.mostrarMensaje('Todos los permisos deben tener una funcionalidad acción.');
					return false;
				}
			}
		}
		return true;
	}

	nuevoPermiso() {
		let permiso = {};
		this.permisos = this.permisos.agregar(permiso);
		this.entidadForm.controls['Permisos'].setValue(this.permisos);
	}

	eliminarPermiso(fila: number) {
		this.permisos = this.permisos.eliminar(fila);
		this.entidadForm.controls['Permisos'].setValue(this.permisos);
	}

}
