import { Injectable } from '@angular/core';
import { BaseServicio } from 'app/core/nucleo/servicios/base-servicio';
import { UniversidadUsuarioRecurso } from 'app/recurso/universidadusuario/UniversidadUsuarioRecurso';

@Injectable()
export class UniversidadUsuarioService extends BaseServicio {

  constructor(private universidadUsuarioRecurso: UniversidadUsuarioRecurso) {
    super(universidadUsuarioRecurso);
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
      var resultado = this.universidadUsuarioRecurso.getDatosInicio();
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
    let resultado = this.universidadUsuarioRecurso.listar(criteria);
    let promesa = new Promise((resolve, reject) => {
      resultado
        .then(
          (res: any) => {
            let universidadUsuarios = res.Data as any[];
            for (var i = 0; i < universidadUsuarios.length; i++) {
              let universidadUsuario = universidadUsuarios[i];
              universidadUsuario.Apellidos = universidadUsuario.PrimerApellido + ' ' + universidadUsuario.SegundoApellido;
              universidadUsuario.Nombres = universidadUsuario.PrimerNombre + ' ' + universidadUsuario.SegundoNombre;
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
