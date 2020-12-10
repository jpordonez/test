import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';
import { BaseRecurso } from 'app/core/seguridad/recurso/BaseRecurso';
import { AppSettings } from 'app/core/constantes/app-settings';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class ResultadoRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Resultado/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Resultado/Details'
  })
  get: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Resultado/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Resultado/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Resultado/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Resultado/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

}