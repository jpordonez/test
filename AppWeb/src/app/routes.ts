import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoreRoutes } from 'app/core/core.routes';
import { AuthGuard } from 'app/core/seguridad/filtros/AuthGuard';
import { PrincipalComponent } from 'app/principal/principal.component';
import { RutasPublicas } from 'app/publico/routes';
import { RutasSeguras } from 'app/seguro/routes';

import { PublicoComponent } from './disenios/publico/publico.component';
import { SeguroComponent } from './disenios/seguro/seguro.component';

const appRoutes: Routes = [
    /* Las rutas se resuelven secuencialmente */
    {
        path: '',
        component: PrincipalComponent
    },
    {
        path: '',
        component: PublicoComponent,
        data: { title: 'Vistas Publicas' },
        children: RutasPublicas
    },
    {
        path: '',
        component: SeguroComponent,
        //loadChildren: '',
        canActivate: [AuthGuard],
        data: { title: 'Vistas Seguras' },
        children: RutasSeguras
    },
    {
        path: '',
        component: SeguroComponent,
        //loadChildren: '',
        canActivate: [AuthGuard],
        data: { title: 'Vistas Core' },
        children: CoreRoutes
    },
    {
        path: '**',
        component: PrincipalComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
