import { BaseCrud } from "app/core/nucleo/controladores/base-crud";
import { EventoAccion } from "app/core/nucleo/modelo/evento-accion";
import { Peticion } from "app/core/nucleo/modelo/peticion";
import { Accion } from "app/core/nucleo/enums/accion.enum";
import { BaseServicio } from "app/core/nucleo/servicios/base-servicio";
import { Respuesta } from "app/core/nucleo/modelo/respuesta";
import { Subscription } from "rxjs/Subscription";
import { OnDestroy } from "@angular/core";

export abstract class BaseCrudItems extends BaseCrud implements OnDestroy {

	private subscripcionRespuesta: Subscription;

	protected emisor: string;

	constructor(private servicio: BaseServicio,
		private receptorItems: string,
		protected nombreControlItems: string) {
		super(servicio);
		this.emisor = this.constructor.name;
		//Suscribir a notificaciones de modificacion de items
		this.subscripcionRespuesta = servicio.respuesta$.subscribe(
			respuesta => {
				let emisor = respuesta.emisor;
				switch (emisor) {
					case this.constructor.name:
						this.seleccionado.Items = [];
						for (var i = 0; i < respuesta.data.length; i++) {
							this.seleccionado.Items.push(respuesta.data[i]);
						}
						this.entidadForm.controls[this.nombreControlItems].setValue(this.seleccionado.Items);
						break;
					default:
						// code...
						break;
				}
			});
	}

	procesarAccion(peticion: Peticion) {
		super.procesarAccion(peticion);
		this.seleccionado.Items = this.entidadForm.controls[this.nombreControlItems].value;
	}

	nuevo() {
		super.nuevo();
		this.seleccionado = {};
		this.seleccionado.Items = [];
		this.entidadForm.controls[this.nombreControlItems].setValue([]);
	}

	guardar() {
		super.guardar();
		//notificar al componente padre como ha cambiado la lista de objetos
		let respuesta = new Respuesta();
		respuesta.emisor = this.emisorComponentePadre;
		respuesta.data = this.lista;
		this.servicio.notificarRespuesta(respuesta);
	}

	nuevoItem() {
		var evento = new EventoAccion();
		let lista = this.entidadForm.controls[this.nombreControlItems].value;
		if (!lista) {
			console.error('El control ' + this.nombreControlItems + ' es nulo.');
		}
		if (!(lista instanceof Array)) {
			console.error('El control ' + this.nombreControlItems + ' no es una lista.');
		}
		evento.lista = lista as any[];
		evento.accion = Accion.CREAR;
		evento.indice = -1;
		let peticion = new Peticion();
		peticion.data =
			{
				evento: evento
			};
		peticion.emisor = this.emisor;
		peticion.receptor = this.receptorItems;
		this.servicio.notificarPeticion(peticion);
	}

	editarItem(fila: number) {
		var evento = new EventoAccion();
		let lista = this.entidadForm.controls[this.nombreControlItems].value;
		if (!lista) {
			console.error('El control ' + this.nombreControlItems + ' es nulo.');
		}
		if (!(lista instanceof Array)) {
			console.error('El control ' + this.nombreControlItems + ' no es una lista.');
		}
		evento.lista = lista as any[];
		evento.accion = Accion.EDITAR;
		evento.indice = fila;
		let peticion = new Peticion();
		peticion.data =
			{
				evento: evento
			};
		peticion.emisor = this.emisor;
		peticion.receptor = this.receptorItems;
		this.servicio.notificarPeticion(peticion);
	}

	visualizarItem(fila: number) {
		var evento = new EventoAccion();
		let lista = this.entidadForm.controls[this.nombreControlItems].value;
		if (!lista) {
			console.error('El control ' + this.nombreControlItems + ' es nulo.');
		}
		if (!(lista instanceof Array)) {
			console.error('El control ' + this.nombreControlItems + ' no es una lista.');
		}
		evento.lista = lista as any[];
		evento.accion = Accion.VISUALIZAR;
		evento.indice = fila;
		let peticion = new Peticion();
		peticion.data =
			{
				evento: evento
			};
		peticion.emisor = this.emisor;
		peticion.receptor = this.receptorItems;
		this.servicio.notificarPeticion(peticion);
	}

	eliminarItem(fila: number) {
		var evento = new EventoAccion();
		let lista = this.entidadForm.controls[this.nombreControlItems].value;
		if (!lista) {
			console.error('El control ' + this.nombreControlItems + ' es nulo.');
		}
		if (!(lista instanceof Array)) {
			console.error('El control ' + this.nombreControlItems + ' no es una lista.');
		}
		evento.lista = lista as any[];
		evento.accion = Accion.ELIMINAR;
		evento.indice = fila;
		let peticion = new Peticion();
		peticion.data =
			{
				evento: evento
			};
		peticion.emisor = this.emisor;
		peticion.receptor = this.receptorItems;
		this.servicio.notificarPeticion(peticion);
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		super.ngOnDestroy();
		this.subscripcionRespuesta.unsubscribe();
	}

}
