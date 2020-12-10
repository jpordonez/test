import { Component, OnInit } from '@angular/core';
import { BaseCrudPaginaBuscador } from '../../nucleo/controladores/base-crud-pagina-buscador';
import { Validators, FormControl, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { Validaciones } from '../../nucleo/validaciones/validaciones';
import { UtilityService } from '../../../core/services/utility.service';
import { FuncionalidadService } from '../../nucleo/servicios/funcionalidad/funcionalidad.service';
import { SelectItem } from 'primeng/primeng';
import { Accion } from '../../../core/nucleo/enums/accion.enum';

@Component({
	selector: 'app-funcionalidad',
	templateUrl: './funcionalidad.component.html',
	styleUrls: ['./funcionalidad.component.css']
})
export class FuncionalidadComponent extends BaseCrudPaginaBuscador implements OnInit {

	public estados: SelectItem[] = [];
	public acciones: any[];

	constructor(public fb: FormBuilder,
		private utilityService: UtilityService,
		private funcionalidadService: FuncionalidadService) {
		super(funcionalidadService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Nombre: new FormControl('', [])
		});

		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			Codigo: new FormControl({ value: null }, [Validators.required, Validaciones.Codigo]),
			Nombre: new FormControl({ value: null }, [Validators.required, Validaciones.NombreEspecial]),
			Controlador: new FormControl({ value: null }, [Validators.required]),
			Descripcion: new FormControl({ value: null }, [Validaciones.Descripcion]),
			EstadoId: new FormControl({ value: null }, [Validators.required]),
			Acciones: new FormControl({ value: null }, [])
		});

		this.alertaEntidad = {
			titulo: "Funcionalidad",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		this.estados = [];
		this.acciones = [];

		//Obtine los datos desde un API Rest
		var resultado = this.funcionalidadService.getDatosInicio();
		resultado
			.then(
				(res: any) => {
					this.estados.push({ label: 'Seleccione', value: null });
					this.estados = this.estados.concat(res.estados);
				}
			);
	}

	nuevo() {
		super.nuevo();
		//Fijar datos por defecto
		this.entidadForm.controls['EstadoId'].setValue(null);
		this.acciones = [];
	}

	editar(fila: number) {
		super.editar(fila);
		this.acciones = this.seleccionado.Acciones;
	}

	visualizar(fila: number) {
		super.visualizar(fila);
		this.acciones = this.seleccionado.Acciones;
	}

	eliminar(fila: number) {
		super.eliminar(fila);
		this.acciones = this.seleccionado.Acciones;
	}

	guardar(): void {

		if (this.accion == Accion.EDITAR && this.esValido()) {
			this.entidadForm.controls['Acciones'].setValue(this.acciones);
			super.guardar();
		} else {
			super.guardar();
		}
	}

	esValido(): boolean {
		for (var i = 0; i < this.acciones.length; i++) {
			for (var j = i + 1; j < this.acciones.length; j++) {
				let codigoI = this.acciones[i].Codigo;
				let codigoJ = this.acciones[j].Codigo;
				if (codigoI == codigoJ) {
					this.utilityService.mostrarMensaje('La opción con Código ' + codigoI + ' esta duplicada.');
					return false;
				}
			}
		}
		for (var i = 0; i < this.acciones.length; i++) {
			let codigo = this.acciones[i].Codigo;
			if (!codigo) {
				this.utilityService.mostrarMensaje('Ingrese un Código en la acción: ' + (i + 1));
				return false;
			}
			let nombre = this.acciones[i].Nombre;
			if (!nombre) {
				this.utilityService.mostrarMensaje('Nombre en la acción Código ' + this.acciones[i].Codigo + ' no es valido.');
				return false;
			}
		}
		return true;
	}

	nuevaAccion() {
		let accion = {};
		this.acciones = this.acciones.agregar(accion);
		this.entidadForm.controls['Acciones'].setValue(this.acciones);
	}

	eliminarAccion(fila: number) {
		this.acciones = this.acciones.eliminar(fila);
		this.entidadForm.controls['Acciones'].setValue(this.acciones);
	}

}
