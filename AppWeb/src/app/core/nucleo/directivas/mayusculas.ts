import { Directive, ElementRef, Input, HostListener } from '@angular/core';
import { NgControl } from "@angular/forms";

@Directive({
	selector: '[mayusculas]'
})
export class Mayusculas {

	constructor(private el: ElementRef,
				private control : NgControl) {

	}

	@HostListener('input', ['$event'])
	onChange(event) {
		let posCursor = this.el.nativeElement.selectionStart;
		this.el.nativeElement.value = this.el.nativeElement.value.toUpperCase();
		//Para actualizar el modelo con el cambio de texto a mayusculas
		this.control.control.setValue(this.el.nativeElement.value);
		this.el.nativeElement.selectionStart = posCursor;
	}
	
}