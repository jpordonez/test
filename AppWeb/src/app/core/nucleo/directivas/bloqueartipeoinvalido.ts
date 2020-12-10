import { Directive, ElementRef, Input, HostListener } from '@angular/core';
import { NgControl } from "@angular/forms";

@Directive({
	selector: '[bloqueartipeoinvalido]'
})
export class BloquearTipeoInvalido {

	private valorAntiguo: any;

	constructor(private el: ElementRef,
		private control: NgControl) {

	}

	@HostListener('keypress', ['$event'])
	onKeyPress($event) {
		this.valorAntiguo = $event.target.value;
	}

	@HostListener('keydown', ['$event'])
	onKeyDown($event) {
		var key = $event.keyCode || $event.charCode;
		if (key == 8 || key == 46)
			this.valorAntiguo = $event.target.value;
	}

	@HostListener('input', ['$event'])
	onInput($event) {
		if ($event.target.value && this.control.control.invalid) {
			$event.target.value = this.valorAntiguo ? this.valorAntiguo.trim() : null;
		}		
		this.control.control.setValue($event.target.value);
	}

	@HostListener('paste', ['$event'])
	onPaste($event) {
		this.valorAntiguo = $event.target.value;
	}

}