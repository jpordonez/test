export class Util {
    static getNombreClase(instancia: any) {
        var funcNameRegex = /function (.{1,})\(/;
        var results = (funcNameRegex).exec((<any>instancia).constructor.toString());
        return (results && results.length > 1) ? results[1] : "";
    }

    static redondear(valor: number, numeroDecimales: number) {
        return Number(Math.round(Number(valor + 'e' + numeroDecimales)) + 'e-' + numeroDecimales);
    }

    static utcStringToFechaLocal(fechaUTCString: string) {
        let temporal = new Date(fechaUTCString);
        let fechaUniversal = Date.UTC(temporal.getFullYear(),
            temporal.getMonth(),
            temporal.getDate(),
            temporal.getHours(),
            temporal.getMinutes(),
            temporal.getSeconds());
        return new Date(fechaUniversal);
    }

    static parseInt(value: any) {
        return isNaN(value) ? 0 : value;
    }

}