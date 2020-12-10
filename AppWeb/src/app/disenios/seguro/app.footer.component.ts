import {Component,Inject,forwardRef} from '@angular/core';

@Component({
    selector: 'app-footer',
    template: `
        <div class="footer">
            <div class="card clearfix">
                <span class="footer-text-right"><span class="ui-icon ui-icon-copyright"></span>  <span>Copyright © 2017, jpordonez Cia Ltda.</span></span>
            </div>
        </div>
    `
})
export class AppFooter {

}
