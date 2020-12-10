import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { ViewChild } from '@angular/core';
import { LazyLoadEvent, DataTable, ConfirmationService } from 'primeng/primeng';
import { Alerta } from 'app/core/nucleo/modelo/Alerta';
import { Accion } from 'app/core/nucleo/enums/accion.enum';
import { UtilityService } from 'app/core/services/utility.service';
import { ServiceLocator } from 'app/core/nucleo/di/ServiceLocator';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { AppSettings } from 'app/core/constantes/app-settings';
import { Mensajes } from 'app/core/constantes/mensajes';
import { FormularioUtil } from 'app/core/nucleo/formularios/formulario-util';
import { Util } from 'app/core/util/util';


//Toma los elementos en el cliente (lista) para realizar todas las operaciones
//Trabaja con API Rest (Server) para crear, editar y eliminar
//Es importante pasarle el servicio que interactua con el API Rest
export abstract class BaseCrudPaginaBuscador {

	public criteriaForm: FormGroup;
	public entidadForm: FormGroup;
	public alertaEntidad: Alerta;
	public lista: any[];
	public seleccionado: any;
	protected indiceSeleccionado: number;
	//Representa una accion de CRUD (Crear, Visualizar, Editar y  Eliminar)
	public accion: Accion;
	//Para obtener el objeto desde un API Rest para realizar (editar, eliminar, visualizar)
	protected obtenerObjetoDesdeCrudService: boolean = false;
	protected postObtenerObjeto: (entidad: any, entidadDeLista: any) => void = null;
	//Para llamar una funcion explicita definida por el usuario despues de guardar los datos (nuevo, editar, eliminar)
	protected postGuardarObjeto: (respuesta: any) => void = null;
	//Para llamar una funcion explicita definida por el usuario despues de buscar los datos (buscar pagina)
	protected postBuscar: (respuesta: any) => void = null;
	public tamanioPagina: number;
	public totalRegistros: number;
	public tablaSinDatos: string;
	@ViewChild('dtbuscador') protected dtbuscador: DataTable;
	public es: any;
	protected esGuardar: boolean = false;
	protected esDatosInicioCargados: boolean = false;
	protected utilService: UtilityService = ServiceLocator.get(UtilityService);

	constructor(private baseServicio: BaseServicio) {
		this.seleccionado = {};
		this.lista = [];
		this.tamanioPagina = AppSettings.TAMANIO_PAGINA;
		this.tablaSinDatos = Mensajes.TABLA_SIN_DATOS;
		this.es = AppSettings.METADATA_CALENDARIO_ES;
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
		if (!this.criteriaForm) {
			console.error('Se debe crear una instancia de this.criteriaForm.');
			return;
		}
		if (this.criteriaForm.invalid) {
			this.utilService.mostrarMensaje('Se tiene que ingresar todos los campos obligatorios.');
			return;
		}
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
					this.seleccionado = {};
					if (this.esGuardar) {
						this.utilService.mostrarMensaje(Mensajes.DatosGuardados);
					}
					if (this.postBuscar) {
						this.postBuscar(res);
					}
					this.esGuardar = false;
				}
			);
	}

	buscarPaginado(event: LazyLoadEvent) {
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
				let respuesta = this.baseServicio.crear(FormularioUtil.getEntidadCompleta(this.entidadForm));
				respuesta
					.then(
						(res: any) => {
							if (res.fallo) {
								if (this.postGuardarObjeto) {
									this.postGuardarObjeto(res);
								}
							} else {
								this.esGuardar = true;
								this.resetearPaginacionYBuscar();
								//this.lista.push(res);
								//this.seleccionado = res;
								this.seleccionado = {};
								this.alertaEntidad.esVisible = false;
								if (this.postGuardarObjeto) {
									this.postGuardarObjeto(res);
								}
							}
						}
					)
					.catch(
						(error: any) => {
							//Manejo de errores
						}
					);
				break;
			case Accion.EDITAR:
				if (this.indiceSeleccionado == -1) {
					return;
				}
				respuesta = this.baseServicio.editar(FormularioUtil.getEntidadCompleta(this.entidadForm));
				respuesta
					.then(
						(res: any) => {
							if (res.fallo) {
								if (this.postGuardarObjeto) {
									this.postGuardarObjeto(res);
								}
							} else {
								this.esGuardar = true;
								this.resetearPaginacionYBuscar();
								//this.seleccionado = res;
								this.seleccionado = {};
								//this.lista[this.indiceSeleccionado]=res;
								this.alertaEntidad.esVisible = false;
								if (this.postGuardarObjeto) {
									this.postGuardarObjeto(res);
								}
							}
						}
					)
					.catch(
						(error: any) => {
							//Manejo de errores
						}
					);
				break;
			case Accion.ELIMINAR:
				if (this.indiceSeleccionado == -1) {
					return;
				}

				let confirmationService = ServiceLocator.get(ConfirmationService);

				confirmationService.confirm({
					message: '¿Está seguro de eliminar?',
					accept: () => {
						respuesta = this.baseServicio.eliminar({ Id: this.seleccionado.Id });
						respuesta
							.then(
								(res: any) => {
									if (res.fallo) {
										if (this.postGuardarObjeto) {
											this.postGuardarObjeto(res);
										}
									} else {
										this.esGuardar = true;
										this.resetearPaginacionYBuscar();
										this.seleccionado = {};
										//this.lista.splice(this.indiceSeleccionado,1);
										this.alertaEntidad.esVisible = false;
										if (this.postGuardarObjeto) {
											this.postGuardarObjeto(res);
										}
									}
								}
							)
							.catch(
								(error: any) => {
									//Manejo de errores
								}
							);
					},
					reject: () => {
						this.seleccionado = {};
						this.alertaEntidad.esVisible = false;
					}
				});

				break;
			case Accion.VISUALIZAR:
				this.alertaEntidad.esVisible = false;
				break;
			default:
				break;
		}
	}

	visualizar(fila: number) {
		if (this.dtbuscador.paginator) {
			fila = fila % this.tamanioPagina;
		}
		this.indiceSeleccionado = fila;
		this.accion = Accion.VISUALIZAR;
		var obj = this.lista[fila];
		if (this.obtenerObjetoDesdeCrudService) {
			let respuesta = this.baseServicio.get({ Id: obj.Id });
			respuesta
				.then(
					(res: any) => {
						this.seleccionado = this.clonarEntidad(res);
						this.entidadForm.reset(this.seleccionado);
						if (this.postObtenerObjeto) {
							this.postObtenerObjeto(this.seleccionado, obj);
						}
						this.alertaEntidad.esBloquear = true;
						this.alertaEntidad.esVisible = true;
					}
				)
				.catch(
					(error: any) => {
						//Manejo de errores
					}
				);
		} else {
			this.seleccionado = this.clonarEntidad(obj);
			this.entidadForm.reset(this.seleccionado);
			if (this.postObtenerObjeto) {
				this.postObtenerObjeto({}, this.seleccionado);
			}
			this.alertaEntidad.esBloquear = true;
			this.alertaEntidad.esVisible = true;
		}
	}

	editar(fila: number) {
		if (this.dtbuscador.paginator) {
			fila = fila % this.tamanioPagina;
		}
		this.indiceSeleccionado = fila;
		this.accion = Accion.EDITAR;
		var obj = this.lista[fila];
		if (this.obtenerObjetoDesdeCrudService) {
			let respuesta = this.baseServicio.get({ Id: obj.Id });
			respuesta
				.then(
					(res: any) => {
						this.seleccionado = this.clonarEntidad(res);
						this.entidadForm.reset(this.seleccionado);
						if (this.postObtenerObjeto) {
							this.postObtenerObjeto(this.seleccionado, obj);
						}
						this.alertaEntidad.esBloquear = false;
						this.alertaEntidad.esVisible = true;
					}
				)
				.catch(
					(error: any) => {
						//Manejo de errores
					}
				);
		} else {
			this.seleccionado = this.clonarEntidad(obj);
			this.entidadForm.reset(this.seleccionado);
			if (this.postObtenerObjeto) {
				this.postObtenerObjeto({}, this.seleccionado);
			}
			this.alertaEntidad.esBloquear = false;
			this.alertaEntidad.esVisible = true;
		}
	}

	eliminar(fila: number) {
		if (this.dtbuscador.paginator) {
			fila = fila % this.tamanioPagina;
		}
		this.indiceSeleccionado = fila;
		this.accion = Accion.ELIMINAR;
		var obj = this.lista[fila];
		if (this.obtenerObjetoDesdeCrudService) {
			let respuesta = this.baseServicio.get({ Id: obj.Id });
			respuesta
				.then(
					(res: any) => {
						this.seleccionado = this.clonarEntidad(res);
						this.entidadForm.reset(this.seleccionado);
						if (this.postObtenerObjeto) {
							this.postObtenerObjeto(this.seleccionado, obj);
						}
						this.alertaEntidad.esBloquear = true;
						this.alertaEntidad.esVisible = true;
					}
				)
				.catch(
					(error: any) => {
						//Manejo de errores
					}
				);
		} else {
			this.seleccionado = this.clonarEntidad(obj);
			this.entidadForm.reset(this.seleccionado);
			if (this.postObtenerObjeto) {
				this.postObtenerObjeto({}, this.seleccionado);
			}
			this.alertaEntidad.esBloquear = true;
			this.alertaEntidad.esVisible = true;
		}
	}

	clonarEntidad(entidad: any): any {
		let e = {};
		for (let prop in entidad) {
			//Propiedades que empiecen con $
			if (prop.indexOf('$') == 0) {
				//Evito clonar las propiedades que extienden los objetos resultado
				/*
				ResourceResult<R>
				Every request method is returning given data type which is extended by ResourceResult

				export type ResourceResult<R extends {}> = R & {
				  $resolved?: boolean; // true if request has been executed
				  $observable?: Observable<R>; // Observable for the request
				  $abortRequest?: () => void; // method to abort pending request
				}
				*/
				continue;
			}
			if (entidad[prop] instanceof Array) {
				//Para clonar un array
				e[prop] = entidad[prop].slice(0);
			} else {
				if (entidad[prop] instanceof Date)
					e[prop] = new Date(entidad[prop]);
				else {
					if (entidad[prop] instanceof Object) {
						//Para clonar un objeto complejo
						e[prop] = this.clonarEntidad(entidad[prop]);
					} else {
						//Para clonar un objeto simple
						e[prop] = entidad[prop];
					}
				}
			}
		}
		return e;
	}

}
