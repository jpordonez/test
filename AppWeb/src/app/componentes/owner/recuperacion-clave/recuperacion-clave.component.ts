import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AplicacionServicio } from '../../../core/seguridad/servicio/AplicacionServicio';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UtilityService } from "app/core/services/utility.service";
import { Validaciones } from "app/core/nucleo/validaciones/validaciones";

@Component({
  selector: 'app-recuperacion-clave',
  templateUrl: './recuperacion-clave.component.html',
  styleUrls: ['./recuperacion-clave.component.css']
})
export class RecuperacionClaveComponent implements OnInit {

  public entidadForm: FormGroup;
  public esClaveCambiada: boolean = false;

  constructor(private route: ActivatedRoute,
    private utilityService: UtilityService,
    private aplicacionServicio: AplicacionServicio,
    public fb: FormBuilder) { }

  ngOnInit() {
    this.entidadForm = this.fb.group({
      Clave: new FormControl('', [Validators.required, Validaciones.Clave]),
      ConfirmarClave: new FormControl('', [Validators.required, Validaciones.Clave])
    });
    let param = this.route.snapshot.queryParams["param"];
    if (!param) {
      this.utilityService.mostrarMensaje('La petición no tiene el formato esperado.');
    }
  }

  cambiarClabe() {
    this.esClaveCambiada = false;
    let param = this.route.snapshot.queryParams["param"];
    if (!param) {
      this.utilityService.mostrarMensaje('La petición no tiene el formato esperado.');
      return;
    }
    let clave = this.entidadForm.controls['Clave'] as FormControl;
    let confirmarClave = this.entidadForm.controls['ConfirmarClave'] as FormControl;
    if (clave.value != confirmarClave.value) {
      clave.markAsDirty();
      confirmarClave.markAsDirty();
      this.utilityService.mostrarMensaje('Clave y la confirmación del misma deben coincidir.');
      return;
    }
    let respuesta = this.aplicacionServicio.recuperarClave(clave.value, param);
    respuesta
      .then(
        (res: any) => {
          this.esClaveCambiada = true;
          this.entidadForm.reset();
        }
      )
      .catch(
        (error: any) => {
          this.esClaveCambiada = false;
        }
      );
  }

}
