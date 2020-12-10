import { ComponenteEducativoService } from 'app/servicios/componente-educativo/componente-educativo.service';
import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
import { BaseBuscador } from 'app/core/nucleo/controladores/base-buscador';
import { UsuarioService } from 'app/core/nucleo/servicios/usuario/usuario.service';
import { Peticion } from 'app/core/nucleo/modelo/peticion';

@Component({
	selector: 'buscador-componente-educativo',
	templateUrl: './buscador.component.html',
	styleUrls: ['./buscador.component.css']
})
export class BuscadorComponenteEducativoComponent extends BaseBuscador implements OnInit {

	constructor(private fb: FormBuilder,
		private componenteEducativoService: ComponenteEducativoService) {
		super(componenteEducativoService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Codigo: new FormControl('', []),
			Nombre: new FormControl('', [])
		});
		this.alertaBuscador = {
			titulo: "Materia",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		var resultado = this.componenteEducativoService.getDatosInicio();

		resultado
			.then(
				(res: any) => {

				}
			);

	}

}
