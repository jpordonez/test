import { Component, OnInit } from '@angular/core';
import { BaseCrudPaginaBuscador } from '../../nucleo/controladores/base-crud-pagina-buscador';
import { Validaciones } from '../../nucleo/validaciones/validaciones';
import { Validators, FormControl, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { UtilityService } from '../../../core/services/utility.service';
import { ParametroService } from '../../nucleo/servicios/parametro/parametro.service';
import { Accion } from '../../../core/nucleo/enums/accion.enum';

@Component({
	selector: 'app-parametro',
	templateUrl: './parametro.component.html',
	styleUrls: ['./parametro.component.css']
})
export class ParametroComponent extends BaseCrudPaginaBuscador implements OnInit {

	public opciones: any[];
	public tipos: any[];

	constructor(public fb: FormBuilder,
		private utilityService: UtilityService,
		private parametroService: ParametroService) {
		super(parametroService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Nombre: new FormControl('', [])
		});

		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			Codigo: new FormControl({ value: null }, [Validators.required, Validaciones.Codigo]),
			Nombre: new FormControl({ value: null }, [Validators.required, Validaciones.NombreEspecial]),
			Descripcion: new FormControl({ value: null }, [Validaciones.Descripcion]),
			Tipo: new FormControl({ value: null }, [Validators.required]),
			Valor: new FormControl({ value: null }, [Validators.required]),
			EsEditable: new FormControl({ value: false }, [Validators.required]),
			Opciones: new FormControl({ value: null }, [])
		});

		this.alertaEntidad = {
			titulo: "Parametro",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		this.opciones = [];
		this.tipos = [];

		//Obtine los datos desde un API Rest
		var resultado = this.parametroService.getDatosInicio();
		resultado
			.then(
				(res: any) => {
					this.tipos.push({ label: 'Seleccione', value: null });
					this.tipos = this.tipos.concat(res.tipos);
				}
			);

	}

	nuevo() {
		super.nuevo();
		//Fijar datos por defecto
		this.entidadForm.controls['EsEditable'].setValue(false);
		this.opciones = [];
	}

	editar(fila: number) {
		super.editar(fila);
		this.opciones = this.seleccionado.Opciones;
	}

	visualizar(fila: number) {
		super.visualizar(fila);
		this.opciones = this.seleccionado.Opciones;
	}

	eliminar(fila: number) {
		super.eliminar(fila);
		this.opciones = this.seleccionado.Opciones;
	}

	guardar(): void {
		if (this.esValido()) {
			super.guardar();
		}
	}

	esValido(): boolean {
		for (var i = 0; i < this.opciones.length; i++) {
			for (var j = i + 1; j < this.opciones.length; j++) {
				let textoI = this.opciones[i].Texto;
				let textoJ = this.opciones[j].Texto;
				if (textoI == textoJ) {
					this.utilityService.mostrarMensaje('La opción ' + textoI + ' esta duplicada.');
					return false;
				}
			}
		}
		for (var i = 0; i < this.opciones.length; i++) {
			let texto = this.opciones[i].Texto;
			if (!texto) {
				this.utilityService.mostrarMensaje('Ingrese un texto en la opción: ' + (i + 1));
				return false;
			}
			let valor = this.opciones[i].Valor;
			if (!valor) {
				this.utilityService.mostrarMensaje('Valor en la opción ' + this.opciones[i].Texto + ' no es valido.');
				return false;
			}
		}
		return true;
	}

	nuevaOpcion() {
		let opcion = {};
		this.opciones = this.opciones.agregar(opcion);
		this.entidadForm.controls['Opciones'].setValue(this.opciones);
	}

	eliminarOpcion(fila: number) {
		this.opciones = this.opciones.eliminar(fila);
		this.entidadForm.controls['Opciones'].setValue(this.opciones);
	}

}
