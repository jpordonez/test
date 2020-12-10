import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
import { BaseBuscador } from 'app/core/nucleo/controladores/base-buscador';
import { BuscadorInstitucionService } from 'app/core/nucleo/servicios/institucion/buscador.service';

@Component({
	selector: 'buscador-institucion',
	templateUrl: './buscador.component.html',
	styleUrls: ['./buscador.component.css']
})
export class BuscadorInstitucionComponent extends BaseBuscador implements OnInit {

	constructor(private fb: FormBuilder,
		private buscadorInstitucionService: BuscadorInstitucionService) {
		super(buscadorInstitucionService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Ruc: new FormControl('', []),
			Nombres: new FormControl('', []),
			NumeroPagina: new FormControl('', [Validators.required])
		});
		this.alertaBuscador = {
			titulo: "Instituciones",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};
	}

}
