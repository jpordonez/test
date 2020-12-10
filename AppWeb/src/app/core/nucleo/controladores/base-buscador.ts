import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { ViewChild, OnDestroy } from '@angular/core';
import { LazyLoadEvent, DataTable } from 'primeng/primeng';
import { ServiceLocator } from 'app/core/nucleo/di/ServiceLocator';
import { Alerta } from 'app/core/nucleo/modelo/Alerta';
import { UtilityService } from 'app/core/services/utility.service';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { AppSettings } from 'app/core/constantes/app-settings';
import { Mensajes } from 'app/core/constantes/mensajes';
import { Util } from 'app/core/util/util';
import { Respuesta } from 'app/core/nucleo/modelo/respuesta';
import { Peticion } from 'app/core/nucleo/modelo/peticion';
import { Subscription } from 'rxjs/Subscription';
import { FormularioUtil } from 'app/core/nucleo/formularios/formulario-util';

export abstract class BaseBuscador implements OnDestroy {

	private subscripcion: Subscription;

	public criteriaForm: FormGroup;
	public alertaBuscador: Alerta;
	public lista: any[];
	public seleccionado: any;
	public indiceSeleccionado: number;
	public tamanioPagina: number;
	public totalRegistros: number;
	public tablaSinDatos: string;
	private emisor: string;
	@ViewChild('dtbuscador') protected dtbuscador: DataTable;
	public es: any;
	protected utilService: UtilityService = ServiceLocator.get(UtilityService);

	constructor(private baseServicio: BaseServicio) {
		this.seleccionado = {};
		this.lista = [];
		this.tamanioPagina = AppSettings.TAMANIO_PAGINA;
		this.tablaSinDatos = Mensajes.TABLA_SIN_DATOS;
		this.es = AppSettings.METADATA_CALENDARIO_ES;
		//Suscribir a notificaciones de utilizacion de buscador
		this.subscripcion = baseServicio.peticion$.subscribe(
			peticion => {
				if (peticion.receptor === this.constructor.name) {
					this.visualizar(peticion);
				}
			});
	}

	resetearPaginacionYBuscar() {
		//Es necesario definir la tabla de resultados de buscador como #dtbuscador
		//con la finalidad de acceder a modificar la metadadta de paginacion cuando sea necesario
		//en este caso se desea resetear a su estado inicial.
		if (this.dtbuscador) {
			//Metodo llama al evento de buscarPaginado(event: LazyLoadEvent) si se definio
			//en la tabla de resultados, el mismo llama al api rest para recuperar la primera pagina
			this.dtbuscador.reset();
		} else {
			console.error('Definir la tabla de resultado con identificador #dtbuscador en el template de: ' + Util.getNombreClase(this));
		}

	}

	buscar(pagina: number) {
		if (!this.criteriaForm.contains('NumeroPagina')) {
			this.criteriaForm.addControl('NumeroPagina', new FormControl('', []));
		}
		this.criteriaForm.controls['NumeroPagina'].setValue(pagina);

		let criteria = FormularioUtil.getEntidadCompleta(this.criteriaForm);
		let respuesta = this.baseServicio.listar(criteria);
		respuesta
			.then(
				(res: any) => {
					this.lista = res.Data;
					if (!this.lista) {
						this.lista = [];
					}
					this.totalRegistros = res.TotalRegistros;
					if (!this.totalRegistros) {
						this.totalRegistros = 1;
					}
					this.seleccionado = null;
				}
			);
	}

	buscarPaginado(event: LazyLoadEvent) {
		//Para no realizar busquedas cuando se crean las intancias de buscadores
		if (!this.alertaBuscador.esVisible) {			
			return;
		}
		//in a real application, make a remote request to load data using state metadata from event
		//event.first = First row offset
		//event.rows = Number of rows per page
		//event.sortField = Field name to sort with
		//event.sortOrder = Sort order as number, 1 for asc and -1 for dec
		//filters: FilterMetadata object having field as key and filter value, filter matchMode as value
		let pagina = (event.first / event.rows) + 1;
		this.buscar(pagina);
	}

	limpiarCriteria() {
		this.criteriaForm.reset();
	}

	aceptar() {
		let respuesta = new Respuesta();
		respuesta.emisor = this.emisor;
		respuesta.data = this.seleccionado;
		this.baseServicio.notificarRespuesta(respuesta);
		this.alertaBuscador.esVisible = false;
		this.criteriaForm.reset();
	}

	visualizar(peticion: Peticion) {
		this.criteriaForm.reset();
		this.emisor = peticion.emisor;
		if (this.emisor == null || this.emisor == '') {
			console.error("El emisor no puede ser nulo o vacio.");
			return;
		}
		this.seleccionado = null;
		this.resetearPaginacionYBuscar();
		this.alertaBuscador.esVisible = true;
	}

	clonarEntidad(entidad: any): any {
		let e = {};
		for (let prop in entidad) {
			e[prop] = entidad[prop];
		}
		return e;
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		this.subscripcion.unsubscribe();
	}

}
