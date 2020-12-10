import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';
import { BaseRecurso } from '../../../seguridad/recurso/BaseRecurso';
import { AppSettings } from '../../../constantes/app-settings';
import { ResourceParams, ResourceAction, IResourceMethod, ResourceRequestMethod } from '@ngx-resource/core';

@Injectable()
@ResourceParams({
	url: AppSettings.API_ENDPOINT
})
export class CatalogoRecurso extends BaseRecurso {

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/Index'
	})
	listar: IResourceMethod<any, any[]>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		isArray: true,
		path: 'Catalogo/Details'
	})
	get: IResourceMethod<any, any[]>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/Create'
	})
	crear: IResourceMethod<any, any>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/Edit'
	})
	editar: IResourceMethod<any, any>;

	@ResourceAction({
		method: ResourceRequestMethod.Post,
		path: 'Catalogo/Delete'
	})
	eliminar: IResourceMethod<any, any>;

}
