import { Injectable } from '@angular/core';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { EncuestaRecurso } from 'app/recurso/encuesta/EncuestaRecurso';
import { Observable } from 'rxjs/Observable';
import { Subscriber } from 'rxjs/Subscriber';

@Injectable()
export class EncuestaService extends BaseServicio {

    constructor(private encuestaRecurso: EncuestaRecurso) {
        super(encuestaRecurso);
    }

    listar(criteria: any): Promise<any> {
        let resultado = this.encuestaRecurso.listar(criteria);
        let promesa = new Promise((resolve, reject) => {
            resultado
                .then(
                    (res: any) => {
                        //Para cargar las fechas correctamente          
                        let encuestas = res.Data as any[];
                        //Formate esperado para las fechas '2011-04-11T10:20:30Z'
                        for (var i = 0; i < encuestas.length; i++) {
                            let encuesta = encuestas[i];
                            let fechaCreacion = encuesta.FechaCreacion;
                            if (fechaCreacion) {
                                encuesta.FechaCreacion = new Date(fechaCreacion);
                            }
                        }
                        resolve(res);
                    }
                )
                .catch((res: any) => {
                    reject(res);
                });
        });

        return promesa;
    }

    get(entidad: any): Promise<any> {
        var resultado = this.encuestaRecurso.get(entidad);
        let promesa = new Promise((resolve, reject) => {
            resultado
                .then(
                    (res: any) => {
                        let encuesta = res;
                        let grupos = encuesta.Grupos as any[];
                        for (var i = 0; i < grupos.length; i++) {
                            let grupo = grupos[i];
                            let fechaCreacion = grupo.FechaCreacion;
                            if (fechaCreacion) {
                                grupo.FechaCreacion = new Date(fechaCreacion);
                            }
                            let preguntas = grupo.Preguntas as any[];
                            for (var j = 0; j < preguntas.length; j++) {
                                let pregunta = preguntas[j];
                                let fechaCreacion = pregunta.FechaCreacion;
                                if (fechaCreacion) {
                                    pregunta.FechaCreacion = new Date(fechaCreacion);
                                }
                                let opciones = pregunta.Opciones as any[];
                                for (var k = 0; k < opciones.length; k++) {
                                    let opcion = opciones[k];
                                    let fechaCreacion = opcion.FechaCreacion;
                                    if (fechaCreacion) {
                                        opcion.FechaCreacion = new Date(fechaCreacion);
                                    }
                                }
                            }
                        }
                        resolve(encuesta);
                    }
                )
                .catch((res: any) => {
                    reject(res);
                });
        });
        return promesa;
    }

    //Datos Cachados
    getDatosInicio(): Promise<any> {
        if (this.datosInicio) {
            // if 'this.datosInicio' esta habilitado retorno este como un 'Observable'.
            this.promesaDatosInicio = new Promise((resolve, reject) => {
                resolve(this.datosInicio);
            });
            return this.promesaDatosInicio;
        } else if (this.promesaDatosInicio) {
            // Si 'this.observable' ha sido fijado entonces el request esta en progreso
            // devuelvo el 'Observable' para la solicitud en curso.
            return this.promesaDatosInicio;
        } else {
            // creo la peticion, almaceno el 'Observable' para suscriptores posteriores
            var resultado = this.encuestaRecurso.getDatosInicio();
            this.promesaDatosInicio = new Promise((resolve, reject) => {
                resultado
                    .then(
                        (res: any) => {
                            //Cuando los datos en caché están disponibles, no necesitamos la referencia 'Observable'
                            this.promesaDatosInicio = null;
                            this.datosInicio = res;
                            resolve(res);
                        }
                    )
                    .catch(
                        (error: any) => {
                            //Cuando se lanza un error es necesario resetear el observable y los datos
                            this.promesaDatosInicio = null;
                            this.datosInicio = null;
                            reject(error);
                        });

            });
            return this.promesaDatosInicio;
        }
    }

}
