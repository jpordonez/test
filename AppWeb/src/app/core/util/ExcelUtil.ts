import { write, utils, read, IWorkBook, IProperties } from 'ts-xlsx';
import { Hoja } from "app/core/nucleo/modelo/Excel/Hoja";
import { saveAs } from "file-saver";

export class ExcelUtil {

    public static crearYDescargar(hojas: Hoja[], nombreArchivo: string) {
        var wb = new Workbook();

        hojas.forEach(hoja => {

            var data = new Array;
            hoja.data.forEach(function (row, index) {
                var each = new Array;
                var keys = hoja.cabeceras ? hoja.cabeceras.map(function (nc) { return nc.clave; }) : Object.keys(row); // all the keys
                if (index == 0) {
                    // column headers
                    for (var i = 0; i < keys.length; i++) {
                        each.push(hoja.cabeceras ? hoja.cabeceras
                            .filter(nc => nc.clave === keys[i])
                            .map(function (nc) { return nc.valor; })[0] : keys[i]);
                    }
                    data.push(each); // write header
                    each = [];
                    for (var i = 0; i < keys.length; i++) {
                        each.push(row[keys[i]]);
                    }
                }
                else {
                    for (var i = 0; i < keys.length; i++) {
                        each.push(row[keys[i]]);
                    }
                }
                data.push(each);
            }, this);

            var ws_name = hoja.nombre;
            wb.SheetNames.push(ws_name);
            wb.Sheets[ws_name] = this.sheet_from_array_of_arrays(data);
        });

        var wbout = write(wb, { bookType: 'xlsx', type: 'binary' }); //bookSST: true,
        saveAs(new Blob([this.s2ab(wbout)], { type: "application/octet-stream" }), nombreArchivo + ".xlsx");
    }


    private static s2ab(s) {
        var buf = new ArrayBuffer(s.length);
        var view = new Uint8Array(buf);
        for (var i = 0; i != s.length; ++i) view[i] = s.charCodeAt(i) & 0xFF;
        return buf;
    }

    private static sheet_from_array_of_arrays(data: any, opts?: any): any {
        var ws: any = {};

        var wscols = [
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 },
            { wch: 20 }
        ];

        var startCell = { c: 10000000, r: 10000000 };
        var endCell = { c: 0, r: 0 };

        var range = { s: startCell, e: endCell };
        for (var R = 0; R != data.length; ++R) {
            for (var C = 0; C != data[R].length; ++C) {
                if (range.s.r > R) range.s.r = R;
                if (range.s.c > C) range.s.c = C;
                if (range.e.r < R) range.e.r = R;
                if (range.e.c < C) range.e.c = C;
                //var cell = { v: data[R][C], t: 'n' };
                //if (cell.v == null) continue;
                //var cell_ref = XLSX.utils.encode_cell({ c: C, r: R });

                //if (typeof cell.v === 'number') cell.t = 'n';
                //else if (typeof cell.v === 'boolean') cell.t = 'b';
                //else cell.t = 's';

                //var cell = new Cell();
                var cell: any = {};
                cell.v = data[R][C];
                //console.log(cell);
                var cell_ref = utils.encode_cell({ c: C, r: R });
                //console.log(cell_ref);
                if (cell.v == null) continue;
                if (typeof cell.v === 'number') cell.t = 'n';
                else if (typeof cell.v === 'boolean') cell.t = 'b';
                else cell.t = 's';
                //console.log(cell);
                ws[cell_ref] = cell;
                //console.log(ws);
            }
        }
        if (range.s.c < 10000000) ws['!ref'] = utils.encode_range(startCell, endCell);
        ws['!cols'] = wscols;
        return ws;
    }

}

class Workbook implements IWorkBook {
    Props: IProperties;
    SheetNames: any = [];
    Sheets: any = {};
}