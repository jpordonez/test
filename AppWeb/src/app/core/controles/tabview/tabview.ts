/**
 * Componente Ui-tabview, basado en primeng p-tabview
 * Created by jpordonez on 2018-04-02.
 */
import {
    Component, OnInit, Input, Output, AfterViewInit, NgModule, EventEmitter, ViewChild,
    Renderer,
    ChangeDetectorRef
} from "@angular/core";
import { CommonModule } from "@angular/common";
import { UITabPanel } from "./tab-panel";
import { TabViewModule } from "primeng/components/tabview/tabview";
import { OverlayPanelModule, MenuModule, TabView } from 'primeng/primeng';
import { AuditoriaComponent } from "app/core/componentes/auditoria/auditoria.component";
import { CatalogoComponent } from "app/core/componentes/catalogo/catalogo.component";
import { Subscription } from 'rxjs/Subscription';
import { TabViewService } from "app/core/controles/tabview/tabview.service";

declare var jQuery: any;

@Component({
    templateUrl: "./tabview.html",
    styleUrls: ["./tabview.scss"],
    selector: "ui-tabview"
})
export class UITabView implements OnInit, AfterViewInit {

    @Input()
    tabs: any[] = [];

    @Input()
    activeIndex: number = 0;

    @Output()
    tabChange: EventEmitter<any> = new EventEmitter<any>();

    @Output()
    tabClose: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('tabRef') tabView: TabView;

    documentClickListener: any;

    items: any = [{
        label: 'Cerrar Actual',
        icon: 'fa-close',
        command: (event) => {
            this.closeCommand(event, 'current')
        }
    }, {
        label: 'Cerrar Todo Izquierda',
        icon: 'fa-close',
        command: (event) => {
            this.closeCommand(event, 'left')
        }
    }, {
        label: 'Cerrar Todo Derecha',
        icon: 'fa-close',
        command: (event) => {
            this.closeCommand(event, 'right')
        }
    }, {
        label: 'Cerrar Restantes',
        icon: 'fa-close',
        command: (event) => {
            this.closeCommand(event, 'other')
        }
    }, {
        label: 'Cerrar Todo',
        icon: 'fa-close',
        command: (event) => {
            this.closeCommand(event, 'all')
        }
    }];

    private subscripcion: Subscription;

    // Hacer clic con el botón derecho en el menú
    private cacheContextClickTarget: any;

    constructor(public renderer: Renderer,
        public tabViewService: TabViewService,
        private cdRef: ChangeDetectorRef
    ) {
        //Suscribir a notificaciones de cambio en tabs
        this.subscripcion = tabViewService.peticion$.subscribe(
            peticion => {
                if (peticion.receptor === this.constructor.name) {
                    this.tabs = peticion.data.tabs;
                    for (var i = 0; i < this.tabs.length; i++) {
                        let tab = this.tabs[i];
                        if (tab.data.selected) {
                            this.activeIndex = i;
                            break;
                        }
                    }                    
                }
            });
    }

    ngOnInit(): void {
    }

    ngAfterViewInit(): void {
        let contextMenu = jQuery('#contextMenu');
        this.documentClickListener = this.renderer.listenGlobal('body', 'click', () => {
            contextMenu.hide();
        });
        jQuery('ul[p-tabviewnav]').bind('contextmenu', (e) => {
            let oe = e.originalEvent;
            let target = oe.target;
            if (target.nodeName === 'SPAN') {
                this.cacheContextClickTarget = jQuery(target);
            } else {
                this.cacheContextClickTarget = jQuery(target).find('span');
            }
            contextMenu.css('left', oe.x);
            contextMenu.css('top', oe.y);
            contextMenu.show();
            e.preventDefault();
        });

    }

    handleChange(e) {
        this.activeIndex = e.index;
        this.tabChange.emit(e);
    }

    handleClose(e) {
        let activeIndex = this.activeIndex;   
        if (this.activeIndex == e.index) {
            activeIndex = e.index - 1;
        } else if (this.activeIndex > e.index) {
            activeIndex = this.activeIndex - 1;
        }
        this.tabs.splice(e.index, 1);
        for (var i = 0; i < this.tabs.length; i++) {
            let tab = this.tabs[i];
            if (activeIndex == i) {
                tab.data.selected = true;
            } else {
                tab.data.selected = false;
            }
        }
        //Para refrescar todos los controles (TabView)        
        this.cdRef.detectChanges();
        //Luego se actualiza el indice para no tener inconsistencias
        //con el tab seleccionado
        this.activeIndex = activeIndex;       
        this.tabClose.emit(e);
    }

    /**
     * Obtener la pestaña seleccionada
     */
    findSelectedTab() {
        return this.tabView.findSelectedTab();
    }

    tabPanelClick(index) {
        this.activeIndex = index;
    }

    /**
     * Bloque borrar etiquetas de pestaña
     * @param $event
     * @param type
     */
    closeCommand($event, type) {
        let text = this.cacheContextClickTarget.html();
        let tabIndex = this.getTabIndexByName(text);
        if (tabIndex === null) {
            return;
        }
        switch (type) {
            case 'current':
                this.tabs.splice(tabIndex, 1);
                break;
            case 'left':
                /*_.remove(this.tabs, function (n, index) {
                    return index < tabIndex;
                });*/
                break;
            case 'right':
                /*_.remove(this.tabs, function (n, index) {
                    return index > tabIndex;
                });*/
                break;
            case 'other':
                /*_.remove(this.tabs, function (n, index) {
                    return index !== tabIndex;
                });*/
                break;
            case 'all':
                this.tabs.length = 0;
                break;
            default:
                break;

        }
        jQuery('#contextMenu').hide();
    }

    /**
     * Pestaña de página 
     * @param name
     * @returns {any}
     */
    getTabIndexByName(name: string) {
        let res = null;
        this.tabs.forEach((tab, index) => {
            if (tab.data && tab.data.name === name) {
                res = index;
            }
        });
        return res;
    }

    ngOnDestroy() {
        if (this.documentClickListener) {
            this.documentClickListener();
        }
        // prevent memory leak when component destroyed
        this.subscripcion.unsubscribe();
    }
}


@NgModule({
    declarations: [
        UITabView,
        UITabPanel,
    ],
    imports: [TabViewModule, CommonModule, OverlayPanelModule, MenuModule],
    exports: [
        UITabView,
        UITabPanel,
    ],
    providers: []
})
export class UITabViewModule {
}
