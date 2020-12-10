import { Component } from '@angular/core';
//import {HTTP_PROVIDERS} from '@angular/http';
//import {InputText,DataTable,Button,Dialog,Column,Header,Footer} from 'primeng/primeng';
import { Excepcion } from '../../nucleo/modelo/Excepcion';
import { AplicacionServicio } from '../../seguridad/servicio/AplicacionServicio';

@Component({
    templateUrl: './elmah.html',
    selector: 'my-app',
    //directives: [InputText,DataTable,Button,Dialog,Column,Header,Footer],
    providers: [AplicacionServicio]
})
export class ElmahComponente {

    displayDialog: boolean;

    car: Excepcion = new Excepcion();

    selectedCar: Excepcion;

    newCar: boolean;

    cars: Excepcion[];

    constructor(private carService: AplicacionServicio) { }

    ngOnInit() {
        let resultado = this.carService.getCarsMedium();
        resultado
            .then(
                (res: any) => {
                    this.cars = res;
                }
            )
            .catch((error: any) => {

            });
    }

    showDialogToAdd() {
        this.newCar = true;
        this.car = new Excepcion();
        this.displayDialog = true;
    }

    onRowSelect(event) {
        this.newCar = false;
        this.car = this.cloneCar(event.data);
        this.displayDialog = true;
    }

    cloneCar(c: Excepcion): Excepcion {
        let car = new Excepcion();
        for (let prop in c) {
            car[prop] = c[prop];
        }
        return car;
    }

    findSelectedCarIndex(): number {
        return this.cars.indexOf(this.selectedCar);
    }
}
