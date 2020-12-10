import { Component, OnInit, OnDestroy } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { SelectItem, MenuItem } from 'primeng/primeng';
import { BaseCrudPaginaBuscador } from '../../nucleo/controladores/base-crud-pagina-buscador';
import { UtilityService } from '../../services/utility.service';
import { Validaciones } from '../../nucleo/validaciones/validaciones';
import { UsuarioService } from '../../nucleo/servicios/usuario/usuario.service';
import { Subscription } from "rxjs/Subscription";
import { BuscadorPersonaService } from "app/core/nucleo/servicios/persona/buscador.service";
import { Peticion } from "app/core/nucleo/modelo/peticion";
import { BuscadorPersonaComponent } from "app/core/componentes/persona/buscador/buscador.component";

@Component({
	selector: 'app-usuario',
	templateUrl: './usuario.component.html',
	styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent extends BaseCrudPaginaBuscador implements OnInit, OnDestroy {

	public estadosUsuario: SelectItem[] = [];
	public rolesSistemaPagina: SelectItem[] = [];
	public rolesSistema: SelectItem[] = [];
	public persona: any = {};
	public accionesPersona: MenuItem[];
	private subscripcion: Subscription;

	constructor(private fb: FormBuilder,
		private utilityService: UtilityService,
		private usuarioService: UsuarioService,
		private buscadorPersonaService: BuscadorPersonaService) {
		super(usuarioService);
		//Suscribir a notificaciones de utilizacion de buscador
		this.subscripcion = buscadorPersonaService.respuesta$.subscribe(
			respuesta => {
				let emisor = respuesta.emisor;
				switch (emisor) {
					case 'RESPERUSU1':
						this.persona = respuesta.data;
						this.entidadForm.controls['PersonaId'].setValue(this.persona.Id);
						break;
					default:
						// code...
						break;
				}
			});
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
			Identificacion: new FormControl('', []),
			Cuenta: new FormControl('', []),
			RolId: new FormControl('', [])
		});
		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			PersonaId: new FormControl('', []),
			Cuenta: new FormControl('', [Validaciones.Cuenta]),
			Clave: new FormControl('', [Validators.required, Validaciones.Clave]),
			Estado: new FormControl('', [Validators.required]),
			RolIds: new FormControl('', [Validators.required])
		});
		this.alertaEntidad = {
			titulo: "Usuario",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};
		this.entidadForm.controls['RolIds'].setValue([]);

		this.accionesPersona = [
			{
				label: 'Limpiar', icon: 'ui-icon-clear', command: () => {
					this.persona = {};
					this.entidadForm.controls['PersonaId'].setValue(null);
				}
			}
		];

		var resultado = this.usuarioService.getDatosInicio();

		resultado
			.then(
				(res: any) => {
					this.estadosUsuario = res.estadosUsuario;
					this.rolesSistema = res.rolesSistemaModeloVista;
					this.rolesSistemaPagina = [];
					this.rolesSistemaPagina.push({ label: 'Seleccione', value: null });
					this.rolesSistemaPagina = this.rolesSistemaPagina.concat(res.rolesSistemaModeloVista);
				}
			);

	}

	buscarPersona() {
		let peticion = new Peticion();
		peticion.data =
			{
				tipoPersonaNombre: 'Personas'
			};
		peticion.emisor = 'RESPERUSU1';
		peticion.receptor = BuscadorPersonaComponent.name;
		this.buscadorPersonaService.notificarPeticion(peticion);
	}

	nuevo() {
		super.nuevo();
		//Para fijar por defecto el primer valor del Estado	
		var usuario = {
			Id: 0,
			Estado: (this.estadosUsuario.length > 0 ? this.estadosUsuario[0].value : null)
		};
		this.entidadForm.reset(usuario);
		this.persona = {};
	}

	visualizar(fila: number) {
		super.visualizar(fila);
		this.persona = {
			Identificacion: this.seleccionado.Identificacion,
			Nombres: this.seleccionado.Nombres,
			Apellidos: this.seleccionado.Apellidos
		};
	}

	editar(fila: number) {
		super.editar(fila);
		this.persona = {
			Identificacion: this.seleccionado.Identificacion,
			Nombres: this.seleccionado.Nombres,
			Apellidos: this.seleccionado.Apellidos
		};
		this.entidadForm.controls['PersonaId'].setValue(this.seleccionado.PersonaId);
	}

	eliminar(fila: number) {
		super.eliminar(fila);
		this.persona = {
			Identificacion: this.seleccionado.Identificacion,
			Nombres: this.seleccionado.Nombres,
			Apellidos: this.seleccionado.Apellidos
		};
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		this.subscripcion.unsubscribe();
	}

}
