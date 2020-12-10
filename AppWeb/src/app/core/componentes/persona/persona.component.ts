import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { UtilityService } from '../../services/utility.service';
import { Alerta } from '../../nucleo/modelo/Alerta';
import { SelectItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from '../../nucleo/controladores/base-crud-pagina-buscador';
import { PersonaService } from '../../nucleo/servicios/persona/persona.service';
import { Validaciones } from '../../nucleo/validaciones/validaciones';
import { Accion } from '../../nucleo/enums/accion.enum';
import { LazyLoadEvent } from 'primeng/primeng';

@Component({
	selector: 'app-persona',
	templateUrl: './persona.component.html',
	styleUrls: ['./persona.component.css']
})
export class PersonaComponent extends BaseCrudPaginaBuscador implements OnInit {

	public tiposDocumento: SelectItem[] = [];
	public estadosCivil: SelectItem[] = [];

	constructor(private fb: FormBuilder,
		private utilityService: UtilityService,
		private personaService: PersonaService) {
		super(personaService);
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
			titulo: "Persona",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		var resultado = this.personaService.getDatosInicio();

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
		var persona = {
			Id: 0,
			TipoDocumento: (this.tiposDocumento.length > 0 ? this.tiposDocumento[0].value : 0),
			EstadoCivil: (this.estadosCivil.length > 0 ? this.estadosCivil[0].value : 0)
		};
		this.entidadForm.reset(persona);
	}

}
