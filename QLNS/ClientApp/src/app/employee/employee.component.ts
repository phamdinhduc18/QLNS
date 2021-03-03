import { ConfirmDialogComponent } from './../dialog/confirm-dialog/confirm-dialog.component';
import { EmployeeAddDialogComponent } from './../dialog/employee-dialog/employee-add-dialog/employee-add-dialog.component';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { Employee } from '../modals/Employee';
import { Pagination } from '../modals/Pagination';
import { AuthService } from '../services/auth.service';
import { EmployeeService } from '../services/employee.service';

//dialog
import {MatDialog,MAT_DIALOG_DATA,MatDialogRef} from "@angular/material/dialog";
import { Inject } from "@angular/core";
//thêm thành công
import {
  MatSnackBar,MatSnackBarHorizontalPosition,MatSnackBarVerticalPosition} from "@angular/material/snack-bar";


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  list: Employee[] = [];
  listOfData: Pagination<Employee>;
  isVisible=false;
  isEdit=false;
  validateForm: FormGroup;
  isRole : boolean = false;

  constructor(private employeeService: EmployeeService, private authService: AuthService,private notification: NzNotificationService,public dialog: MatDialog, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getEm();
  }



  showModal(): void{
    this.isVisible=true;
  }
  handleCancel(): void{
    this.isVisible = false;
    this.isEdit = false;
  }

  resetPassword(id:number){
    console.warn("id em",id);
    this.authService.ResetPassword(id).subscribe((data:any)=>{
      this.notification.create('success','success', 'Password changed successfully')
    },(error:any)=>{
      this.notification.create('error','failed','Password changed Unsuccessfully')
    }
    );
  }

  confirm(): void{
    
  }
  getEm(){
    let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
    console.log('item ============');
    console.log(item);
    console.log(item.roleId);
    this.isRole = item.roleId == 1;
    this.employeeService.getEmployees().subscribe(
      (res: any) => {
        console.log("res", res);
        this.list = res
        console.log("data1", this.list);
      });
  }

  
  adddialogRef: any;
  ely : any;
  openAddEmployeeDialog() {
    this.adddialogRef = this.dialog.open(EmployeeAddDialogComponent, {
      width: "40%",
      disableClose: false,
      data: {}
    });                                                   
    this.adddialogRef.afterClosed().subscribe(res => {
      //res là khi bên dialog đóng lại truyền cái formControl bên dialog vào (res)
      if (res) {
        this.ely = res;

        
        this.employeeService.createEmployee(this.ely).subscribe(res => {     
          if(res){
            console.warn("đã thêm", res);
            this.getEm();
          }
          else{
          }
        }
        
        )}
        else{
        }
        
    }
    )}

    confirmdialog:any;
    horizontalPosition: MatSnackBarHorizontalPosition = "center";
  verticalPosition: MatSnackBarVerticalPosition = "top";
    Delete(id){
      this.confirmdialog=this.dialog.open(ConfirmDialogComponent,{
        //disableClose: false
      });
      this.confirmdialog.componentInstance.confirmMessage= 'Are you sure you want to delete?';
      this.confirmdialog.afterClosed().subscribe(result => {
        if(result){
          this.employeeService.deleteEmployee(id).subscribe(res => {
          console.warn("đã delete", res);
          //show xóa thành công
          this._snackBar.open("Delete successful", "End now", {
              duration: 3000,
              horizontalPosition: this.horizontalPosition,
              verticalPosition: this.verticalPosition
            });
          this.getEm();
        });
      }
      this.confirmdialog=null;
      });
}
}
