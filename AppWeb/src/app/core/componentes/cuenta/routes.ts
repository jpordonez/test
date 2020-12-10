import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountComponent } from './account.component';
import { LoginComponent } from './login';
import { SeleccionarRolComponent } from './seleccionar-rol/seleccionar-rol.component';

export const accountRoutes: Routes = [
    {
        path: 'cuenta',
        component: AccountComponent,
        children: [
            { path: 'login', component: LoginComponent },
            { path: 'seleccionar_rol', component: SeleccionarRolComponent }            
        ]
    }
];

export const accountRouting: ModuleWithProviders = RouterModule.forChild(accountRoutes);