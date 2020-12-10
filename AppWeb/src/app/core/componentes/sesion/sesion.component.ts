import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { BaseCrudPaginaBuscador } from '../../../core/nucleo/controladores/base-crud-pagina-buscador';
import { UtilityService } from '../../../core/services/utility.service';
import { SesionService } from '../../nucleo/servicios/sesion/sesion.service';
import { SelectItem } from 'primeng/primeng';

@Component({
  selector: 'app-sesion',
  templateUrl: './sesion.component.html',
  styleUrls: ['./sesion.component.css']
})
export class SesionComponent extends BaseCrudPaginaBuscador implements OnInit {

  public rolesSistema: SelectItem[] = [];

  constructor(public fb: FormBuilder,
    private utilityService: UtilityService,
    private sesionService: SesionService) {
    super(sesionService);
  }

  ngOnInit() {
    this.criteriaForm = this.fb.group({
      Cuenta: new FormControl('', []),
      FechaDesde: new FormControl('', []),
      FechaHasta: new FormControl('', [])
    });

    this.entidadForm = this.fb.group({
      Id: new FormControl('', []),
      Cuenta: new FormControl('', []),
      Ip: new FormControl('', []),
      Inicio: new FormControl('', []),
      Fin: new FormControl('', []),
      RolId: new FormControl('', []),
      Token: new FormControl('', [])
    });

    this.alertaEntidad = {
      titulo: "Sesion",
      mensaje: "",
      esVisible: false,
      esBloquear: false
    };

    var resultado = this.sesionService.getDatosInicio();

    resultado
      .then(
        (res: any) => {
          this.rolesSistema = res.rolesSistemaModeloVista;
        }
      );

  }

}
