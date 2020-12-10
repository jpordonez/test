import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';
import { BaseRecurso } from 'app/core/seguridad/recurso/BaseRecurso';
import { AppSettings } from 'app/core/constantes/app-settings';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class ComponenteEducativoRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'ComponenteEducativo/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'ComponenteEducativo/Details'
  })
  get: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'ComponenteEducativo/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'ComponenteEducativo/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'ComponenteEducativo/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'ComponenteEducativo/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

}