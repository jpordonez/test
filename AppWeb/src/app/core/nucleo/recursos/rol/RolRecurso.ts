import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { BaseRecurso } from '../../../seguridad/recurso/BaseRecurso';
import { AppSettings } from '../../../constantes/app-settings';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class RolRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Rol/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    isArray: true,
    path: 'Rol/Details'
  })
  get: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Rol/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Rol/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Rol/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Rol/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

}