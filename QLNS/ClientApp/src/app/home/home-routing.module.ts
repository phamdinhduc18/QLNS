import { DepartmentComponent } from './../department/department/department.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangePasswordComponent } from '../change-password/change-password.component';
import { EmployeeComponent } from '../employee/employee.component';
import { RequestapprovalComponent } from '../requestapproval/requestapproval.component';
import { HomeComponent } from './home.component';
import { BirthdayComponent } from '../birthday/birthday/birthday.component';
import { BlogComponent } from 'src/blog/blog/blog.component';
const routes: Routes=[{
    path: '',
    component: HomeComponent,
    children:[
        {
            path: '',
            component: DepartmentComponent
        },
        { path: 'ChangePW', 
        component: ChangePasswordComponent },
        { path: 'RequestApproval', 
        component:  RequestapprovalComponent},
        { path: 'Department', 
        component:  DepartmentComponent},
        { path: 'Birthday', 
        component:  BirthdayComponent},
        {path:'Blog',
        component: BlogComponent}
    ]
   
}]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModlue{

}