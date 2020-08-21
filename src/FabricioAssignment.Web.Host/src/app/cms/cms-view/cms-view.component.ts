import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { Component, OnInit, Injector } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { ContentDto, ContentServiceProxy } from "@shared/service-proxies/service-proxies";


@Component({
  templateUrl: './cms-view.component.html',
  animations: [appModuleAnimation()]
})

export class CMSViewComponent extends AppComponentBase implements OnInit {

  content: ContentDto = new ContentDto();
  contentId: number;

  constructor(
    injector: Injector,
    private _contentService: ContentServiceProxy,
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.contentId = params['eventId'];
      this.loadContent();
    });
  }

  loadContent() {
    this._contentService.getDetailAsync(this.contentId)
      .subscribe((result: ContentDto) => {
        this.content = result;
      });
  }

}