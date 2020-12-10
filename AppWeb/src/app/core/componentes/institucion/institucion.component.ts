import { Component, OnInit, OnDestroy } from '@angular/core';
import { BaseCrudPaginaBuscador } from '../../nucleo/controladores/base-crud-pagina-buscador';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { UtilityService } from '../../services/utility.service';
import { InstitucionService } from '../../nucleo/servicios/institucion/institucion.service';
import { Validaciones } from '../../nucleo/validaciones/validaciones';
import { SelectItem, MenuItem } from 'primeng/primeng';
import { Subscription } from 'rxjs/Subscription';
import { BuscadorPersonaService } from '../../nucleo/servicios/persona/buscador.service';
import { Peticion } from '../../nucleo/modelo/peticion';
import { BuscadorPersonaComponent } from '../../componentes/persona/buscador/buscador.component';

@Component({
	selector: 'app-institucion',
	templateUrl: './institucion.component.html',
	styleUrls: ['./institucion.component.css']
})
export class InstitucionComponent extends BaseCrudPaginaBuscador implements OnInit, OnDestroy {

	public inscritosEn: SelectItem[] = [];
	public subscripcion: Subscription;
	public representante: any = {};
	public accionesResponsable: MenuItem[];

	constructor(private fb: FormBuilder,
		private utilityService: UtilityService,
		private institucionService: InstitucionService,
		private buscadorPersonaService: BuscadorPersonaService) {
		super(institucionService);
		//Suscribir a notificaciones de utilizacion de buscador
		this.subscripcion = buscadorPersonaService.respuesta$.subscribe(
			respuesta => {
				let emisor = respuesta.emisor;
				switch (emisor) {
					case 'RESPON1':
						this.representante = respuesta.data;
						this.entidadForm.controls['RepresentanteId'].setValue(this.representante.Id);
						break;
					default:
						// code...
						break;
				}
			});
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Ruc: new FormControl('', []),
			Nombres: new FormControl('', [])
		});
		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			RepresentanteId: new FormControl('', []),
			RazonSocial: new FormControl('', [Validators.required, Validaciones.RazonSocial]),
			Ruc: new FormControl('', [Validators.required, Validaciones.Ruc]),
			InscritoId: new FormControl('', [Validators.required]),
			LugarInscripcion: new FormControl('', [Validaciones.Descripcion]),
			NumeroAcuerdoRegistro: new FormControl('', [Validators.pattern('[0-9]{8,10}')])
		});
		this.alertaEntidad = {
			titulo: "Institución",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		this.accionesResponsable = [
			{
				label: 'Limpiar', icon: 'ui-icon-clear', command: () => {
					this.representante = {};
					this.entidadForm.controls['RepresentanteId'].setValue(null);
				}
			}
		];

		var resultado = this.institucionService.getDatosInicio();

		resultado
			.then(
				(res: any) => {
					this.inscritosEn = res.inse;
				}
			);
	}

	buscarResponsable() {
		let peticion = new Peticion();
		peticion.data =
			{
				tipoPersonaNombre: 'Representantes'
			};
		peticion.emisor = 'RESPON1';
		peticion.receptor = BuscadorPersonaComponent.name;
		this.buscadorPersonaService.notificarPeticion(peticion);
	}

	nuevo() {
		super.nuevo();
		//Para fijar por defecto el primer valor del combo InscritosEn
		var institucion = {
			Id: 0,
			InscritoId: (this.inscritosEn.length > 0 ? this.inscritosEn[0].value : 0)
		};
		this.entidadForm.reset(institucion);
		this.representante = {};
	}

	visualizar(fila: number) {
		super.visualizar(fila);
		this.representante = {
			Identificacion: this.seleccionado.RepresentanteIdentificacion,
			Nombres: this.seleccionado.RepresentanteNombres,
			Apellidos: this.seleccionado.RepresentanteApellidos
		};
	}

	editar(fila: number) {
		super.editar(fila);
		this.representante = {
			Identificacion: this.seleccionado.RepresentanteIdentificacion,
			Nombres: this.seleccionado.RepresentanteNombres,
			Apellidos: this.seleccionado.RepresentanteApellidos
		};
	}

	eliminar(fila: number) {
		super.eliminar(fila);
		this.representante = {
			Identificacion: this.seleccionado.RepresentanteIdentificacion,
			Nombres: this.seleccionado.RepresentanteNombres,
			Apellidos: this.seleccionado.RepresentanteApellidos
		};
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		this.subscripcion.unsubscribe();
	}

}
