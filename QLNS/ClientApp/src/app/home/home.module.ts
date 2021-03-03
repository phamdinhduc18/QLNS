import { NgModule } from '@angular/core';
import { HomeRoutingModlue } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { EmployeeService } from '../services/employee.service';
import { CommonModule } from '@angular/common';
import { EmployeeModalService } from '../services/employee-modal.service';
import { ReactiveFormsModule } from '@angular/forms';
import { DemoNgZorroAntdModule } from 'src/shared/ng-zorro-antd.module';

@NgModule({
    imports:[
        CommonModule,
        HomeRoutingModlue,
        NzLayoutModule,DemoNgZorroAntdModule,
        NzMenuModule,ReactiveFormsModule],
    declarations:[HomeComponent],
    exports:[HomeComponent],
    providers: [EmployeeService,EmployeeModalService]
})
export class HomeModule{

}