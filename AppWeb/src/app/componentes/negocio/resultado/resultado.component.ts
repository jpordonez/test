import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from 'app/core/nucleo/controladores/base-crud-pagina-buscador';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';
import { ResultadoService } from 'app/servicios/resultado/resultado.service';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent extends BaseCrudPaginaBuscador implements OnInit {

  public estudiante: any = {};
  public coe: any = {};
  public estadosCoe: SelectItem[] = [];

  constructor(private fb: FormBuilder,
    private resultadoService: ResultadoService) {
    super(resultadoService);
  }

  ngOnInit() {
    this.criteriaForm = this.fb.group({
      EstadoCoe: new FormControl('', [])
    });
    this.entidadForm = this.fb.group({
      Id: new FormControl('', []),
      AsignacionDocenteId: new FormControl('', [Validators.required]),
      MatriculaId: new FormControl('', [Validators.required]),
      Deberes: new FormControl('', [Validaciones.DecimalPositivo]),
      Examen: new FormControl('', [Validaciones.DecimalPositivo])
    });
    this.alertaEntidad = {
      titulo: "Resultado",
      mensaje: "",
      esVisible: false,
      esBloquear: false
    };

    var resultado = this.resultadoService.getDatosInicio();

    resultado
      .then(
        (res: any) => {

        }
      );

    this.estadosCoe[0] = {
      value: null,
      label: 'Seleccionar'
    };
    this.estadosCoe[1] = {
      value: 'ESTCOEAPR',
      label: 'Aprobado'
    };
    this.estadosCoe[2] = {
      value: 'ESTCOEREP',
      label: 'Reprobado'
    };

  }

  editar(fila: number) {
    super.editar(fila);

    var obj = this.lista[fila];

    this.estudiante = {};
    this.estudiante.Identificacion = obj.EstudianteIdentificacion;
    this.estudiante.Nombre = obj.EstudianteNombre;

    this.coe = {};
    this.coe.Codigo = obj.ComponenteEducativoCodigo;
    this.coe.Nombre = obj.ComponenteEducativoNombre;

  }

  visualizar(fila: number) {
    super.visualizar(fila);

    var obj = this.lista[fila];

    this.estudiante = {};
    this.estudiante.Identificacion = obj.EstudianteIdentificacion;
    this.estudiante.Nombre = obj.EstudianteNombre;

    this.coe = {};
    this.coe.Codigo = obj.ComponenteEducativoCodigo;
    this.coe.Nombre = obj.ComponenteEducativoNombre;

  }

}
