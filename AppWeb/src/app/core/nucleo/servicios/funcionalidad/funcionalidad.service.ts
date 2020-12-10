import { Injectable } from '@angular/core';
import {BaseServicio} from '../base-servicio';
import {FuncionalidadRecurso} from '../../recursos/funcionalidad/FuncionalidadRecurso';

@Injectable()
export class FuncionalidadService extends BaseServicio {

	constructor(private funcionalidadRecurso:FuncionalidadRecurso) { 
      super(funcionalidadRecurso);
  }

	listar(criteria:any){
  		return this.funcionalidadRecurso.listar(criteria);
  	}

    get(entidad:any){
      	return this.funcionalidadRecurso.get(entidad);
    }

  	crear(entidad:any){
  		return this.funcionalidadRecurso.crear(entidad);
  	}

  	editar(entidad:any){
  		return this.funcionalidadRecurso.editar(entidad);
  	}

    eliminar(entidad:any){
      	return this.funcionalidadRecurso.eliminar(entidad);
    }

    getDatosInicio(){
    	return this.funcionalidadRecurso.getDatosInicio();
    }

}