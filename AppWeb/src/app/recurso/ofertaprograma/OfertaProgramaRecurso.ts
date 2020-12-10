import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';
import { BaseRecurso } from 'app/core/seguridad/recurso/BaseRecurso';
import { AppSettings } from 'app/core/constantes/app-settings';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class OfertaProgramaRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/Index'
  })
  listar: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/Details'
  })
  get: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/Create'
  })
  crear: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/Edit'
  })
  editar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/Delete'
  })
  eliminar: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'OfertaPrograma/Get'
  })
  getDatosInicio: IResourceMethod<any, any[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/Tickets'
  })
  getTickets: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/GuardarYEnviarTickets'
  })
  guardarYEnviarTickets: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'OfertaPrograma/ResolverEncuesta'
  })
  resolverEncuesta: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'OfertaPrograma/GuardarRespuestas'
  })
  guardarRespuestas: IResourceMethod<any, any>;

}