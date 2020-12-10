import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { Rol } from '../modelo/Rol';
import { BaseRecurso } from './BaseRecurso';
import { MenuItem } from 'primeng/primeng';
import { ResourceParams, ResourceAction, IResourceMethod, ResourceRequestMethod } from '@ngx-resource/core';
import { AppSettings } from 'app/core/constantes/app-settings';
import { Excepcion } from 'app/core/nucleo/modelo/Excepcion';

@Injectable()
@ResourceParams({
  url: AppSettings.API_ENDPOINT
})
export class AplicacionRecurso extends BaseRecurso {

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    isArray: true,
    path: 'excepcionesseveras'
  })
  query: IResourceMethod<any, Excepcion[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    isArray: true,
    noLanzarExcepcion: true,
    path: 'Inicio/Menu'
  })
  getMenu: IResourceMethod<{ valor: string }, MenuItem[]>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Cuenta/Ingresar'
  })
  ingresar: IResourceMethod<{ Usuario: string, Password: string }, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Cuenta/SeleccionarRol'
  })
  setRol: IResourceMethod<{ RolCodigo: string, IPClient: string, Token: string }, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Cuenta/Salir'
  })
  salir: IResourceMethod<{ valor: string }, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Cuenta/RecuperarCredencial'
  })
  recuperarCredencial: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Post,
    path: 'Cuenta/CambiarClave'
  })
  cambiarClave: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Sistema/LimpiarCache'
  })
  limpiarCache: IResourceMethod<any, any>;

  @ResourceAction({
    method: ResourceRequestMethod.Get,
    path: 'Sistema/RecargarContextoEF'
  })
  recargarContextoEF: IResourceMethod<any, any>;

}