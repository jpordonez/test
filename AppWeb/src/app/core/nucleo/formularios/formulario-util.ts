import { Validators, FormControl, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';

export class FormularioUtil{
  
    constructor() {
       
    }  
	
	static marcarTodoSucio(control: AbstractControl) {
        if(control.hasOwnProperty('controls')) {
            control.markAsDirty();
            let ctrl = control as any;
            for (let inner in ctrl.controls) {
                this.marcarTodoSucio(ctrl.controls[inner] as AbstractControl);
            }
        }
        else {
            (control as FormControl).markAsDirty();
        }
    }

    static getEntidadCompleta(formulario: FormGroup): any {        
        if(formulario.hasOwnProperty('controls')) {
            let entidad = formulario.getRawValue();            
            for (let nombreControl in formulario.controls) {
                let control = formulario.controls[nombreControl];
                if (control instanceof FormGroup) {
                    let subFormulario = this.getEntidadCompleta(control);
                    entidad[nombreControl] = subFormulario;
                }                
            }
            return entidad;
        }
        else {            
            return formulario.getRawValue();
        }
    }

}