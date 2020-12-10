import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { BaseRecurso } from '../../../seguridad/recurso/BaseRecurso';
import { AppSettings } from '../../../constantes/app-settings';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class UsuarioRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Usuario/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    isArray: true,
    path: 'Usuario/Details'
  })
  get: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Usuario/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Usuario/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Usuario/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Usuario/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Usuario/ValidarExistencia'
  })
  validarExistencia: IResourceMethod<any, any>;

}