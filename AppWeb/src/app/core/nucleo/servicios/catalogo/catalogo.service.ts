import { Injectable } from '@angular/core';
import { CatalogoRecurso } from '../../recursos/catalogo/catalogo-recurso';
import { Accion } from '../../enums/accion.enum';
import { EventoAccion } from '../../modelo/evento-accion';
import { BaseServicio } from '../../../nucleo/servicios/base-servicio';
import { Observable, Subscriber, Subject } from 'rxjs/Rx';

@Injectable()
export class CatalogoService extends BaseServicio {

  constructor(private catalogoRecurso: CatalogoRecurso) {
    super(catalogoRecurso);
  }

  listar(criteria: any): Promise<any> {
    var resultado = this.catalogoRecurso.listar(criteria);
    let promesa = new Promise((resolve, reject) => {
      resultado
        .then(
          (res: any) => {
            //Para cargar las fechas correctamente          
            let catalogos = res.Data as any[];
            //Formate esperado para las fechas '2011-04-11T10:20:30Z'
            for (var i = 0; i < catalogos.length; i++) {
              let catalogo = catalogos[i];
              let fechaCreacion = catalogo.FechaCreacion;
              if (fechaCreacion) {
                catalogo.FechaCreacion = new Date(fechaCreacion);
              }
              for (var j = 0; j < catalogo.Items.length; j++) {
                let item = catalogo.Items[j];
                let fechaCreacion = item.FechaCreacion;
                if (fechaCreacion) {
                  item.FechaCreacion = new Date(fechaCreacion);
                }
              }
            }
            resolve(res);
          }
        )
        .catch(
          (error: any) => {
            reject(error);
          }
        );
    });
    return promesa;
  }

}
