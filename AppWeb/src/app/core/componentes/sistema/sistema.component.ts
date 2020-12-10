import { Component, OnInit } from '@angular/core';
import { AplicacionServicio } from '../../seguridad/servicio/AplicacionServicio';
import { ServiceLocator } from '../../nucleo/di/ServiceLocator';
import { EncuestaService } from 'app/servicios/encuesta/encuesta.service';


@Component({
	selector: 'app-sistema',
	templateUrl: './sistema.component.html',
	styleUrls: ['./sistema.component.css']
})
export class SistemaComponent implements OnInit {

	public servicios: any[];
	public servicio: any

	constructor(private aplicacionServicio: AplicacionServicio) { }

	ngOnInit() {
		this.servicios = [
			{
				servicio: 'Limpiar Cache Sistema',
				resultado: ''
			},
			{
				servicio: 'Recargar Datos Entidades Entity Framework',
				resultado: ''
			}
		];
	}

	ejecutarAccion(index: number) {
		var servicio = this.servicios[index];
		servicio.resultado = 'Procesando...';
		switch (index) {
			case 0:
				let resultado = this.aplicacionServicio.limpiarCache();
				resultado
					.then(
						(res: any) => {
							this.resetearServiciosCachados();
							servicio.resultado = 'Realizado';
						}
					)
					.catch(
						(error: any) => {
							servicio.resultado = 'Falló';
						});
				break;
			case 1:
				resultado = this.aplicacionServicio.recargarContextoEF();
				resultado
					.then(
						(res: any) => {
							servicio.resultado = 'Realizado';
						}
					)
					.catch(
						(error: any) => {
							servicio.resultado = 'Falló';
						}
					);
				break;
			default:
				// code...
				break;
		}
	}

	resetearServiciosCachados() {
		//Agregar lista de servicios para limpiar cache
		let encuestaService = ServiceLocator.get(EncuestaService);
		encuestaService.limpiarCache();
	}

}
