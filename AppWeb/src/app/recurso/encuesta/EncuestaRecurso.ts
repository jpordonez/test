import { Injectable } from "@angular/core";
import { AppSettings } from "app/core/constantes/app-settings";
import { BaseRecurso } from "app/core/seguridad/recurso/BaseRecurso";
import { RequestMethod } from "@angular/http";
import { ResourceParams, ResourceAction, IResourceMethod, ResourceRequestMethod } from "@ngx-resource/core";

@Injectable()
@ResourceParams({
    url: AppSettings.API_ENDPOINT
})
export class EncuestaRecurso extends BaseRecurso {

    @ResourceAction({
        method: ResourceRequestMethod.Post,
        path: 'Encuesta/Index'
    })
    listar: IResourceMethod<any, any>;

    @ResourceAction({
        method: ResourceRequestMethod.Post,
        path: 'Encuesta/Details'
    })
    get: IResourceMethod<any, any>;

    @ResourceAction({
        method: ResourceRequestMethod.Post,
        path: 'Encuesta/Create'
    })
    crear: IResourceMethod<any, any>;

    @ResourceAction({
        method: ResourceRequestMethod.Post,
        path: 'Encuesta/Edit'
    })
    editar: IResourceMethod<any, any>;

    @ResourceAction({
        method: ResourceRequestMethod.Post,
        path: 'Encuesta/Delete'
    })
    eliminar: IResourceMethod<any, any>;

    @ResourceAction({
        method: ResourceRequestMethod.Get,
        path: 'Encuesta/Get'
    })
    getDatosInicio: IResourceMethod<any, any>;

}
