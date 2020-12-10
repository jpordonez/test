import { Injectable } from '@angular/core';
import {ItemRecurso} from '../../recursos/item/item-recurso';
import {BaseServicio} from '../base-servicio';
import { Subject }    from 'rxjs/Subject';

@Injectable()
export class ItemService extends BaseServicio{

	constructor(private itemRecurso:ItemRecurso) {
		super(itemRecurso);
	}

}
