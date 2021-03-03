import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogComponent } from './blog/blog.component';
import { DemoNgZorroAntdModule } from 'src/shared/ng-zorro-antd.module';



@NgModule({
  declarations: [BlogComponent],
  imports: [
    CommonModule,DemoNgZorroAntdModule
  ]
})
export class BlogModule { }
