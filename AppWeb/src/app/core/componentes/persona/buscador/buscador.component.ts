import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
import { BaseBuscador } from 'app/core/nucleo/controladores/base-buscador';
import { BuscadorPersonaService } from 'app/core/nucleo/servicios/persona/buscador.service';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';
import { Peticion } from 'app/core/nucleo/modelo/peticion';

@Component({
	selector: 'buscador-personas',
	templateUrl: './buscador.component.html',
	styleUrls: ['./buscador.component.css']
})
export class BuscadorPersonaComponent extends BaseBuscador implements OnInit {

	constructor(private fb: FormBuilder,
		private buscadorPersonaService: BuscadorPersonaService) {
		super(buscadorPersonaService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Identificacion: new FormControl('', []),
			Nombre: new FormControl('', [Validaciones.Nombre]),
			Apellido: new FormControl('', [Validaciones.Apellido]),
			NumeroPagina: new FormControl('', [Validators.required])
		});
		this.alertaBuscador = {
			titulo: "",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};
	}

	visualizar(peticion: Peticion) {
		this.alertaBuscador.titulo = peticion.data.tipoPersonaNombre;
		this.criteriaForm.reset();
		super.visualizar(peticion);
	}

}
