import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';
import { BaseRecurso } from 'app/core/seguridad/recurso/BaseRecurso';
import { AppSettings } from 'app/core/constantes/app-settings';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class BuscadorModuloRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Programa/ModuloIndex'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Programa/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

}