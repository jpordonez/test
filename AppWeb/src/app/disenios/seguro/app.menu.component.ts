import { Component, Input, OnInit, EventEmitter, ViewChild, trigger, state, transition, style, animate, Inject, forwardRef } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/primeng';
import { SeguroComponent } from "app/disenios/seguro/seguro.component";
import { UtilityService } from "app/core/services/utility.service";
import { TabViewService } from 'app/core/controles/tabview/tabview.service';
import { RutasSeguras } from 'app/seguro/routes';
import { RutasPublicas } from 'app/publico/routes';
import { CoreRoutes } from 'app/core/core.routes';

@Component({
    selector: 'app-menu',
    template: `
        <ul app-submenu [item]="model" root="true" class="ultima-menu ultima-main-menu clearfix" [reset]="reset" visible="true"></ul>
    `
})
export class AppMenuComponent implements OnInit {

    @Input() reset: boolean;

    //model: any[];

    constructor( @Inject(forwardRef(() => SeguroComponent)) public app: SeguroComponent,
        public utilityService: UtilityService) { }

    ngOnInit() {
        /*this.model = [
            {label: 'Dashboard', icon: 'dashboard', routerLink: ['/']},
            {
                label: 'Themes', icon: 'palette',
                items: [
                    {label: 'Indigo - Pink', icon: 'brush', command: (event) => {this.changeTheme('indigo')}},
                    {label: 'Brown - Green', icon: 'brush', command: (event) => {this.changeTheme('brown')}},
                    {label: 'Blue - Amber', icon: 'brush', command: (event) => {this.changeTheme('blue')}},
                    {label: 'Blue Grey - Green', icon: 'brush', command: (event) => {this.changeTheme('blue-grey')}},
                    {label: 'Dark - Blue', icon: 'brush', command: (event) => {this.changeTheme('dark-blue')}},
                    {label: 'Dark - Green', icon: 'brush', command: (event) => {this.changeTheme('dark-green')}},
                    {label: 'Green - Yellow', icon: 'brush', command: (event) => {this.changeTheme('green')}},
                    {label: 'Purple - Cyan', icon: 'brush', command: (event) => {this.changeTheme('purple-cyan')}},
                    {label: 'Purple - Amber', icon: 'brush', command: (event) => {this.changeTheme('purple-amber')}},
                    {label: 'Teal - Lime', icon: 'brush', command: (event) => {this.changeTheme('teal')}},
                    {label: 'Cyan - Amber', icon: 'brush', command: (event) => {this.changeTheme('cyan')}},
                    {label: 'Grey - Deep Orange', icon: 'brush', command: (event) => {this.changeTheme('grey')}}
                ]
            },
            {
                label: 'Customization', icon: 'settings_application',
                items: [
                    {label: 'Compact Size', icon: 'fiber_manual_record', command: () => this.app.layoutCompact = true},
                    {label: 'Material Size', icon: 'fiber_smart_record',  command: () => this.app.layoutCompact = false},
                    {label: 'Static Menu', icon: 'menu',  command: () => this.app.changeToStaticMenu()},
                    {label: 'Overlay Menu', icon: 'exit_to_app',  command: () => this.app.changeToOverlayMenu()},
                    {label: 'Horizontal Menu', icon: 'border_horizontal',  command: () => this.app.changeToHorizontalMenu()},
                    {label: 'Light Menu', icon: 'label_outline',  command: () => this.app.darkMenu = false},
                    {label: 'Dark Menu', icon: 'label',  command: () => this.app.darkMenu = true},
                    {label: 'Inline Profile', icon: 'contacts',  command: () => this.app.profileMode = 'inline'},
                    {label: 'Top Profile', icon: 'person_pin',  command: () => this.app.profileMode = 'top'},
                ]
            },
            {
                label: 'Components', icon: 'list',
                items: [
                    {label: 'Sample Page', icon: 'desktop_mac', routerLink: ['/sample']},
                    {label: 'Forms', icon: 'input', routerLink: ['/forms']},
                    {label: 'Data', icon: 'grid_on', routerLink: ['/data']},
                    {label: 'Panels', icon: 'content_paste', routerLink: ['/panels']},
                    {label: 'Overlays', icon: 'content_copy', routerLink: ['/overlays']},
                    {label: 'Menus', icon: 'menu', routerLink: ['/menus']},
                    {label: 'Messages', icon: 'message', routerLink: ['/messages']},
                    {label: 'Charts', icon: 'insert_chart', routerLink: ['/charts']},
                    {label: 'File', icon: 'attach_file', routerLink: ['/file']},
                    {label: 'Misc', icon: 'toys', routerLink: ['/misc']}
                ]
            },
            {
                label: 'Template Pages', icon: 'get_app',
                items: [
                    {label: 'Empty Page', icon: 'hourglass_empty', routerLink: ['/empty']},
                    {label: 'Landing Page', icon: 'flight_land', url: 'landing.html'},
                    {label: 'Login Page', icon: 'verified_user', url: 'login.html'},
                    {label: 'Error Page', icon: 'error', url: 'error.html'},
                    {label: '404 Page', icon: 'error_outline', url: '404.html'},
                    {label: 'Access Denied Page', icon: 'security', url: 'access.html'}
                ]
            },
            {
                label: 'Menu Hierarchy', icon: 'menu',
                items: [
                    {
                        label: 'Submenu 1', icon: 'subject',
                        items: [
                            {
                                label: 'Submenu 1.1', icon: 'subject',
                                items: [
                                    {label: 'Submenu 1.1.1', icon: 'subject'},
                                    {label: 'Submenu 1.1.2', icon: 'subject'},
                                    {label: 'Submenu 1.1.3', icon: 'subject'},
                                ]
                            },
                            {
                                label: 'Submenu 1.2', icon: 'subject',
                                items: [
                                    {label: 'Submenu 1.2.1', icon: 'subject'},
                                    {label: 'Submenu 1.2.2', icon: 'subject'}
                                ]
                            },
                        ]
                    },
                    {
                        label: 'Submenu 2', icon: 'subject',
                        items: [
                            {
                                label: 'Submenu 2.1', icon: 'subject',
                                items: [
                                    {label: 'Submenu 2.1.1', icon: 'subject'},
                                    {label: 'Submenu 2.1.2', icon: 'subject'},
                                    {label: 'Submenu 2.1.3', icon: 'subject'},
                                ]
                            },
                            {
                                label: 'Submenu 2.2', icon: 'subject',
                                items: [
                                    {label: 'Submenu 2.2.1', icon: 'subject'},
                                    {label: 'Submenu 2.2.2', icon: 'subject'}
                                ]
                            },
                        ]
                    }
                ]
            },
            {label: 'Utils', icon: 'build', routerLink: ['/utils']},
            {label: 'Documentation', icon: 'find_in_page', routerLink: ['/documentation']}
        ];*/
    }

    changeTheme(theme) {
        let themeLink: HTMLLinkElement = <HTMLLinkElement>document.getElementById('theme-css');
        let layoutLink: HTMLLinkElement = <HTMLLinkElement>document.getElementById('layout-css');

        themeLink.href = 'assets/theme/theme-' + theme + '.css';
        layoutLink.href = 'assets/layout/css/layout-' + theme + '.css';
    }

    get model(): MenuItem[] {
        return this.utilityService.getItemsMenu();
    }

}

@Component({
    selector: '[app-submenu]',
    template: `
        <ng-template ngFor let-child let-i="index" [ngForOf]="(root ? item : item.items)">
            <li [ngClass]="{'active-menuitem': isActive(i)}" *ngIf="child.visible === false ? false : true">
                <a [href]="child.url||'#'" (click)="itemClick($event,child,i)" class="ripplelink" *ngIf="!child.routerLink" [attr.tabindex]="!visible ? '-1' : null" [attr.target]="child.target">
                    <i class="ui-button-icon-left ui-c fa fa-fw {{child.icon}}"></i>
                    <span>{{child.label}}</span>
                    <i class="material-icons" *ngIf="child.items">keyboard_arrow_down</i>
                </a>

                <a (click)="itemClick($event,child,i)" class="ripplelink" *ngIf="child.routerLink"
                                    routerLinkActive="active-menuitem-routerlink" [routerLinkActiveOptions]="{exact: true}" [attr.tabindex]="!visible ? '-1' : null" [attr.target]="child.target">
                    <i class="ui-button-icon-left ui-c fa fa-fw {{child.icon}}"></i>
                    <span>{{child.label}}</span>
                    <i class="material-icons" *ngIf="child.items">keyboard_arrow_down</i>
                </a>
                <ul app-submenu [item]="child" *ngIf="child.items" [@children]="isActive(i) ? 'visible' : 'hidden'" [visible]="isActive(i)" [reset]="reset"></ul>
            </li>
        </ng-template>
    `,
    animations: [
        trigger('children', [
            state('hidden', style({
                height: '0px'
            })),
            state('visible', style({
                height: '*'
            })),
            transition('visible => hidden', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)')),
            transition('hidden => visible', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)'))
        ])
    ]
})
export class AppSubMenu {

    @Input() item: MenuItem;

    @Input() root: boolean;

    @Input() visible: boolean;

    _reset: boolean;

    activeIndex: number;

    constructor( @Inject(forwardRef(() => SeguroComponent)) public app: SeguroComponent,
        public router: Router,
        public location: Location,
        public tabViewService: TabViewService) { }

    itemClick(event: Event, item: MenuItem, index: number) {

        //Para manejar tabs
        if (item.url || item.routerLink) {
            let pathComponente = (item.url || item.routerLink).replace('/', '');
            let componente = RutasSeguras.filter(rs => rs.path === pathComponente)[0];
            if (!componente) {
                componente = RutasPublicas.filter(rs => rs.path === pathComponente)[0];
            }
            if (!componente) {
                componente = CoreRoutes.filter(rs => rs.path === pathComponente)[0];
            }

            if (!componente) {
                console.error('No se encuentra una ruta para: ' + pathComponente);
            } else {
                this.tabViewService.actualizarTabs(componente.component, item.label);
                event.preventDefault();
                return true;
            }

        }


        //avoid processing disabled items
        if (item.disabled) {
            event.preventDefault();
            return true;
        }

        //activate current item and deactivate active sibling if any
        this.activeIndex = (this.activeIndex === index) ? null : index;

        //execute command
        //TODO: Revisar eventEmitter
        /*if(item.command) {
            if(!item.eventEmitter) {
                item.eventEmitter = new EventEmitter();
                item.eventEmitter.subscribe(item.command);
            }
            
            item.eventEmitter.emit({
                originalEvent: event,
                item: item
            });
        }*/

        //prevent hash change
        if (item.items || (!item.url && !item.routerLink)) {
            event.preventDefault();
        }

        //hide menu
        if (!item.items) {
            if (this.app.isHorizontal())
                this.app.resetMenu = true;
            else
                this.app.resetMenu = false;

            this.app.overlayMenuActive = false;
            this.app.staticMenuMobileActive = false;
        }
    }

    isActive(index: number): boolean {
        return this.activeIndex === index;
    }

    @Input() get reset(): boolean {
        return this._reset;
    }

    set reset(val: boolean) {
        this._reset = val;

        if (this._reset && this.app.isHorizontal()) {
            this.activeIndex = null;
        }
    }
}