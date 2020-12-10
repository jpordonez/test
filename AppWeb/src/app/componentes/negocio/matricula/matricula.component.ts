import { ComponenteEducativoService } from 'app/servicios/componente-educativo/componente-educativo.service';
import { BuscadorComponenteEducativoComponent } from './../componente-educativo/buscador/buscador.component';
import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from 'app/core/nucleo/controladores/base-crud-pagina-buscador';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';
import { MatriculaService } from 'app/servicios/matricula/matricula.service';
import { Peticion } from 'app/core/nucleo/modelo/peticion';
import { Subscription } from 'rxjs';
import { BuscadorPersonaComponent } from 'app/core/componentes/persona/buscador/buscador.component';
import { BuscadorPersonaService } from 'app/core/nucleo/servicios/persona/buscador.service';

@Component({
  selector: 'app-Matricula',
  templateUrl: './matricula.component.html',
  styleUrls: ['./matricula.component.css']
})
export class MatriculaComponent extends BaseCrudPaginaBuscador implements OnInit {

  public estudiante: any = {};
  public coe: any = {};

  private subscripcionEstudiante: Subscription;
  private subscripcionCoe: Subscription;

  constructor(private fb: FormBuilder,
    private matriculaService: MatriculaService,
    private componenteEducativoService: ComponenteEducativoService,
    private personaService: BuscadorPersonaService) {
    super(matriculaService);
    //Suscribir a notificaciones de utilizacion de buscador
    this.subscripcionEstudiante = personaService.respuesta$.subscribe(
      respuesta => {
        let emisor = respuesta.emisor;
        switch (emisor) {
          case 'EST1':
            this.estudiante = respuesta.data;
            this.entidadForm.controls['EstudianteId'].setValue(this.estudiante.Id);
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
      EstudianteId: new FormControl('', [Validators.required]),
      EstudianteNombre: new FormControl('', []),
      ComponenteEducativoId: new FormControl('', [Validators.required]),
      ComponenteEducativoCodigo: new FormControl('', []),
      ComponenteEducativoNombre: new FormControl('', [])
    });
    this.alertaEntidad = {
      titulo: "Matricula",
      mensaje: "",
      esVisible: false,
      esBloquear: false
    };

    var resultado = this.matriculaService.getDatosInicio();

    resultado
      .then(
        (res: any) => {

        }
      );

  }

  nuevo() {
    super.nuevo();
    //Para fijar por defecto el primer valor de los combos de tipo de documento y estado civil
    this.estudiante = {};
    this.coe = {};
  }

  buscarCoe() {
    let peticion = new Peticion();
    peticion.emisor = 'COE1';
    peticion.receptor = BuscadorComponenteEducativoComponent.name;
    this.componenteEducativoService.notificarPeticion(peticion);
  }

  buscarEstudiante() {
    let peticion = new Peticion();
    peticion.data =
    {
      tipoPersonaNombre: 'Estudiante'
    };
    peticion.emisor = 'EST1';
    peticion.receptor = BuscadorPersonaComponent.name;
    this.personaService.notificarPeticion(peticion);
  }

}
