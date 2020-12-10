import { Injectable } from '@angular/core';
import { Observable, Subscriber, Subject } from 'rxjs/Rx';
import { RolRecurso } from '../../recursos/rol/RolRecurso';
import { BaseServicio } from '../base-servicio';

@Injectable()
export class RolService extends BaseServicio {

  constructor(private rolRecurso: RolRecurso) {
    super(rolRecurso);
  }

  //Datos Cachados
  /*getDatosInicio() {
    if(this.datosInicio) {
      // if 'this.datosInicio' esta habilitado retorno este como un 'Observable'.
      return {$observable:Observable.of(this.datosInicio)}; 
    } else if(this.observable) {
      // Si 'this.observable' ha sido fijado entonces el request esta en progreso
      // devuelvo el 'Observable' para la solicitud en curso.
      return {$observable:this.observable};
    } else {
      // creo la peticion, almaceno el 'Observable' para suscriptores posteriores
      var resultado = this.rolRecurso.getDatosInicio();
      this.observable = Observable.create((subscriber: Subscriber<any>) => { 
        resultado.$observable.subscribe(
          (res: any) => {
            //Cuando los datos en caché están disponibles, no necesitamos la referencia 'Observable'
            this.observable = null;
            this.datosInicio = res;
            subscriber.next(res);          
          },
          (error: any) => {
            //Cuando se lanza un error es necesario resetear el observable y los datos
            this.observable = null;
            this.datosInicio = null;         
          },
          () => subscriber.complete()
        );
   
      });
      return {$observable:this.observable};
    }             
  }*/

}
