import { Component, ElementRef, OnDestroy, OnInit, Renderer, ViewChild } from '@angular/core';
import { UtilityService } from "app/core/services/utility.service";
import { AplicacionServicio } from "app/core/seguridad/servicio/AplicacionServicio";

enum MenuOrientation {
  STATIC,
  OVERLAY,
  HORIZONTAL
};

declare var jQuery: any;

@Component({
  selector: 'app-seguro',
  templateUrl: './seguro.component.html',
  styleUrls: ['./seguro.component.css']
})
export class SeguroComponent implements OnInit, OnDestroy {

  public layoutCompact: boolean = false;
  public layoutMode: MenuOrientation = MenuOrientation.STATIC;
  public darkMenu: boolean = false;
  public profileMode: string = 'inline';
  public rotateMenuButton: boolean;
  public topbarMenuActive: boolean;
  public overlayMenuActive: boolean;
  public staticMenuDesktopInactive: boolean;
  public staticMenuMobileActive: boolean;
  public layoutContainer: HTMLDivElement;
  public layoutMenuScroller: HTMLDivElement;
  public menuClick: boolean;
  public topbarItemClick: boolean;
  public activeTopbarItem: any;
  public documentClickListener: Function;
  public resetMenu: boolean;

  @ViewChild('layoutContainer') layourContainerViewChild: ElementRef;
  @ViewChild('layoutMenuScroller') layoutMenuScrollerViewChild: ElementRef;

  constructor(public utilityService: UtilityService,
    private aplicacionServicio: AplicacionServicio,
    public renderer: Renderer) {
    /*let urlActual = location.hash;
    if (AppSettings.URLS_ANONIMAS.indexOf(urlActual) > -1) {
        //Se trata de una url anonima permitimos el paso sin autenticacion
        return;
    }
    if (!this.aplicacionServicio.esUsuarioAutenticado()) {
        if (urlActual == '#/cuenta/login') {
            LocalStorageHelper.set('urlActual', this.utilityService.urlActual());
            let timer = Observable.timer(1);
            timer.subscribe(t => this.utilityService.navegarAIngreso());
        } else {
            let timer = Observable.timer(1);
            timer.subscribe(t => window.location.href = '/assets/pages/landing.html');                
        }
    }*/
  }

  async ngOnInit() {
    this.utilityService.setItemsMenu(await this.aplicacionServicio.getMenu('MENSISPRIN'));
  }

  ngAfterViewInit() {
    this.layoutContainer = <HTMLDivElement>this.layourContainerViewChild.nativeElement;
    this.layoutMenuScroller = <HTMLDivElement>this.layoutMenuScrollerViewChild.nativeElement;

    //hides the horizontal submenus or top menu if outside is clicked
    this.documentClickListener = this.renderer.listenGlobal('body', 'click', (event) => {
      if (!this.topbarItemClick) {
        this.activeTopbarItem = null;
        this.topbarMenuActive = false;
      }

      if (!this.menuClick && this.isHorizontal()) {
        this.resetMenu = true;
      }

      this.topbarItemClick = false;
      this.menuClick = false;
    });

    setTimeout(() => {
      jQuery(this.layoutMenuScroller).nanoScroller({ flash: true });
    }, 10);
  }

  onMenuButtonClick(event) {
    this.rotateMenuButton = !this.rotateMenuButton;
    this.topbarMenuActive = false;

    if (this.layoutMode === MenuOrientation.OVERLAY) {
      this.overlayMenuActive = !this.overlayMenuActive;
    }
    else {
      if (this.isDesktop())
        this.staticMenuDesktopInactive = !this.staticMenuDesktopInactive;
      else
        this.staticMenuMobileActive = !this.staticMenuMobileActive;
    }

    event.preventDefault();
  }

  onMenuClick($event) {
    this.menuClick = true;
    this.resetMenu = false;

    if (!this.isHorizontal()) {
      setTimeout(() => {
        jQuery(this.layoutMenuScroller).nanoScroller();
      }, 500);
    }
  }

  onTopbarMenuButtonClick(event) {
    this.topbarItemClick = true;
    this.topbarMenuActive = !this.topbarMenuActive;

    if (this.overlayMenuActive || this.staticMenuMobileActive) {
      this.rotateMenuButton = false;
      this.overlayMenuActive = false;
      this.staticMenuMobileActive = false;
    }

    event.preventDefault();
  }

  onTopbarItemClick(event, item) {
    this.topbarItemClick = true;

    if (this.activeTopbarItem === item)
      this.activeTopbarItem = null;
    else
      this.activeTopbarItem = item;

    event.preventDefault();
  }

  isTablet() {
    let width = window.innerWidth;
    return width <= 1024 && width > 640;
  }

  isDesktop() {
    return window.innerWidth > 1024;
  }

  isMobile() {
    return window.innerWidth <= 640;
  }

  isOverlay() {
    return this.layoutMode === MenuOrientation.OVERLAY;
  }

  isHorizontal() {
    return this.layoutMode === MenuOrientation.HORIZONTAL;
  }

  changeToStaticMenu() {
    this.layoutMode = MenuOrientation.STATIC;
  }

  changeToOverlayMenu() {
    this.layoutMode = MenuOrientation.OVERLAY;
  }

  changeToHorizontalMenu() {
    this.layoutMode = MenuOrientation.HORIZONTAL;
  }

  ngOnDestroy() {
    if (this.documentClickListener) {
      this.documentClickListener();
    }

    jQuery(this.layoutMenuScroller).nanoScroller({ flash: true });
  }

}