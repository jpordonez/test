import { Injectable } from '@angular/core';
import {MenuRecurso} from '../../recursos/menu/MenuRecurso';
import {BaseServicio} from '../../servicios/base-servicio';

@Injectable()
export class MenuService extends BaseServicio {

    constructor(private menuRecurso:MenuRecurso) {
      super(menuRecurso);
    }

}