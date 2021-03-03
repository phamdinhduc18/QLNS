import { DemoNgZorroAntdModule } from './../../shared/ng-zorro-antd.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentComponent } from './department/department.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';


@NgModule({
  declarations: [DepartmentComponent],
  imports: [
    CommonModule,
    DemoNgZorroAntdModule,
    FormsModule, ReactiveFormsModule,
    Ng2SearchPipeModule
  ]
})
export class DepartmentModule { }
