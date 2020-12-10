import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { BaseRecurso } from '../../../seguridad/recurso/BaseRecurso';
import { AppSettings } from '../../../constantes/app-settings';
import { ResourceParams, ResourceAction, IResourceMethod, ResourceRequestMethod } from '@ngx-resource/core';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class MenuRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Menu/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    isArray: true,
    path: 'Menu/Details'
  })
  get: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Menu/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Menu/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Menu/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Menu/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

}