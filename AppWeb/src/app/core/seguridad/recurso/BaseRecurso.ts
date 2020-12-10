import { Request, Response } from '@angular/http';
import { Injector, Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subscriber } from 'rxjs/Subscriber';
import { Resource, ResourceHandler, IResourceAction, IResourceActionInner, IResourceResponse } from '@ngx-resource/core';
import { IRecurso } from 'app/core/nucleo/recursos/IRecurso';
import { UtilityService } from 'app/core/services/utility.service';
import { ServiceLocator } from 'app/core/nucleo/di/ServiceLocator';
import { AuthServiceHelper } from 'app/core/seguridad/util/AuthServiceHelper';
import { LocalStorageHelper } from 'app/core/util/LocalStorageHelper';
import { Mensajes } from 'app/core/constantes/mensajes';

//No inyectar AplicacionServicio presenta problemas con las cookies
export abstract class BaseRecurso extends Resource implements IRecurso {

  private utilityService: UtilityService;
  protected noLanzarExcepcion: boolean = false;

  constructor() {
    super(ServiceLocator.get(ResourceHandler));
    //Inyeccion mediante constructor no funciona
    this.utilityService = ServiceLocator.get(UtilityService);
  }

  $getHeaders(actionOptions?: IResourceAction): any | Promise<any> {
    if (actionOptions.noLanzarExcepcion) {
      this.noLanzarExcepcion = true;
    } else {
      this.noLanzarExcepcion = false;
    }

    let headers = super.$getHeaders();

    // Extending our headers with Authorization
    if (!actionOptions.noAuth) {
      headers = AuthServiceHelper.extendHeaders(headers);
    }

    return headers;
  }

  $setRequestOptionsUrl(options: IResourceActionInner): void {
    super.$setRequestOptionsUrl(options);
    //console.log("req.url:"+req.url);
    //Para visualizar la mascara
    this.utilityService.setEsVisibleMascaraProcesando(true);
  }

  $handleSuccessResponse(options: IResourceActionInner, resp: IResourceResponse): any {
    //Para ocultar la mascara
    this.utilityService.setEsVisibleMascaraProcesando(false);
    var headers = resp.headers;
    var token = headers['token'];
    //Si hay token en respuesta actualizo para que no caduque la sesion
    if (token) {
      AuthServiceHelper.token = token;
    }
    this.noLanzarExcepcion = false;
    return (resp.body ? resp.body : {});
  }

  $handleErrorResponse(options: IResourceActionInner, resp: IResourceResponse): any {
    //Para ocultar la mascara
    this.utilityService.setEsVisibleMascaraProcesando(false);
    //console.log('error:'+JSON.stringify(error));
    let error = (resp.body ? resp.body : {});
    if (resp.status === 401) {
      if (!LocalStorageHelper.get('esLogin')) {
        AuthServiceHelper.token = null;
        //console.log('urlActual:'+this.utilityService.urlActual());
        LocalStorageHelper.set('urlActual', this.utilityService.urlActual());
        this.utilityService.resetearSesion();
        this.utilityService.navegarAIngreso();
      } else {//Si es login presento el mensaje de rechazo de ingreso al sistema        
        if (error.presentar) {
          this.utilityService.mostrarMensaje(error.mensaje);
        } else {
          AuthServiceHelper.token = null;
          LocalStorageHelper.set('urlActual', this.utilityService.urlActual());
          this.utilityService.resetearSesion();
          this.utilityService.navegarAIngreso();
        }
      }
    } else {
      switch (resp.status) {
        case 504:
          //El Api Rest no esta disponible
          window.location.href = '/assets/pages/landing.html?mensaje=NoApi';
          //window.location.href = '/sitio/index.html?mensaje=NoApi';          
          break;
        case 403:
          this.utilityService.mostrarMensaje(error.mensaje, 'warn', Mensajes.AccionNoPermitida);
          break;
        case 409:
          this.utilityService.mostrarMensaje(error.mensaje);
          break;
        case 412://Se necesita seleccionar un rol
          var roles = LocalStorageHelper.get('roles');
          if (roles) {
            LocalStorageHelper.set('urlActual', '/inicio');
            this.utilityService.navegarASeleccionarRol();
          } else {
            this.utilityService.navegarAIngreso();
          }
          break;
        default:
          this.utilityService.mostrarMensaje(Mensajes.ErrorGenerico);
          break;
      }
    }
    if (!this.noLanzarExcepcion) {
      this.noLanzarExcepcion = false;
      throw error;
    }
  }

}