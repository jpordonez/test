import { Injectable } from '@angular/core';
import {Message} from 'primeng/primeng';

@Injectable()
export class NotificationService {

     msgs: Message[] = [];

    constructor() {
         
    }

    printSuccessMessage(message: string) {
        console.log(message);
         this.msgs.push({severity:'info', summary:'Mensaje Informativo', detail:message});
    }

    printErrorMessage(message: string) {
        this.msgs.push({severity:'error', summary:'Mensaje Informativo', detail:message});
    }

    printConfirmationDialog(message: string, okCallback: () => any) {
       /* this._notifier.confirm(message, function (e) {
            if (e) {
                okCallback();
            } else {
            }
        });*/
    }
}