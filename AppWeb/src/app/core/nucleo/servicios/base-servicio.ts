import { Subject } from 'rxjs/Subject';
import { IRecurso } from 'app/core/nucleo/recursos/IRecurso';
import { Peticion } from 'app/core/nucleo/modelo/peticion';
import { Respuesta } from 'app/core/nucleo/modelo/respuesta';

export abstract class BaseServicio {

    public datosInicio: any;
    public promesaDatosInicio: Promise<any>;

    constructor(private iRecurso: IRecurso) {
    }

    listar(criteria: any): Promise<any> {
        return (this.iRecurso as any).listar(criteria);
    }

    get(entidad: any): Promise<any> {
        return (this.iRecurso as any).get(entidad);
    }

    crear(entidad: any): Promise<any> {
        return (this.iRecurso as any).crear(entidad);
    }

    editar(entidad: any): Promise<any> {
        return (this.iRecurso as any).editar(entidad);
    }

    eliminar(entidad: any): Promise<any> {
        return (this.iRecurso as any).eliminar(entidad);
    }

    getDatosInicio(): Promise<any> {
        return (this.iRecurso as any).getDatosInicio();
    }

    limpiarCache() {
        this.promesaDatosInicio = null;
        this.datosInicio = null;
    }

    // Observables - Solo deberia suscribirse el componente que será llamado
    private observablePeticion = new Subject<Peticion>();
    peticion$ = this.observablePeticion.asObservable();

    notificarPeticion(peticion: Peticion) {
        if (peticion.receptor) {
            if (peticion.emisor) {
                this.observablePeticion.next(peticion);
            } else {
                console.error('Se debe indicar un codigo para el destinatario que receptara la respuesta, -emisor-');
                return;
            }
        } else {
            console.error('Se debe indicar el nombre del componente que procesará la peticion, -receptor-');
            return;
        }
    }

    // Observables - Deberían suscribirse los componentes que realizan
    // la utilizacion de algun componente que ha registrado la espera de respuestas
    private observableRespuesta = new Subject<Respuesta>();
    respuesta$ = this.observableRespuesta.asObservable();

    notificarRespuesta(respuesta: Respuesta) {
        this.observableRespuesta.next(respuesta);
    }

}
