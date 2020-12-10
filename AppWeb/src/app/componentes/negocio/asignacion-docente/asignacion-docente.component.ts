import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from 'app/core/nucleo/controladores/base-crud-pagina-buscador';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';
import { AsignacionDocenteService } from 'app/servicios/asignacion-docente/asignacion-docente.service';
import { Subscription } from 'rxjs';
import { BuscadorPersonaService } from 'app/core/nucleo/servicios/persona/buscador.service';
import { ComponenteEducativoService } from 'app/servicios/componente-educativo/componente-educativo.service';
import { Peticion } from 'app/core/nucleo/modelo/peticion';
import { BuscadorComponenteEducativoComponent } from '../componente-educativo/buscador/buscador.component';
import { BuscadorPersonaComponent } from 'app/core/componentes/persona/buscador/buscador.component';

@Component({
  selector: 'app-AsignacionDocente',
  templateUrl: './asignacion-docente.component.html',
  styleUrls: ['./asignacion-docente.component.css']
})
export class AsignacionDocenteComponent extends BaseCrudPaginaBuscador implements OnInit {

  public docente: any = {};
  public coe: any = {};

  private subscripcionDocente: Subscription;
  private subscripcionCoe: Subscription;

  constructor(private fb: FormBuilder,
    private asignacionDocenteService: AsignacionDocenteService,
    private componenteEducativoService: ComponenteEducativoService,
    private personaService: BuscadorPersonaService) {
    super(asignacionDocenteService);
    //Suscribir a notificaciones de utilizacion de buscador
    this.subscripcionDocente = personaService.respuesta$.subscribe(
      respuesta => {
        let emisor = respuesta.emisor;
        switch (emisor) {
          case 'DOC1':
            this.docente = respuesta.data;
            this.entidadForm.controls['DocenteId'].setValue(this.docente.Id);
            break;
          default:
            // code...
            break;
        }
      });
    //Suscribir a notificaciones de utilizacion de buscador
    this.subscripcionCoe = componenteEducativoService.respuesta$.subscribe(
      respuesta => {
        let emisor = respuesta.emisor;
        switch (emisor) {
          case 'COE1':
            this.coe = respuesta.data;
            this.entidadForm.controls['ComponenteEducativoId'].setValue(this.coe.Id);
            break;
          default:
            // code...
            break;
        }
      });
  }

  ngOnInit() {
    this.criteriaForm = this.fb.group({
      Identificacion: new FormControl('', [])
    });
    this.entidadForm = this.fb.group({
      Id: new FormControl('', []),
      DocenteId: new FormControl('', [Validators.required]),
      DocenteNombre: new FormControl('', []),
      ComponenteEducativoId: new FormControl('', [Validators.required]),
      ComponenteEducativoCodigo: new FormControl('', []),
      ComponenteEducativoNombre: new FormControl('', [])
    });
    this.alertaEntidad = {
      titulo: "Asignacion Docente",
      mensaje: "",
      esVisible: false,
      esBloquear: false
    };

    var resultado = this.asignacionDocenteService.getDatosInicio();

    resultado
      .then(
        (res: any) => {

        }
      );

  }

  nuevo() {
    super.nuevo();
    //Para fijar por defecto el primer valor de los combos de tipo de documento y estado civil
    this.docente = {};
    this.coe = {};
  }

  buscarCoe() {
    let peticion = new Peticion();
    peticion.emisor = 'COE1';
    peticion.receptor = BuscadorComponenteEducativoComponent.name;
    this.componenteEducativoService.notificarPeticion(peticion);
  }

  buscarDocente() {
    let peticion = new Peticion();
    peticion.data =
    {
      tipoPersonaNombre: 'Docente'
    };
    peticion.emisor = 'DOC1';
    peticion.receptor = BuscadorPersonaComponent.name;
    this.personaService.notificarPeticion(peticion);
  }

}
