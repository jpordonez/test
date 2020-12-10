export class Imagen {
    
    public static ImagenBlanca: string = 'data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==';

    static cambiarTamanioImagen(img, MAX_WIDTH: number = 100, MAX_HEIGHT: number = 100) {
        var canvas = document.createElement("canvas");

        var width = img.width;
        var height = img.height;

        if (width > height) {
            if (width > MAX_WIDTH) {
                height *= MAX_WIDTH / width;
                width = MAX_WIDTH;
            }
        } else {
            if (height > MAX_HEIGHT) {
                width *= MAX_HEIGHT / height;
                height = MAX_HEIGHT;
            }
        }
        canvas.width = width;
        canvas.height = height;
        var ctx = canvas.getContext("2d");

        ctx.drawImage(img, 0, 0, width, height);

        var dataUrl = canvas.toDataURL('image/jpeg');
        // IMPORTANT: 'jpeg' NOT 'jpg'
        return dataUrl
    }

    static getImagenBlanca() {        
        return Imagen.ImagenBlanca;
    }

}