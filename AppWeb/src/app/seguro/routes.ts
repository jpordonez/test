import { AsignacionDocenteComponent } from './../componentes/negocio/asignacion-docente/asignacion-docente.component';
import { MatriculaComponent } from './../componentes/negocio/matricula/matricula.component';
import { ComponenteEducativoComponent } from './../componentes/negocio/componente-educativo/componente-educativo.component';
import { Routes } from '@angular/router';
import { InicioComponente } from 'app/componentes/inicio';
import { PerfilComponent } from 'app/componentes/owner/perfil/perfil.component';
import { ResultadoComponent } from 'app/componentes/negocio/resultado/resultado.component';


export const RutasSeguras: Routes = [
    {
        path: 'inicio',
        component: InicioComponente
    },
    {
        path: 'perfil',
        component: PerfilComponent
    },
    {
        path: 'componente-educativo',
        component: ComponenteEducativoComponent
    },
    {
        path: 'matricula',
        component: MatriculaComponent
    },
    {
        path: 'resultado',
        component: ResultadoComponent
    },
    {
        path: 'asignacion-docente',
        component: AsignacionDocenteComponent
    }

];
