import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from 'app/core/nucleo/controladores/base-crud-pagina-buscador';
import { #{Entidad}Service } from '../../nucleo/servicios/#{Entidad}/#{Entidad}.service';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';

@Component({
	selector: 'app-#{Entidad}',
	templateUrl: './#{Entidad}.component.html',
	styleUrls: ['./#{Entidad}.component.css']
})
export class #{Entidad}Component extends BaseCrudPaginaBuscador implements OnInit {

	public tiposDocumento: SelectItem[] = [];
	public estadosCivil: SelectItem[] = [];

	constructor(private fb: FormBuilder,
		private #{Entidad}Service: #{Entidad}Service) {
		super(#{Entidad}Service);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Identificacion: new FormControl('', []),
			Nombre: new FormControl('', [Validaciones.Nombre]),
			Apellido: new FormControl('', [Validaciones.Apellido])
		});
		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			Identificacion: new FormControl('', [Validators.required, Validaciones.Identificacion]),
			PrimerNombre: new FormControl('', [Validators.required, Validaciones.Nombre]),
			PrimerApellido: new FormControl('', [Validators.required, Validaciones.Apellido]),
			SegundoNombre: new FormControl('', [Validaciones.Nombre]),
			SegundoApellido: new FormControl('', [Validaciones.Apellido]),
			TipoDocumento: new FormControl('', [Validators.required]),
			Telefono: new FormControl('', [Validaciones.Telefono]),
			Movil: new FormControl('', [Validaciones.Celular]),
			Correo: new FormControl('', [Validaciones.Correo]),
			EstadoCivil: new FormControl('', [Validators.required])
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
					this.tiposDocumento = res.tpsi;
					this.estadosCivil = res.etsc;
				}
			);

	}

	nuevo() {
		super.nuevo();
		//Para fijar por defecto el primer valor de los combos de tipo de documento y estado civil	
		var #{Entidad} = {
			Id: 0,
			TipoDocumento: (this.tiposDocumento.length > 0 ? this.tiposDocumento[0].value : 0),
			EstadoCivil: (this.estadosCivil.length > 0 ? this.estadosCivil[0].value : 0)
		};
		this.entidadForm.reset(#{Entidad});
	}

}
