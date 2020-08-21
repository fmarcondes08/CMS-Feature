import { AppComponentBase } from "@shared/app-component-base";
import { OnInit, Injector, Optional, Inject, Component } from "@angular/core";
import { ContentDto, ContentServiceProxy } from "@shared/service-proxies/service-proxies";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { finalize } from "rxjs/operators";

@Component({
  templateUrl: './edit-cms.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class EditCMSComponent extends AppComponentBase implements OnInit {
  saving = false;
  content: ContentDto = new ContentDto();

  constructor(
    injector: Injector,
    public _contentService: ContentServiceProxy,
    private _dialogRef: MatDialogRef<EditCMSComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._contentService.getDetailAsync(this._id).subscribe(result => {
      this.content = result;
    });
  }

  save(): void {
    this.saving = true;

    this._contentService
      .createUpdateAsync(this.content)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('CMS Updated'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}