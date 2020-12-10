import { Injectable } from '@angular/core';
import { BaseServicio } from '../base-servicio';
import { UsuarioRecurso } from '../../recursos/usuario/UsuarioRecurso';

@Injectable()
export class UsuarioService extends BaseServicio {

  constructor(private usuarioRecurso: UsuarioRecurso) {
    super(usuarioRecurso);
  }

  validarExistencia(criteria: any) {
    return this.usuarioRecurso.validarExistencia(criteria);
  }

}
