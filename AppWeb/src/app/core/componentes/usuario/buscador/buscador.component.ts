import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
import { BaseBuscador } from 'app/core/nucleo/controladores/base-buscador';
import { UsuarioService } from 'app/core/nucleo/servicios/usuario/usuario.service';
import { Peticion } from 'app/core/nucleo/modelo/peticion';

@Component({
	selector: 'buscador-usuario',
	templateUrl: './buscador.component.html',
	styleUrls: ['./buscador.component.css']
})
export class BuscadorUsuarioComponent extends BaseBuscador implements OnInit {

	public rolesSistemaPagina: any[] = [];

	constructor(private fb: FormBuilder,
		private usuarioService: UsuarioService) {
		super(usuarioService);
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Identificacion: new FormControl('', []),
			Cuenta: new FormControl('', []),
			RolId: new FormControl('', [])
		});
		this.alertaBuscador = {
			titulo: "Usuario",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		var resultado = this.usuarioService.getDatosInicio();

		resultado
			.then(
				(res: any) => {
					this.rolesSistemaPagina = [];
					this.rolesSistemaPagina.push({ label: 'Seleccione', value: null });
					this.rolesSistemaPagina = this.rolesSistemaPagina.concat(res.rolesSistemaModeloVista);
				}
			);

	}

	visualizar(peticion: Peticion) {
		super.visualizar(peticion);
		let rolCodigo = peticion.data.RolCodigo;
		let rolControl = this.criteriaForm.controls['RolId'];
		//Si tiene rolcodigo fijo y bloqueo control rol
		if (rolCodigo) {
			let rol = this.rolesSistemaPagina.filter(t => t.Codigo == rolCodigo)[0];
			if (!rol) {
				console.error('No se encontró un rol de sistema con código: ' + rolCodigo);
				return;
			}
			let rolId = rol.value;
			rolControl.setValue(rolId);
			this.alertaBuscador.titulo = rol.label;
			rolControl.disable();
		} else {
			this.alertaBuscador.titulo = 'Usuario';
			rolControl.enable();
		}
	}

}
