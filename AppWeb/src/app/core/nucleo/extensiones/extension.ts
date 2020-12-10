//Agregar metodos a los tipos Nativos JavaScript
Number.prototype.padLeft = function (numeroDigitos: number, caracterIzquierda: string): string {
    return Array(numeroDigitos - String(this).length + 1).join(caracterIzquierda || '0') + this;
};

Number.prototype.truncar = function (numeroDecimales: number): number {
    var re = new RegExp("(\\d+\\.\\d{" + numeroDecimales + "})(\\d)"),
        m = this.toString().match(re);
    return m ? parseFloat(m[1]) : this.valueOf();
};

String.prototype.padLeft = function (numeroDigitos: number, caracterIzquierda: string): string {
    return Array(numeroDigitos - this.length + 1).join(caracterIzquierda || '0') + this;
};

Array.prototype.agregar = function (objeto: any): Array<any> {
    let lista: any[] = [];
    for (var i = 0; i < this.length; i++) {
        lista.push(this[i]);
    }
    lista.push(objeto);
    return lista;
};

Array.prototype.eliminar = function (indice: number): Array<any> {
    let lista: any[] = [];
    for (var i = 0; i < this.length; i++) {
        lista.push(this[i]);
    }
    lista.splice(indice, 1);
    return lista;
};

Array.prototype.suma = function (propiedad: string): number {
    let total: number = 0;
    for (var i = 0; i < this.length; i++) {
        total += this[i][propiedad];
    }
    return total;
};

Date.prototype.toStringSoloFecha = function (): string {
    let dia = this.getDate();
    let mes = this.getMonth();
    let anio = this.getFullYear();
    let fecha = new Date(Date.UTC(anio, mes, dia, 0, 0, 0));
    return fecha.toISOString();
};