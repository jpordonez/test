import { Mayusculas } from './nucleo/directivas/mayusculas';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ElmahComponente } from './componentes/elmah/elmah';
import { SistemaComponent } from './componentes/sistema/sistema.component';
import { PersonaComponent } from './componentes/persona/persona.component';
import { CatalogoComponent } from './componentes/catalogo/catalogo.component';
import { ItemComponent } from './componentes/catalogo/item/item.component';
import { ParametroComponent } from './componentes/parametro/parametro.component';
import { RolComponent } from './componentes/rol/rol.component';
import { SesionComponent } from './componentes/sesion/sesion.component';
import { AuditoriaComponent } from './componentes/auditoria/auditoria.component';
import { UsuarioComponent } from './componentes/usuario/usuario.component';
import { InstitucionComponent } from './componentes/institucion/institucion.component';

/*Buscadores*/
import { BuscadorPersonaComponent } from './componentes/persona/buscador/buscador.component';
import { BuscadorInstitucionComponent } from './componentes/institucion/buscador/buscador.component';

//Servicios
import { UsuarioService } from './nucleo/servicios/usuario/usuario.service';
import { ParametroService } from './nucleo/servicios/parametro/parametro.service';
import { RolService } from './nucleo/servicios/rol/rol.service';
import { SesionService } from './nucleo/servicios/sesion/sesion.service';
import { AuditoriaService } from './nucleo/servicios/auditoria/auditoria.service';
import { InstitucionService } from './nucleo/servicios/institucion/institucion.service';
import { PersonaService } from './nucleo/servicios/persona/persona.service';
import { CatalogoService } from './nucleo/servicios/catalogo/catalogo.service';
import { ItemService } from './nucleo/servicios/catalogo/item.service';
import { FuncionalidadService } from './nucleo/servicios/funcionalidad/funcionalidad.service';
import { MenuService } from './nucleo/servicios/menu/menu.service';
import { BuscadorInstitucionService } from './nucleo/servicios/institucion/buscador.service';
import { BuscadorPersonaService } from './nucleo/servicios/persona/buscador.service';

import {
  CalendarModule, DataTableModule, SharedModule, InputMaskModule, DialogModule, PanelModule, MenuModule,
  TabViewModule, ButtonModule, TieredMenuModule, GrowlModule, InputTextareaModule, ListboxModule, CheckboxModule,
  DropdownModule, ChartModule, ScheduleModule, StepsModule, SplitButtonModule, AutoCompleteModule,
  FieldsetModule, TooltipModule, BlockUIModule, MultiSelectModule, RadioButtonModule,
  GalleriaModule, FileUploadModule, InputTextModule
} from 'primeng/primeng';

import { BoolToCadenaPipe } from './nucleo/pipes/bool-to-cadena/bool-to-cadena.pipe';
import { CapitalizarPipe } from './nucleo/pipes/capitalizar/capitalizar.pipe';
import { MenuComponent } from './componentes/menu/menu.component';
import { FuncionalidadComponent } from './componentes/funcionalidad/funcionalidad.component';
import { MenuItemComponent } from './componentes/menu/menu-item/menu-item.component';
import { Minusculas } from "app/core/nucleo/directivas/minusculas";
import { Control } from "app/core/nucleo/directivas/control";
import { BloquearTipeoInvalido } from 'app/core/nucleo/directivas/bloqueartipeoinvalido';
import { TabViewService } from 'app/core/controles/tabview/tabview.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,    
    //third-party PRIMENG
    CalendarModule, DataTableModule, SharedModule, InputMaskModule, DialogModule, PanelModule, MenuModule,
    TabViewModule, ButtonModule, TieredMenuModule, GrowlModule, InputTextareaModule, ListboxModule,
    CheckboxModule, DropdownModule, ChartModule, ScheduleModule, StepsModule, SplitButtonModule,
    AutoCompleteModule, FieldsetModule, TooltipModule, BlockUIModule, MultiSelectModule,
    RadioButtonModule, GalleriaModule, FileUploadModule, InputTextModule
  ],
  declarations: [
    //Componentes
    ElmahComponente,
    SistemaComponent,
    PersonaComponent,
    CatalogoComponent,
    ItemComponent,
    ParametroComponent,
    RolComponent,
    SesionComponent,
    AuditoriaComponent,
    UsuarioComponent,
    InstitucionComponent,
    MenuComponent,
    MenuItemComponent,
    FuncionalidadComponent,
    //Buscadores
    BuscadorPersonaComponent,
    BuscadorInstitucionComponent,
    //Pipes
    BoolToCadenaPipe,
    CapitalizarPipe,
    //Directivas
    Minusculas,
    Mayusculas,
    BloquearTipeoInvalido,
    Control    

  ],
  //Para exportar el buscador de Personas al importar el core modulo en otros modulos
  exports: [
    BuscadorPersonaComponent,
    BuscadorInstitucionComponent,
    //Pipes
    BoolToCadenaPipe,
    CapitalizarPipe,
    //Directivas
    Minusculas,
    Mayusculas,
    BloquearTipeoInvalido,
    Control
  ],
  //Puedo inyectar en cualquier modulo que importe CoreModule
  //no es necesario definir estos provedores en los modulos que los importen.
  providers: [
    UsuarioService,
    ParametroService,
    RolService,
    SesionService,
    AuditoriaService,
    InstitucionService,
    PersonaService,
    BuscadorInstitucionService,
    BuscadorPersonaService,
    CatalogoService,
    ItemService,
    FuncionalidadService,
    MenuService,
    
    //Controles
    TabViewService
  ]
})
export class CoreModule { }
