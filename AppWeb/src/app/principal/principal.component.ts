import { Component, OnInit } from '@angular/core';
import { AplicacionServicio } from "app/core/seguridad/servicio/AplicacionServicio";
import { Observable } from "rxjs/Observable";
import { UtilityService } from "app/core/services/utility.service";

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent implements OnInit {

  constructor(private aplicacionServicio: AplicacionServicio,
              public utilityService: UtilityService) { }

  ngOnInit() {
    if (!this.aplicacionServicio.esUsuarioAutenticado()) {
      window.location.href = '/assets/pages/landing.html';
      //window.location.href = '/sitio/index.html';
    } else {
      let timer = Observable.timer(100);
      timer.subscribe(t=>this.utilityService.navegar("/inicio")); 
    }
  }

}
