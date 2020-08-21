import { appModuleAnimation } from "@shared/animations/routerTransition";
import { Component, ViewChild, Injector } from "@angular/core";
import { PagedListingComponentBase, PagedRequestDto } from "@shared/paged-listing-component-base";
import { CreateCMSComponent } from "./create-cms/create-cms.component";
import { MatDialog } from "@angular/material";
import { ContentServiceProxy, ContentListDto, ContentDto, ListResultDtoOfContentListDto } from "@shared/service-proxies/service-proxies";
import { EditCMSComponent } from "./edit-cms/edit-cms.component";

@Component({
  templateUrl: './cms.component.html',
  animations: [appModuleAnimation()],
  styles: [
    `
      mat-form-field {
        padding: 10px;
      }
    `
  ]
})
export class CMSComponent extends PagedListingComponentBase<ContentListDto> {

  contents: ContentListDto[] = [];

  constructor(
    injector: Injector,
    private _contentService: ContentServiceProxy,
    private _dialog: MatDialog
  ) {
    super(injector);
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this.loadContent();
    finishedCallback();
  }

  protected delete(entity: any): void {
  }

  // Show Modals
  createCMS(): void {
    this.showCreateOrEditUserDialog();
  }

  editCMS(user: ContentDto): void {
    this.showCreateOrEditUserDialog(user.id);
  }

  private showCreateOrEditUserDialog(id?: number): void {
    let createOrEditUserDialog;
    if (id === undefined || id <= 0) {
      createOrEditUserDialog = this._dialog.open(CreateCMSComponent);
    } else {
      createOrEditUserDialog = this._dialog.open(EditCMSComponent, {
         data: id
       });
    }

    createOrEditUserDialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }

  loadContent() {
    this._contentService.getListAsync()
      .subscribe((result: ListResultDtoOfContentListDto) => {
        this.contents = result.items;
      });
  }

}