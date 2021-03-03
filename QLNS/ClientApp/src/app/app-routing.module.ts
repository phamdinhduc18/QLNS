import { DepartmentComponent } from './department/department/department.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { EmployeeComponent } from './employee/employee.component';
import { AuthLoginService } from './guards/auth-login.service';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [ {
  path: '',
  component: LoginComponent,
  
},
{
  path: 'home',
  loadChildren: ()=>import('./home/home.module').then(m=>m.HomeModule),
  canActivate:[ AuthLoginService],
  canLoad: [AuthLoginService]
},
{ path: '**', redirectTo: '' },
{path: '',
    canActivate: [AuthLoginService],
    component: HomeComponent,
    children: [
      { path: 'Home', component: HomeComponent },
      { path: 'Employee', component: EmployeeComponent },
      //{ path: 'ChangePW', component: ChangePasswordComponent }
    //  {path: 'Department', component: DepartmentComponent}
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
