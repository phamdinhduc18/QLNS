import { DemoNgZorroAntdModule } from 'src/shared/ng-zorro-antd.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BirthdayComponent } from './birthday/birthday.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [BirthdayComponent],
  imports: [
    CommonModule,
    DemoNgZorroAntdModule,
    FormsModule, ReactiveFormsModule
  ]
})
export class BirthdayModule { }
