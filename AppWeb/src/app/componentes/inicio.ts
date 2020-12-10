import {Component} from '@angular/core';
import {MenuItem} from 'primeng/primeng';


@Component({
    selector: 'my-app',
    templateUrl: './inicio.html'
})
export class InicioComponente {

    private items: MenuItem[];
    public display: boolean=false;

    ngOnInit() {
                
	}
}