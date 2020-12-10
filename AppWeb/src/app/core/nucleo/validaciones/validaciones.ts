import { AbstractControl, ValidatorFn } from '@angular/forms';
import {ExpresionesRegulares} from '../../constantes/expresiones-regulares';

function evaluar(control: AbstractControl, expresionRegular: string) {
	if(!control.value) {
		return null;
	}
  	let regex = new RegExp(expresionRegular);
    let isValid = regex.test(control.value);

	if(isValid) {
	    return null;
	} else {
	    return {
	        validarDecimal: {
	            valid: false
	        }
	    };
	}

}

export class Validaciones {

	constructor() {}

	static Apellido(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.APELLIDO);
	}

	static Nombre(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.NOMBRE);
	}

	static Decimal(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.DECIMAL);
	}

	static DecimalPositivo(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.DECIMALPOSITIVO);
	}

	static Descripcion(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.DESCRIPCION);
	}

	static Pregunta(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.PREGUNTA);
	}

	static Opcion(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.OPCION);
	}

	static Codigo(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.CODIGO);
	}

	static Identificacion(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.IDENTIFICACION);
	}

	static Correo(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.CORREO);
	}

	static Telefono(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.TELEFONO);
	}

	static Celular(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.CELULAR);
	}

	static Ruc(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.RUC);
	}

	static RazonSocial(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.RAZONSOCIAL);
	}

	static EnteroPositivo(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.ENTEROPOSITIVO);
	}

	static NombreEspecial(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.NOMBREESPECIAL);
	}

	static Cuenta(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.CUENTA);
	}

	static Clave(control: AbstractControl) {
		return evaluar(control,ExpresionesRegulares.CLAVE);
	}	

}