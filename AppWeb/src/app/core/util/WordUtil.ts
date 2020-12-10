var JSZip = require('jszip');
var Docxtemplater = require('docxtemplater');
var JSZipUtils = require('jszip-utils');

export class WordUtil {

    //The angular-parser makes creating complex templates easier.
    //{user.name}
    private static angularParser = (tag) => {
        return {
            get: tag === '.' ? function (s) { return s; } : function (s) {
                return eval('s.' + tag.replace(/’/g, "'"));
                //return expressions.compile(tag.replace(/’/g, "'"))(s);
            }
        };
    }

    public static Generar(rutaPlantilla: string, modelo: any): Promise<any> {
        let promesa = new Promise((resolve, reject) => {
            this.loadFile(rutaPlantilla, (error, content) => {
                if (error) {
                    reject(error);
                };
                var zip = new JSZip(content);
                var doc = new Docxtemplater().loadZip(zip).setOptions({ parser: WordUtil.angularParser });
                doc.setData(modelo);

                try {
                    // render the document (replace all occurences of {first_name} by John, {last_name} by Doe, ...)
                    doc.render();
                }
                catch (error) {
                    var e = {
                        message: error.message,
                        name: error.name,
                        stack: error.stack,
                        properties: error.properties,
                    };
                    reject(error);
                }

                var out = doc.getZip().generate({
                    type: "blob",
                    mimeType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                }); //Output the document using Data-URI
                resolve(out);
            });
        });

        return promesa;
    }

    private static loadFile(url, callback) {
        JSZipUtils.getBinaryContent(url, callback);
    }

}