import { Component, Injector, OnInit } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { finalize } from "rxjs/operators";
import { CreateContentDto, ContentServiceProxy } from "@shared/service-proxies/service-proxies";
import { MatDialogRef, MatCheckboxChange } from '@angular/material';

@Component({
  templateUrl: './create-cms.component.html',
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
export class CreateCMSComponent extends AppComponentBase implements OnInit {
  saving = false;
  content: CreateContentDto = new CreateContentDto();

  constructor(
    injector: Injector,
    public _contentService: ContentServiceProxy,
    private _dialogRef: MatDialogRef<CreateCMSComponent>
  ) {
    super(injector);
  }

  ngOnInit(): void {

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
        this.notify.info(this.l('CMS Saved'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}