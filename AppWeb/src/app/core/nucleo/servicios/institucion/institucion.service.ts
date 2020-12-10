import { Injectable } from '@angular/core';
import {BaseServicio} from '../../servicios/base-servicio';
import {InstitucionRecurso} from '../../recursos/institucion/InstitucionRecurso';

@Injectable()
export class InstitucionService extends BaseServicio {

	constructor(private institucionRecurso: InstitucionRecurso) { 
		super(institucionRecurso);
	}

}
