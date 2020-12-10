import { Injectable } from '@angular/core';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { ResultadoRecurso } from 'app/recurso/resultado/ResultadoRecurso';

@Injectable()
export class ResultadoService extends BaseServicio {

  constructor(private resultadoRecurso: ResultadoRecurso) {
    super(resultadoRecurso);
  }

  //Datos Cachados
  getDatosInicio(): Promise<any> {
    if (this.datosInicio) {
      // if 'this.datosInicio' esta habilitado retorno este como una 'Promise'.
      this.promesaDatosInicio = new Promise((resolve, reject) => {
        resolve(this.datosInicio);
      });
    } else if (this.promesaDatosInicio) {
      // Si 'this.promesaDatosInicio' ha sido fijado entonces el request esta en progreso
      // devuelvo el 'Promise' para la solicitud en curso.
      return this.promesaDatosInicio;
    } else {
      // creo la peticion, almaceno el 'Promise' para suscriptores posteriores
      var resultado = this.resultadoRecurso.getDatosInicio();
      this.promesaDatosInicio = new Promise((resolve, reject) => {
        resultado
          .then(
            (res: any) => {
              //Cuando los datos en caché están disponibles, no necesitamos la referencia 'promesaDatosInicio'
              this.promesaDatosInicio = null;
              this.datosInicio = res;
              resolve(res);
            }
          )
          .then((error: any) => {
            //Cuando se lanza un error es necesario resetear el promesaDatosInicio y los datos
            this.promesaDatosInicio = null;
            this.datosInicio = null;
            reject(error);
          });

      });
      return this.promesaDatosInicio;
    }
  }

  /*listar(criteria: any): Promise<any> {
    var resultado = this.resultadoRecurso.listar(criteria);
    let promesa = new Promise((resolve, reject) => {
      resultado
        .then(
          (res: any) => {
            //Para cargar las fechas correctamente          
            let Resultados = res.Data as any[];
            //Formate esperado para las fechas '2011-04-11T10:20:30Z'
            for (var i = 0; i < Resultados.length; i++) {
              let Resultado = Resultados[i];
              let inicio = Resultado.Inicio;
              if (inicio) {
                Resultado.Inicio = new Date(inicio);
              }
              let fin = Resultado.Fin;
              if (fin) {
                Resultado.Fin = new Date(fin);
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
  }*/

}
