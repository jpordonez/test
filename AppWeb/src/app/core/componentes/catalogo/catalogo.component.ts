import { Component, OnInit, OnDestroy } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { UtilityService } from '../../services/utility.service';
import { Alerta } from '../../nucleo/modelo/Alerta';
import {CatalogoService} from '../../nucleo/servicios/catalogo/catalogo.service';
import {ItemService} from '../../nucleo/servicios/catalogo/item.service';
import {Accion} from '../../nucleo/enums/accion.enum';
import {MenuItem} from 'primeng/primeng';
import {BaseCrudPaginaBuscador} from '../../nucleo/controladores/base-crud-pagina-buscador';
import {Validaciones} from '../../nucleo/validaciones/validaciones';
import { Subscription }   from 'rxjs/Subscription';
import { Peticion }    from '../../nucleo/modelo/peticion';
import {EventoAccion} from '../../nucleo/modelo/evento-accion';
import { ItemComponent } from './item/item.component';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent extends BaseCrudPaginaBuscador implements OnInit, OnDestroy {

	private subscripcion: Subscription;

	constructor(private fb: FormBuilder,				
				private catalogoService: CatalogoService,
				private itemService: ItemService,
				private utilityService: UtilityService)
	{
		super(catalogoService);
		//Suscribir a notificaciones de item
		this.subscripcion = catalogoService.respuesta$.subscribe(
		respuesta => {
			let emisor = respuesta.emisor;
			switch (emisor) {
				case 'CATALOGOITEM1':
					this.seleccionado.Items = [];
		            for (var i = 0; i < respuesta.data.length; i++) {
		                this.seleccionado.Items.push(respuesta.data[i]);
		            }					
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
	        Descripcion : new FormControl('', [Validators.required,Validaciones.Descripcion]),
	        Items : new FormControl('', [])         
	    });
		this.alertaEntidad = {
            titulo : "Catalogo",
            mensaje : "",
            esVisible : false,
            esBloquear : false
        };        
		this.indiceSeleccionado = -1;
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
        peticion.emisor = 'CATALOGOITEM1';
        peticion.receptor = ItemComponent.name;
		this.catalogoService.notificarPeticion(peticion);		
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
        peticion.emisor = 'CATALOGOITEM1';
        peticion.receptor = ItemComponent.name;
		this.catalogoService.notificarPeticion(peticion);
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
        peticion.emisor = 'CATALOGOITEM1';
        peticion.receptor = ItemComponent.name;
		this.catalogoService.notificarPeticion(peticion);
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
        peticion.emisor = 'CATALOGOITEM1';
        peticion.receptor = ItemComponent.name;
		this.catalogoService.notificarPeticion(peticion);
	}

	ngOnDestroy() {
		// prevent memory leak when component destroyed
		this.subscripcion.unsubscribe();
	}

}
