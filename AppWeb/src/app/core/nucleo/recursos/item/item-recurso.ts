import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { BaseRecurso } from '../../../seguridad/recurso/BaseRecurso';
import { AppSettings } from '../../../constantes/app-settings';
import { ResourceParams, ResourceAction, ResourceRequestMethod, IResourceMethod } from '@ngx-resource/core';

@Injectable()
@ResourceParams({
	url: AppSettings.API_ENDPOINT
})
export class ItemRecurso extends BaseRecurso {

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		isArray: true,
		path: 'Catalogo/IndexItem'
	})
	listar: IResourceMethod<any, any[]>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		isArray: true,
		path: 'Catalogo/DetailsItem'
	})
	get: IResourceMethod<any, any[]>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/CreateItem'
	})
	crear: IResourceMethod<any, any>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/EditItem'
	})
	editar: IResourceMethod<any, any>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/DeleteItem'
	})
	eliminar: IResourceMethod<any, any>;

}