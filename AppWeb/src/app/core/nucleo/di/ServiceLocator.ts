import { Injector, Type, InjectionToken } from "@angular/core";

export class ServiceLocator {
    private static _injector: Injector;

    /*static get<T>(token: Type<T> | InjectionToken<T>, notFoundValue?: T): T {
        return this._injector.get(token, notFoundValue);
    }*/

    static get(token: any, notFoundValue?: any): any {
        return this._injector.get(token, notFoundValue);
    }

    static setInjector(injector: Injector) {
        this._injector = injector;
    }

}