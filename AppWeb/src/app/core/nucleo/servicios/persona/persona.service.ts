import { Injectable } from '@angular/core';
import { PersonaRecurso } from '../../recursos/persona/PersonaRecurso';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';

@Injectable()
export class PersonaService extends BaseServicio {

  constructor(private personaRecurso: PersonaRecurso) {
    super(personaRecurso);
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
      var resultado = this.personaRecurso.getDatosInicio();
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
          .then((error: any) => {
            //Cuando se lanza un error es necesario resetear el observable y los datos
            this.promesaDatosInicio = null;
            this.datosInicio = null;
            reject(error);
          });

      });
      return this.promesaDatosInicio;
    }
  }

  validarIdentificacionYExistencia(criteria: any) {
    return this.personaRecurso.validarIdentificacionYExistencia(criteria);
  }

  validarExistenciaCorreo(criteria: any) {
    return this.personaRecurso.validarExistenciaCorreo(criteria);
  }

}
