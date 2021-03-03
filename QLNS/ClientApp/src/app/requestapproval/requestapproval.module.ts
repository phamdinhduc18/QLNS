
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RequestapprovalComponent } from "./requestapproval.component";
//zoro

import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { DemoNgZorroAntdModule } from "src/shared/ng-zorro-antd.module";
@NgModule({
  declarations: [RequestapprovalComponent],
  imports: [
    CommonModule,
    DemoNgZorroAntdModule,FormsModule,ReactiveFormsModule
  ],
  providers: [
 ],
})
export class RequestapprovalModule {}