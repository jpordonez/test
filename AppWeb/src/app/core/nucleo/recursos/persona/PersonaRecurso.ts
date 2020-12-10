import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';
import { BaseRecurso } from 'app/core/seguridad/recurso/BaseRecurso';
import { AppSettings } from 'app/core/constantes/app-settings';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class PersonaRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/Details'
  })
  get: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Persona/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/ValidarIdentificacionYExistencia'
  })
  validarIdentificacionYExistencia: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Persona/ValidarExistenciaCorreo'
  })
  validarExistenciaCorreo: IResourceMethod<any, any>;

}