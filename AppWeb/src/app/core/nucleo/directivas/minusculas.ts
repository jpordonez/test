import { Directive, ElementRef, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { NgControl } from "@angular/forms";

@Directive({
	selector: '[minusculas]'
})
export class Minusculas {

	constructor(private el: ElementRef,
				private control : NgControl) {

	}

	@HostListener('input', ['$event']) 
	onChange(event) {		
		let posCursor = this.el.nativeElement.selectionStart;
		this.el.nativeElement.value = this.el.nativeElement.value.toLowerCase();
		//Para actualizar el modelo con el cambio de texto a minusculas
		this.control.control.setValue(this.el.nativeElement.value);
		this.el.nativeElement.selectionStart = posCursor;
	}

}