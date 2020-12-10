import { Routes } from '@angular/router';

import { AuditoriaComponent } from './componentes/auditoria/auditoria.component';
import { CatalogoComponent } from './componentes/catalogo/catalogo.component';
import { ElmahComponente } from './componentes/elmah/elmah';
import { FuncionalidadComponent } from './componentes/funcionalidad/funcionalidad.component';
import { InstitucionComponent } from './componentes/institucion/institucion.component';
import { MenuComponent } from './componentes/menu/menu.component';
import { ParametroComponent } from './componentes/parametro/parametro.component';
import { PersonaComponent } from './componentes/persona/persona.component';
import { RolComponent } from './componentes/rol/rol.component';
import { SesionComponent } from './componentes/sesion/sesion.component';
import { SistemaComponent } from './componentes/sistema/sistema.component';
import { UsuarioComponent } from './componentes/usuario/usuario.component';

export const CoreRoutes: Routes = [    
    {
        path: 'usuario',
        component: UsuarioComponent
    },
    {
        path: 'parametrosistema',
        component: ParametroComponent
    },
    {
        path: 'rol',
        component: RolComponent
    },
    {
        path: 'sesion',
        component: SesionComponent
    },
    {
        path: 'auditoria',
        component: AuditoriaComponent
    },
    {
        path: 'institucion',
        component: InstitucionComponent
    },
    {
        path: 'elmah',
        component: ElmahComponente
    },
    {
        path: 'sistema',
        component: SistemaComponent
    },
    {
        path: 'persona',
        component: PersonaComponent
    },    
    {
        path: 'catalogo',
        component: CatalogoComponent
    },    
    {
        path: 'funcionalidad',
        component: FuncionalidadComponent
    },    
    {
        path: 'menu',
        component: MenuComponent
    }
];

//export const CoreRoutes: ModuleWithProviders = RouterModule.forChild(coreRoutes);