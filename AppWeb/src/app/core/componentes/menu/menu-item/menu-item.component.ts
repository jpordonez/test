import { Component, OnInit } from "@angular/core";
import { BaseCrud } from "app/core/nucleo/controladores/base-crud";
import { SelectItem } from "primeng/primeng";
import { FormBuilder, FormControl, Validators } from "@angular/forms";
import { MenuService } from "app/core/nucleo/servicios/menu/menu.service";
import { Validaciones } from "app/core/nucleo/validaciones/validaciones";
import { EventoAccion } from "app/core/nucleo/modelo/evento-accion";
import { Peticion } from "app/core/nucleo/modelo/peticion";

@Component({
	selector: 'menu-item',
	templateUrl: './menu-item.component.html',
	styleUrls: ['./menu-item.component.css']
})
export class MenuItemComponent extends BaseCrud implements OnInit {

	public estados: SelectItem[];
	public tipos: SelectItem[];
	public menusPadre: any[];
	public funcionalidades: SelectItem[];

	constructor(public fb: FormBuilder,
		private menuService: MenuService) {
		super(menuService);
	}

	ngOnInit() {
		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			Codigo: new FormControl('', [Validators.required, Validaciones.Codigo]),
			Nombre: new FormControl('', [Validators.required, Validaciones.NombreEspecial]),
			Descripcion: new FormControl('', [Validaciones.Descripcion]),
			Url: new FormControl('', [Validators.required]),
			EstadoId: new FormControl('', [Validators.required]),
			TipoId: new FormControl('', [Validators.required]),
			PadreCodigo: new FormControl('', []),
			FuncionalidadId: new FormControl('', []),
			Orden: new FormControl('', [Validators.required]),
			Icono: new FormControl('', [])
		});
		this.alertaEntidad = {
			titulo: "Item",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};

		var resultado = this.menuService.getDatosInicio();
		resultado
			.then(
				(res: any) => {
					this.estados = [];
					this.estados.push({ label: 'Seleccione', value: null });
					this.estados = this.estados.concat(res.ests);
					this.tipos = [];
					this.tipos.push({ label: 'Seleccione', value: null });
					this.tipos = this.tipos.concat(res.tiposItemMenu);
					this.funcionalidades = [];
					this.funcionalidades.push({ label: 'Seleccione', value: null });
					this.funcionalidades = this.funcionalidades.concat(res.funcionalidads);
				}
			);
	}

	procesarAccion(peticion: Peticion) {
		let evento: EventoAccion = peticion.data.evento;
		let menusItems = evento.lista;
		this.menusPadre = [];
		this.menusPadre.push({ label: 'Seleccione', value: null });
		for (var i = 0; i < menusItems.length; i++) {
			let menu = {
				value: menusItems[i].Codigo,
				label: menusItems[i].Nombre
			};
			this.menusPadre.push(menu);
		}
		super.procesarAccion(peticion);
	}

	guardar() {
		let padreCodigo = this.entidadForm.controls['PadreCodigo'].value;
		let tipoId = this.entidadForm.controls['TipoId'].value;
		if (padreCodigo != null && tipoId == 1) {
			this.utilService.mostrarMensaje('El item de menú no puede ser de tipo contenedor,<BR/> solo se permiten dos niveles.');
			return;
		}

		let estadoId = this.entidadForm.controls['EstadoId'].value;
		let estadoNombre = this.estados.filter(e => e.value == estadoId)[0].label;
		let tipoNombre = this.tipos.filter(t => t.value == tipoId)[0].label;
		let menuPadreNombre = padreCodigo != null ? this.menusPadre.filter(t => t.value == padreCodigo)[0].label : '';
		let funcionalidadId = this.entidadForm.controls['FuncionalidadId'].value;
		let funcionalidadNombre = funcionalidadId != null ? this.funcionalidades.filter(t => t.value == funcionalidadId)[0].label : '';

		this.seleccionado.EstadoNombre = estadoNombre;
		this.seleccionado.TipoNombre = tipoNombre;
		this.seleccionado.MenuPadreNombre = menuPadreNombre;
		this.seleccionado.FuncionalidadNombre = funcionalidadNombre;

		super.guardar();

	}

}
