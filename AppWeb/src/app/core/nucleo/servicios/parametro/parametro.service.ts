import { Injectable } from '@angular/core';
import { BaseServicio } from '../base-servicio';
import { ParametroRecurso } from '../../recursos/parametro/ParametroRecurso';
import { Observable, Subscriber, Subject } from 'rxjs/Rx';

@Injectable()
export class ParametroService extends BaseServicio {

  constructor(private parametroRecurso: ParametroRecurso) {
    super(parametroRecurso);
  }

  //Datos Cachados
  getDatosInicio() {
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
      var resultado = this.parametroRecurso.getDatosInicio();
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
