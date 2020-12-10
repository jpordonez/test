import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { UtilityService } from "app/core/services/utility.service";
import { ServiceLocator } from "app/core/nucleo/di/ServiceLocator";
import { Mensajes } from "app/core/constantes/mensajes";
import { AppSettings } from "app/core/constantes/app-settings";
import { OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { Respuesta } from 'app/core/nucleo/modelo/respuesta';
import { Alerta } from 'app/core/nucleo/modelo/Alerta';
import { Accion } from 'app/core/nucleo/enums/accion.enum';
import { Peticion } from 'app/core/nucleo/modelo/peticion';
import { EventoAccion } from 'app/core/nucleo/modelo/evento-accion';

//Toma los elementos en el cliente (lista) para realizar todas las operaciones
//Trabaja sin API Rest (Server) la modificacion de los elementos se los hace en el cliente
export abstract class BaseCrud implements OnDestroy {

	private subscripcionPeticion: Subscription;
	public criteriaForm: FormGroup;
	public entidadForm: FormGroup;
	public alertaEntidad: Alerta;
	public lista: any[];
	public seleccionado: any;
	protected indiceSeleccionado: number;
	public accion: Accion;
	protected emisorComponentePadre: string;
	protected utilService: UtilityService = ServiceLocator.get(UtilityService);
	public tablaSinDatos: string;
	public es: any;

	constructor(private componentePadreServicio: BaseServicio) {
		this.seleccionado = {};
		this.lista = [];
		this.tablaSinDatos = Mensajes.TABLA_SIN_DATOS;
		this.es = AppSettings.METADATA_CALENDARIO_ES;
		//Suscribir a notificaciones de componente padre
		this.subscripcionPeticion = componentePadreServicio.peticion$.subscribe(
			peticion => {
				if (peticion.receptor === this.constructor.name) {
					this.procesarAccion(peticion);
				}
			});
	}

	nuevo() {
		this.accion = Accion.CREAR;
		this.seleccionado = {};
		this.entidadForm.reset({ Id: 0 });
		this.alertaEntidad.esBloquear = false;
		this.alertaEntidad.esVisible = true;
	}

	guardar() {
		switch (this.accion) {
			case Accion.CREAR:
				this.seleccionado = this.entidadForm.value;
				this.lista = this.lista.agregar(this.seleccionado);
				this.alertaEntidad.esVisible = false;
				break;
			case Accion.EDITAR:
				if (this.indiceSeleccionado == -1) {
					return;
				}
				this.seleccionado = this.entidadForm.value;
				this.lista[this.indiceSeleccionado] = this.seleccionado;
				this.alertaEntidad.esVisible = false;
				break;
			case Accion.ELIMINAR:
				if (this.indiceSeleccionado == -1) {
					return;
				}
				this.seleccionado = {};
				this.lista = this.lista.eliminar(this.indiceSeleccionado);
				this.alertaEntidad.esVisible = false;
				break;
			case Accion.VISUALIZAR:
				this.alertaEntidad.esVisible = false;
				break;
			default:
				break;
		}
		//notificar al componente padre como ha cambiado la lista de objetos
		let respuesta = new Respuesta();
		respuesta.emisor = this.emisorComponentePadre;
		respuesta.data = this.lista;
		this.componentePadreServicio.notificarRespuesta(respuesta);
	}

	visualizar(fila: number) {
		this.indiceSeleccionado = fila;
		this.accion = Accion.VISUALIZAR;
		this.seleccionado = this.clonarEntidad(this.lista[fila]);
		this.entidadForm.reset(this.seleccionado);
		this.alertaEntidad.esBloquear = true;
		this.alertaEntidad.esVisible = true;
	}

	editar(fila: number) {
		this.indiceSeleccionado = fila;
		this.accion = Accion.EDITAR;
		this.seleccionado = this.clonarEntidad(this.lista[fila]);
		this.entidadForm.reset(this.seleccionado);
		this.alertaEntidad.esBloquear = false;
		this.alertaEntidad.esVisible = true;
	}

	eliminar(fila: number) {
		this.indiceSeleccionado = fila;
		this.accion = Accion.ELIMINAR;
		this.seleccionado = this.clonarEntidad(this.lista[fila]);
		this.entidadForm.reset(this.seleccionado);
		this.alertaEntidad.esBloquear = true;
		this.alertaEntidad.esVisible = true;
	}

	clonarEntidad(entidad: any): any {
		let e = {};
		for (let prop in entidad) {
			e[prop] = entidad[prop];
		}
		return e;
	}

	procesarAccion(peticion: Peticion) {
		let evento: EventoAccion = peticion.data.evento;
		if (!evento.lista) {
			console.error("evento.lista no puede ser nulo o indefinido.");
			return;
		}
		//Se clona las lista para deshacer los cambios si se cierra sin guadar la entidad
		this.lista = evento.lista.slice(0);
		var accion = evento.accion;
		this.emisorComponentePadre = peticion.emisor;
		switch (accion) {
			case Accion.CREAR:
				this.nuevo();
				break;
			case Accion.EDITAR:
				this.editar(evento.indice);
				break;
			case Accion.ELIMINAR:
				this.eliminar(evento.indice);
				break;
			case Accion.VISUALIZAR:
				this.visualizar(evento.indice);
				break;
			default:
				break;
		}
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		this.subscripcionPeticion.unsubscribe();
	}

}
