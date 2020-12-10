import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector : '[control]'
})
export class Control{
  
    constructor(private el: ElementRef) {
       
    }
  
	@Input()
	set bloquear(bloquear : boolean){
		this.el.nativeElement.disabled = bloquear;
	}
}