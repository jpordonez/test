import { AsignacionDocenteRecurso } from './recurso/asignacion-docente/AsignacionDocenteRecurso';
import { ResultadoRecurso } from 'app/recurso/resultado/ResultadoRecurso';
import { ResultadoService } from './servicios/resultado/resultado.service';
import { AsignacionDocenteService } from './servicios/asignacion-docente/asignacion-docente.service';
import { ResultadoComponent } from './componentes/negocio/resultado/resultado.component';
import { AsignacionDocenteComponent } from './componentes/negocio/asignacion-docente/asignacion-docente.component';
import { MatriculaRecurso } from './recurso/matricula/MatriculaRecurso';
import { MatriculaService } from './servicios/matricula/matricula.service';
import { MatriculaComponent } from './componentes/negocio/matricula/matricula.component';
import { ComponenteEducativoRecurso } from './recurso/componente-educativo/ComponenteEducativoRecurso';
import { ComponenteEducativoComponent } from './componentes/negocio/componente-educativo/componente-educativo.component';
import { HttpClientModule } from '@angular/common/http';
import { InstitucionRecurso } from './core/nucleo/recursos/institucion/InstitucionRecurso';
import { AuditoriaRecurso } from './core/nucleo/recursos/auditoria/AuditoriaRecurso';
import { SesionRecurso } from './core/nucleo/recursos/sesion/SesionRecurso';
import { RolRecurso } from './core/nucleo/recursos/rol/RolRecurso';
import { PersonaRecurso } from './core/nucleo/recursos/persona/PersonaRecurso';
import { MenuRecurso } from './core/nucleo/recursos/menu/MenuRecurso';
import { FuncionalidadRecurso } from './core/nucleo/recursos/funcionalidad/FuncionalidadRecurso';
import { ParametroRecurso } from './core/nucleo/recursos/parametro/ParametroRecurso';
import { CatalogoRecurso } from './core/nucleo/recursos/catalogo/catalogo-recurso';
import { UsuarioRecurso } from './core/nucleo/recursos/usuario/UsuarioRecurso';
import { NgModule, Injector } from "@angular/core";
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import 'rxjs/Rx';
import { BrowserModule } from '@angular/platform-browser';
import {
    CalendarModule, DataTableModule, SharedModule, InputMaskModule, DialogModule, PanelModule, MenuModule,
    TabViewModule, ButtonModule, TieredMenuModule, GrowlModule, InputTextareaModule, ListboxModule, CheckboxModule,
    DropdownModule, ChartModule, ScheduleModule, StepsModule, SplitButtonModule, AutoCompleteModule,
    FieldsetModule, TooltipModule, BlockUIModule, MultiSelectModule, RadioButtonModule,
    GalleriaModule, FileUploadModule, InputTextModule, EditorModule, GMapModule, ToggleButtonModule, ConfirmationService, ConfirmDialogModule, CaptchaModule, CardModule
} from 'primeng/primeng';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { routing } from './routes';

/*Diseño del sitio*/
import { AppMenuComponent, AppSubMenu } from 'app/disenios/seguro/app.menu.component';
import { AppTopBar } from 'app/disenios/seguro/app.topbar.component';
import { AppFooter } from 'app/disenios/seguro/app.footer.component';
import { InlineProfileComponent } from 'app/disenios/seguro/app.profile.component';
/*Diseño del sitio*/

/*Modulos*/
import { AccountModule } from './core/componentes/cuenta/account.module';
import { CoreModule } from './core/core.module';
/*Modulos*/

/*ServiceLocator*/
import { ServiceLocator } from './core/nucleo/di/ServiceLocator';
/*ServiceLocator*/

import { InicioComponente } from './componentes/inicio';
import { UtilityService } from './core/services/utility.service';
import { NotificationService } from './core/services/notification.service';
import { AplicacionServicio } from './core/seguridad/servicio/AplicacionServicio';

//Servicios Negocio

//Manejo de archivos excel
//import * as alasql from 'alasql';

import { SpinnerComponentModule } from 'ng2-component-spinner';

//Extensiones
import './core/nucleo/extensiones/extension';
import { PrincipalComponent } from './principal/principal.component';
import { AuthGuard } from "app/core/seguridad/filtros/AuthGuard";
import { PerfilComponent } from './componentes/owner/perfil/perfil.component';

import { RecuperacionClaveComponent } from './componentes/owner/recuperacion-clave/recuperacion-clave.component';
import { SeguroComponent } from './disenios/seguro/seguro.component';
import { PublicoComponent } from './disenios/publico/publico.component';
import { ItemRecurso } from "app/core/nucleo/recursos/item/item-recurso";
import { UITabViewModule } from 'app/core/controles/tabview/tabview';
import { ResourceModule } from '@ngx-resource/handler-ngx-http';
import { AplicacionRecurso } from './core/seguridad/recurso/AplicacionRecurso';
import { ComponenteEducativoService } from './servicios/componente-educativo/componente-educativo.service';
import { BuscadorComponenteEducativoComponent } from './componentes/negocio/componente-educativo/buscador/buscador.component';

// AoT requires an exported function for factories
/*export function myHandlerFactory(http: HttpClient) {
    return new MyResourceHandler(http);
}*/

@NgModule({
    // directives, components, and pipes
    declarations: [
        //Diseño del sitio
        AppMenuComponent,
        AppSubMenu,
        AppTopBar,
        AppFooter,
        InlineProfileComponent,

        AppComponent, InicioComponente,

        PrincipalComponent,
        PerfilComponent,
        RecuperacionClaveComponent,
        SeguroComponent,
        PublicoComponent,

        //TEST
        //Componentes
        ComponenteEducativoComponent,
        MatriculaComponent,
        AsignacionDocenteComponent,
        ResultadoComponent,

        //Buscadores
        BuscadorComponenteEducativoComponent

    ],
    // modules
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        routing,
        AccountModule,
        CoreModule,
        BrowserAnimationsModule,
        //third-party PRIMENG
        CalendarModule, DataTableModule, SharedModule, InputMaskModule, DialogModule, PanelModule, MenuModule,
        TabViewModule, ButtonModule, TieredMenuModule, GrowlModule, InputTextareaModule, ListboxModule,
        CheckboxModule, DropdownModule, ChartModule, ScheduleModule, StepsModule, SplitButtonModule,
        AutoCompleteModule, FieldsetModule, TooltipModule, BlockUIModule, MultiSelectModule,
        RadioButtonModule, GalleriaModule, FileUploadModule, InputTextModule, EditorModule, GMapModule,
        ToggleButtonModule, ConfirmDialogModule, CaptchaModule, CardModule,
        // Add module to imports
        SpinnerComponentModule,

        //Recursos rest
        // Default ResourceHandler uses class `ResourceHandlerHttpClient`
        ResourceModule.forRoot(),

        // Or set you own handler
        //ResourceModule.forRoot({
        //  handler: { provide: ResourceHandler, useFactory: (myHandlerFactory), deps: [HttpClient] }
        //})

        //Controles
        UITabViewModule
    ],
    // providers
    providers: [
        UtilityService,
        NotificationService,
        AplicacionServicio,
        AuthGuard,
        ConfirmationService,
        //Recursos
        AplicacionRecurso,
        UsuarioRecurso,
        RolRecurso,
        SesionRecurso,
        AuditoriaRecurso,
        CatalogoRecurso,
        ItemRecurso,
        ParametroRecurso,
        FuncionalidadRecurso,
        MenuRecurso,
        InstitucionRecurso,
        PersonaRecurso,

        //TEST
        ComponenteEducativoService,
        MatriculaService,
        AsignacionDocenteService,
        ResultadoService,

        //TEST
        ComponenteEducativoRecurso,
        MatriculaRecurso,
        AsignacionDocenteRecurso,
        ResultadoRecurso,

        { provide: LocationStrategy, useClass: HashLocationStrategy }
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
    constructor(private injector: Injector) {
        ServiceLocator.setInjector(this.injector);
    }
}

declare global {
    interface Number {
        padLeft(numeroDigitos: number, caracterIzquierda: string): string;
        truncar(numeroDecimales: number): number;
    }
    interface Array<T> {
        agregar(objeto: any): Array<T>;
        eliminar(indice: number): Array<T>;
        suma(propiedad: string): number;
    }
    interface String {
        padLeft(numeroDigitos: number, caracterIzquierda: string): string;
    }

    interface Date {
        toStringSoloFecha(): string;
    }

}
