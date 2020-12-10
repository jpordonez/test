import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { #{Entidad}Service } from 'app/servicios/#{Entidad}/#{Entidad}.service';
import { BaseCrudItemsPaginaBuscador } from 'app/core/nucleo/controladores/base-crud-items-pagina-buscador';

@Component({
  selector: 'app-#{Entidad}',
  templateUrl: './#{Entidad}.component.html',
  styleUrls: ['./#{Entidad}.component.css']
})
export class #{Entidad}Component extends BaseCrudItemsPaginaBuscador implements OnInit, OnDestroy {

  public periodosAcademicos: any[] = [];
  public programasAcademicos: any[] = [];
  public centros: any[] = [];
  public modulos: any[] = [];

  constructor(private fb: FormBuilder,
    private #{Entidad}Service: #{Entidad}Service) {
    super(#{Entidad}Service, EntidadItemComponent.name, 'EntidadItems');
  }

  ngOnInit() {
    this.criteriaForm = this.fb.group({
      Codigo: new FormControl('', [])
    });

    this.entidadForm = this.fb.group({
      Id: new FormControl('', []),
      Codigo: new FormControl('', []),
      PeriodoAcademicoId: new FormControl('', [Validators.required]),
      ProgramaAcademicoId: new FormControl('', [Validators.required]),
      CentroId: new FormControl('', [Validators.required]),
      ModuloId: new FormControl('', [Validators.required]),
      Instructor: new FormControl('', [Validators.required]),
      Descripcion: new FormControl('', [Validators.required]),
      FechaCreacion: new FormControl('', []),
      Grupos: new FormControl('', [Validators.required])
    });

    this.alertaEntidad = {
      titulo: "#{Entidad}",
      mensaje: "",
      esVisible: false,
      esBloquear: false
    };

    var resultado = this.#{Entidad}Service.getDatosInicio();

    resultado
      .then(
        (res: any) => {
          this.periodosAcademicos = [];
          this.periodosAcademicos.push({ label: 'Seleccione', value: null });
          this.periodosAcademicos = this.periodosAcademicos.concat(res.periodos);
          this.programasAcademicos = [];
          this.programasAcademicos.push({ label: 'Seleccione', value: null });
          this.programasAcademicos = this.programasAcademicos.concat(res.programas);
          this.centros = [];
          this.centros.push({ label: 'Seleccione', value: null });
          this.centros = this.centros.concat(res.centros);
          this.modulos = [];
          this.modulos.push({ label: 'Seleccione', value: null });
          this.modulos = this.modulos.concat(res.modulos);
        }
      );

    this.obtenerObjetoDesdeCrudService = true;
    this.postObtenerObjeto = this.postObtenerObjetoDesdeServicio;

  }

  guardar() {
    let items = this.entidadForm.controls[this.nombreControlItems].value as any[];
    if (items && items.length == 0) {
      this.utilService.mostrarMensaje('Es obligatorio registrar ' + this.nombreControlItems + '.');
      return;
    }
    //Fijar propiedades y realizar validaciones antes de guardar el objeto
    var fechaCreacion = new Date();
    this.entidadForm.controls['FechaCreacion'].setValue(fechaCreacion);
    super.guardar();
  }

}
