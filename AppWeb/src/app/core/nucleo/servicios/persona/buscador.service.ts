import { Injectable } from '@angular/core';
import {BaseServicio} from '../base-servicio';
import {PersonaRecurso} from '../../recursos/persona/PersonaRecurso';

@Injectable()
export class BuscadorPersonaService extends BaseServicio {

	constructor(private personaRecurso:PersonaRecurso) {
        super(personaRecurso);
    }

}
