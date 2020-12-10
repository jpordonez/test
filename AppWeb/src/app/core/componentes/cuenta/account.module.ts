import { NgModule }       from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule }   from '@angular/common';
import {CalendarModule, DataTableModule, SharedModule, InputMaskModule, DialogModule,PanelModule,MenuModule,
    TabViewModule,ButtonModule,TieredMenuModule,GrowlModule,CheckboxModule,PasswordModule,ListboxModule,
    InputTextModule} from 'primeng/primeng';

import { NotificationService } from '../../services/notification.service';

import { AccountComponent } from './account.component';
import { LoginComponent } from './login';

import { accountRouting } from './routes';
import { SeleccionarRolComponent } from './seleccionar-rol/seleccionar-rol.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        accountRouting,
        //third-party PRIMENG
        CalendarModule,DataTableModule,SharedModule,InputMaskModule,DialogModule,PanelModule,MenuModule,
        TabViewModule,ButtonModule,TieredMenuModule,GrowlModule,CheckboxModule,PasswordModule,ListboxModule,
        InputTextModule
    ],
    declarations: [
        AccountComponent,
        LoginComponent,
        SeleccionarRolComponent
    ],

    providers: [
        NotificationService
    ]
})
export class AccountModule { }