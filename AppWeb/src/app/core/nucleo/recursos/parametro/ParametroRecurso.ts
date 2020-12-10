import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { BaseRecurso } from '../../../seguridad/recurso/BaseRecurso';
import { AppSettings } from '../../../constantes/app-settings';
import { ResourceParams, ResourceAction, IResourceMethod, ResourceRequestMethod } from '@ngx-resource/core';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class ParametroRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Parametro/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    isArray: true,
    path: 'Parametro/Details'
  })
  get: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Parametro/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Parametro/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Parametro/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Parametro/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

}