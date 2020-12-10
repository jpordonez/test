import { Component, OnInit, OnDestroy } from '@angular/core';
import {BaseCrudPaginaBuscador} from '../../nucleo/controladores/base-crud-pagina-buscador';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { UtilityService } from '../../services/utility.service';
import {Validaciones} from '../../nucleo/validaciones/validaciones';
import { Alerta } from '../../nucleo/modelo/Alerta';
import {Accion} from '../../nucleo/enums/accion.enum';
import { Subscription }   from 'rxjs/Subscription';
import {MenuService} from '../../nucleo/servicios/menu/menu.service';
import { Peticion }    from '../../nucleo/modelo/peticion';
import {EventoAccion} from '../../nucleo/modelo/evento-accion';
import {MenuItemComponent} from './menu-item/menu-item.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent extends BaseCrudPaginaBuscador implements OnInit, OnDestroy {

	private subscripcion: Subscription;

	constructor(private fb: FormBuilder,				
				private menuService: MenuService,
				private utilityService: UtilityService) { 
		super(menuService);
		//Suscribir a notificaciones de MenuItems
		this.subscripcion = menuService.respuesta$.subscribe(
		respuesta => {
			let emisor = respuesta.emisor;
			switch (emisor) {
				case 'MENUITEM1':
					//Clono el array para que angular detecte el cambio mediante set
					//sin clonar no se considera el cambio en el modelo
					this.seleccionado.Items = respuesta.data.slice(0);
					break;				
				default:
					// code...
					break;
			}		
		});
	}

	ngOnInit() {
		this.criteriaForm = this.fb.group({
	        Nombre : new FormControl('', []),         
	    });
	    this.entidadForm = this.fb.group({	
	    	Id : new FormControl('', []),    
	        Codigo : new FormControl('', [Validators.required,Validaciones.Codigo]),   
	        Nombre : new FormControl('', [Validators.required,Validaciones.NombreEspecial]),
	        Descripcion : new FormControl('', [Validaciones.Descripcion]),
	        Items : new FormControl('', [])         
	    });	    
		this.alertaEntidad = {
            titulo : "Menu",
            mensaje : "",
            esVisible : false,
            esBloquear : false
        };
	}
	
	guardar(){
		this.entidadForm.controls['Items'].setValue(this.seleccionado.Items);
		super.guardar();
	}

	nuevo(){		
		super.nuevo();
		this.seleccionado = {};
		this.seleccionado.Items = [];
	}		

	nuevoItem(){
		var evento = new EventoAccion();
		evento.lista = this.seleccionado.Items;
		evento.accion = Accion.CREAR;
		evento.indice = -1;
		let peticion = new Peticion();
        peticion.data = 
        {
            evento:evento
        };
        peticion.emisor = 'MENUITEM1';
        peticion.receptor = MenuItemComponent.name;
		this.menuService.notificarPeticion(peticion);		
	}

	editarItem(fila:number){
		var evento = new EventoAccion();
		evento.lista = this.seleccionado.Items;
		evento.accion = Accion.EDITAR;
		evento.indice = fila;
		let peticion = new Peticion();
        peticion.data = 
        {
            evento:evento
        };
        peticion.emisor = 'MENUITEM1';
        peticion.receptor = MenuItemComponent.name;
		this.menuService.notificarPeticion(peticion);
	}

	visualizarItem(fila:number){
		var evento = new EventoAccion();
		evento.lista = this.seleccionado.Items;
		evento.accion = Accion.VISUALIZAR;
		evento.indice = fila;
		let peticion = new Peticion();
        peticion.data = 
        {
            evento:evento
        };
        peticion.emisor = 'MENUITEM1';
        peticion.receptor = MenuItemComponent.name;
		this.menuService.notificarPeticion(peticion);
	}

	eliminarItem(fila:number){
		var evento = new EventoAccion();
		evento.lista = this.seleccionado.Items;
		evento.accion = Accion.ELIMINAR;
		evento.indice = fila;
		let peticion = new Peticion();
        peticion.data = 
        {
            evento:evento
        };
        peticion.emisor = 'MENUITEM1';
        peticion.receptor = MenuItemComponent.name;
		this.menuService.notificarPeticion(peticion);
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		this.subscripcion.unsubscribe();
	}

}
