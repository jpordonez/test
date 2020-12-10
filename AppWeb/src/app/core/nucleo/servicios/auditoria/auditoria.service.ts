import { Injectable } from '@angular/core';
import { Observable, Subscriber, Subject } from 'rxjs/Rx';
import { AuditoriaRecurso } from '../../recursos/auditoria/AuditoriaRecurso';
import { BaseServicio } from '../base-servicio';

@Injectable()
export class AuditoriaService extends BaseServicio {

  constructor(private auditoriaRecurso: AuditoriaRecurso) {
    super(auditoriaRecurso);
  }

  listar(criteria: any): Promise<any> {
    var resultado = this.auditoriaRecurso.listar(criteria);
    let promesa = new Promise((resolve, reject) => {
      resultado
        .then(
          (res: any) => {
            //Para cargar las fechas correctamente          
            let auditorias = res.Data as any[];
            //Formate esperado para las fechas '2011-04-11T10:20:30Z'
            for (var i = 0; i < auditorias.length; i++) {
              let auditoria = auditorias[i];
              let fecha = auditoria.Fecha;
              if (fecha) {
                auditoria.Fecha = new Date(fecha);
              }
            }
            resolve(res);
          }
        )
        .catch(
          (error: any) => {
            reject(error);
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
    } else if (this.promesaDatosInicio) {
      // Si 'this.observable' ha sido fijado entonces el request esta en progreso
      // devuelvo el 'Observable' para la solicitud en curso.
      return this.promesaDatosInicio;
    } else {
      // creo la peticion, almaceno el 'Observable' para suscriptores posteriores
      var resultado = this.auditoriaRecurso.getDatosInicio();
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
