import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormControl } from '@angular/forms';
import { BaseCrud } from 'app/core/nucleo/controladores/base-crud';
import { CatalogoService } from 'app/core/nucleo/servicios/catalogo/catalogo.service';
import { Validaciones } from 'app/core/nucleo/validaciones/validaciones';

@Component({
	selector: 'item-catalogo',
	templateUrl: './item.component.html',
	styleUrls: ['./item.component.css']
})
export class ItemComponent extends BaseCrud implements OnInit {

	constructor(public fb: FormBuilder,
		private catalogoService: CatalogoService) {
		super(catalogoService);
	}

	ngOnInit() {
		this.entidadForm = this.fb.group({
			Id: new FormControl('', []),
			CatalogoId: new FormControl('', []),
			CatalogoCodigo: new FormControl('', []),
			Codigo: new FormControl('', [Validators.required, Validaciones.Codigo]),
			Nombre: new FormControl('', [Validators.required, Validaciones.NombreEspecial]),
			Descripcion: new FormControl('', [Validators.required, Validaciones.Descripcion])
		});
		this.alertaEntidad = {
			titulo: "Item",
			mensaje: "",
			esVisible: false,
			esBloquear: false
		};
	}

	guardar() {
		//Fijar validaciones y propiedades antes de notificar al componente padre el cambio
		var fechaCreacion = new Date();
		//Para agregar propiedades temporales
		this.seleccionado.FechaCreacion = fechaCreacion;
		super.guardar();
	}

}
