import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from 'app/core/nucleo/controladores/base-crud-pagina-buscador';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';
import { ComponenteEducativoService } from 'app/servicios/componente-educativo/componente-educativo.service';

@Component({
  selector: 'app-ComponenteEducativo',
  templateUrl: './componente-educativo.component.html',
  styleUrls: ['./componente-educativo.component.css']
})
export class ComponenteEducativoComponent extends BaseCrudPaginaBuscador implements OnInit {

  public tiposDocumento: SelectItem[] = [];
  public estadosCivil: SelectItem[] = [];

  constructor(private fb: FormBuilder,
    private componenteEducativoService: ComponenteEducativoService) {
    super(componenteEducativoService);
  }

  ngOnInit() {
    this.criteriaForm = this.fb.group({
      Identificacion: new FormControl('', []),
      Codigo: new FormControl('', [Validaciones.Codigo]),
      Nombre: new FormControl('', [Validaciones.Nombre])
    });
    this.entidadForm = this.fb.group({
      Id: new FormControl('', []),
      Codigo: new FormControl('', [Validators.required, Validaciones.Codigo]),
      Nombre: new FormControl('', [Validators.required, Validaciones.Nombre])
    });
    this.alertaEntidad = {
      titulo: "ComponenteEducativo",
      mensaje: "",
      esVisible: false,
      esBloquear: false
    };

    var resultado = this.componenteEducativoService.getDatosInicio();

    resultado
      .then(
        (res: any) => {
          this.tiposDocumento = res.tpsi;
          this.estadosCivil = res.etsc;
        }
      );

  }

  /*
  nuevo() {
    super.nuevo();
    //Para fijar por defecto el primer valor de los combos de tipo de documento y estado civil
    var ComponenteEducativo = {
      Id: 0,
      TipoDocumento: (this.tiposDocumento.length > 0 ? this.tiposDocumento[0].value : 0),
      EstadoCivil: (this.estadosCivil.length > 0 ? this.estadosCivil[0].value : 0)
    };
    this.entidadForm.reset(ComponenteEducativo);
  }*/

}
