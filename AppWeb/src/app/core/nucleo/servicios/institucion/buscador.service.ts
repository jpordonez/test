import { Injectable } from '@angular/core';
import {InstitucionRecurso} from '../../../nucleo/recursos/institucion/InstitucionRecurso';
import {BaseServicio} from '../../../nucleo/servicios/base-servicio';
import { Subject }    from 'rxjs/Subject';

@Injectable()
export class BuscadorInstitucionService extends BaseServicio {

	constructor(private institucionRecurso:InstitucionRecurso) {
        super(institucionRecurso);
    }

}
