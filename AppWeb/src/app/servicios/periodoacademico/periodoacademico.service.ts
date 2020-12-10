import { Injectable } from '@angular/core';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { PeriodoAcademicoRecurso } from 'app/recurso/periodoacademico/PeriodoAcademicoRecurso';

@Injectable()
export class PeriodoAcademicoService extends BaseServicio {

  constructor(private periodoAcademicoRecurso: PeriodoAcademicoRecurso) {
    super(periodoAcademicoRecurso);
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
      var resultado = this.periodoAcademicoRecurso.getDatosInicio();
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

  listar(criteria: any): Promise<any> {
    let resultado = this.periodoAcademicoRecurso.listar(criteria);
    let promesa = new Promise((resolve, reject) => {
      resultado
        .then(
          (res: any) => {
            //Para cargar las fechas correctamente          
            let periodoAcademicos = res.Data as any[];
            //Formate esperado para las fechas '2011-04-11T10:20:30Z'
            for (var i = 0; i < periodoAcademicos.length; i++) {
              let periodoAcademico = periodoAcademicos[i];
              let fechaDesde = periodoAcademico.FechaDesde;
              if (fechaDesde) {
                periodoAcademico.FechaDesde = new Date(fechaDesde);
              }
              let fechaHasta = periodoAcademico.FechaHasta;
              if (fechaHasta) {
                periodoAcademico.FechaHasta = new Date(fechaHasta);
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

}
