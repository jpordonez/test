import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { SelectItem } from "primeng/primeng";
import { PersonaService } from "app/core/nucleo/servicios/persona/persona.service";
import { Validaciones } from "app/core/nucleo/validaciones/validaciones";
import { FormularioUtil } from "app/core/nucleo/formularios/formulario-util";
import { UtilityService } from "app/core/services/utility.service";

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  public representanteForm: FormGroup;
  public tiposDocumento: SelectItem[] = [];
  public estadosCivil: SelectItem[] = [];
  public identificacionHaCambiado: boolean;

  constructor(public fb: FormBuilder,
    private personaService: PersonaService,
    private utilityService: UtilityService) { }

  ngOnInit() {
    this.representanteForm = this.fb.group({
      Id: new FormControl('', []),
      Identificacion: new FormControl('', [Validators.required, Validaciones.Identificacion]),
      PrimerNombre: new FormControl('', [Validators.required, Validaciones.Nombre]),
      PrimerApellido: new FormControl('', [Validators.required, Validaciones.Apellido]),
      SegundoNombre: new FormControl('', [Validaciones.Nombre]),
      SegundoApellido: new FormControl('', [Validaciones.Apellido]),
      TipoDocumento: new FormControl('', [Validators.required]),
      Telefono: new FormControl('', [Validaciones.Telefono]),
      Movil: new FormControl('', [Validaciones.Celular]),
      Correo: new FormControl('', [Validators.required, Validaciones.Correo]),
      ConfirmarCorreo: new FormControl('', [Validators.required, Validaciones.Correo])
    });

    var resultado = this.personaService.getDatosInicio();
    resultado
      .then(
        (res: any) => {
          this.tiposDocumento = [];
          this.tiposDocumento.push({ label: 'Seleccione', value: null });
          this.tiposDocumento = this.tiposDocumento.concat(res.tpsi);
          this.estadosCivil = [];
          this.estadosCivil.push({ label: 'Seleccione', value: null });
          this.estadosCivil = this.estadosCivil.concat(res.etsc);
        }
      );

    var resultado1 = this.personaService.get({ Id: 0 });
    resultado1
      .then(
        (res: any) => {
          res.ConfirmarCorreo = res.Correo;
          this.representanteForm.reset(res);
          let tipoDocumento = this.representanteForm.controls['TipoDocumento'];
          let identificacion = this.representanteForm.controls['Identificacion'];
          tipoDocumento.disable();
          identificacion.disable();
        }
      );

    this.identificacionHaCambiado = false;

  }

  validarIdentificacion() {
    if (!this.identificacionHaCambiado) {
      return;
    }
    this.identificacionHaCambiado = false;

    let tipoDocumento = this.representanteForm.controls['TipoDocumento'];
    let identificacion = this.representanteForm.controls['Identificacion'];
    let criteria = { TipoDocumento: tipoDocumento.value, Identificacion: identificacion.value };
    var resultado = this.personaService.validarIdentificacionYExistencia(criteria);

    resultado
      .then(
        (res: any) => {
          //Si no se trata de una identificacion valida
          if (!res.resultado) {
            tipoDocumento.setValue(null);
            this.haCambiadoTipoIdentificacion({ value: null });
            this.utilityService.mostrarMensaje(res.mensaje);
          }
        }
      );
  }

  haCambiadoIdentificacion() {
    this.identificacionHaCambiado = true;
  }

  haCambiadoTipoIdentificacion(event) {
    let identificacion = this.representanteForm.controls['Identificacion'];
    if (!event.value) {
      identificacion.setValue(null);
      identificacion.disable();
    } else {
      identificacion.enable();
    }
  }

  guardar() {
    //Se debe ejecutar despues de form.reset para que la propiedad dirty no sea modificada
    FormularioUtil.marcarTodoSucio(this.representanteForm);

    if (this.representanteForm.invalid) {
      this.utilityService.mostrarMensaje('El formulario es invalido o incompleto.');
      return;
    } else {
      let correo = this.representanteForm.controls['Correo'] as FormControl;
      let confirmarCorreo = this.representanteForm.controls['ConfirmarCorreo'] as FormControl;
      if (correo.value != confirmarCorreo.value) {
        correo.markAsDirty();
        confirmarCorreo.markAsDirty();
        this.utilityService.mostrarMensaje('Correo y la confirmación del mismo deben coincidir.');
        return;
      }
    }

    let respuesta = this.personaService.editar(FormularioUtil.getEntidadCompleta(this.representanteForm));
    respuesta
      .then(
        (res: any) => {
          this.utilityService.mostrarMensaje('Datos guardados correctamente');
        }
      );
  }

}

