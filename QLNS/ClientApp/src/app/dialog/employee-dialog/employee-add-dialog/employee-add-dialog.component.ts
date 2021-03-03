import { EmployeeService } from '../../../../app/services/employee.service';
import { Employee } from './../../../modals/Employee';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup,  NgForm,  Validators } from "@angular/forms";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog"; 
import { Inject } from "@angular/core";

@Component({
  selector: 'app-employee-add-dialog',
  templateUrl: './employee-add-dialog.component.html',
  styleUrls: ['./employee-add-dialog.component.css']
})
export class EmployeeAddDialogComponent implements OnInit {

  formControl: FormGroup;
  constructor(public service: EmployeeService,public dialogRef: MatDialogRef<EmployeeAddDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any,private fb: FormBuilder) {
    {
      this.formControl=fb.group({
        'fullName': [null],
        'email': [null],
        'phone': [null],
        'diaChi': [null],
        'gender': [null],
        'userName': [null],
        'managerId': [null]
      })
    }
   }

  ngOnInit(): void {
  }
  isSubmmitted=false;
  createEmployee: Employee; 
  laybien: Employee;
  submit() {
    this.isSubmmitted=true; //khi nhấn nút submit thì nó bắt lỗi cái gender
    if(this.formControl.status==='VALID'){
      this.createEmployee = new Employee();     
      this.createEmployee.fullName=this.formControl.value.fullName;
      this.createEmployee.email=this.formControl.value.email;
      this.createEmployee.phoneNumber=this.formControl.value.phone;
      this.createEmployee.address=this.formControl.value.diaChi;
      this.createEmployee.gender=this.formControl.value.gender;
      this.createEmployee.username=this.formControl.value.username;
      this.createEmployee.managerId=this.formControl.value.managerId;
     this.createEmployee.departmentId= 1;
     this.createEmployee.roleId=5;
      console.warn(this.createEmployee);  
     
      this.dialogRef.close(this.createEmployee);
    }
  }

}
