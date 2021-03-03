import { RoleService } from './../../services/role.service';
import { AuthService } from './../../services/auth.service';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { EmployeeService } from './../../services/employee.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Employee } from 'src/app/modals/Employee';
import { DepartmentService } from 'src/app/services/department.service';
import { Department } from 'src/app/modals/Deparment';



AuthService

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  idDepartment: number; //giá trị departmentId
  listEmployee : any; //Ds Employee
  listDepartment: any;  //Ds Department
  validateForm!: FormGroup; //Form tạo Employee
  validateFormEdit!: FormGroup; //Form sữa Employee
  searchText: any; //Search
  validateCreateFormDepartment: FormGroup //Form tao department
  constructor(private eservice: EmployeeService, private dService: DepartmentService, 
    private fb: FormBuilder, 
    private notification: NzNotificationService,
    private nzMessageService: NzMessageService,
    private modal: NzModalService,
    private authService: AuthService,
    private roleService: RoleService){
   
  }
  
  ngOnInit(): void{
    this.getAllEmployee();
    this.getAllDepartment();
    this.getAllRole();
    let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
    this.idDepartment = item.departmentId; 
    console.log("idDepartment",this.idDepartment);
   console.log(item);

   this.validateForm = this.fb.group({
        fullName: [null, [Validators.required]],
        email: [null, [Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
        dateOfBirth: [null, [Validators.required]],
        gender: [null, [Validators.required]],
        phoneNumber:[null,[Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{9}$")]],
        startDate:[null, [Validators.required]],
        department: [null, [Validators.required]],
        role:[null, [Validators.required]],
        manager:[0]
      })

    this.validateFormEdit = this.fb.group({
      fullName: [null, [Validators.required]],
      email: [null, [Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
      dateOfBirth: [null, [Validators.required]],
      gender: ['Male', [Validators.required]],
      phoneNumber:[null,[Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{9}$")]],
      startDate:[null, [Validators.required]],
      department: [null, [Validators.required]],
      role:[null, [Validators.required]],
      manager:[null]
    })

    this.validateCreateFormDepartment=this.fb.group({
      departmentName: [null,[Validators.required]],
      description: [null,[Validators.required]],
    })
  }
  
  listED:any; //Ds Employee theo Department 
  isRole: boolean = false; //Giá trị của roleId
  listManager:any;
  getAllEmployee(){
    let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
    this.isRole = item.roleId == 1;
    this.eservice.getEmployees().subscribe(res=>{
      this.listEmployee=res;
      console.log("getAllEmployee res",res);
      console.log("getAllEmployee listEmployee",this.listEmployee);
    //  console.log('listEmployee', this.listEmployee);
      this.listED = this.listEmployee.filter(d => d.departmentId == this.idDepartment);
    //  console.log('arr1', this.arr1);
      this.listManager= this.listEmployee.filter(d =>d.roleId == 4);
      console.log("listmanager:", this.listManager);
    })
  }

  

  // getAllDepartment(){
  //   this.dService.getDepartment().subscribe(res=>{
  //     this.listDepartment = res;
  //     console.log("listDepartment",this.listDepartment);
  //   })
  // }

  listRole:any;
  getAllRole(){
    this.roleService.getRole().subscribe(res=>{
      this.listRole=res;
      console.log("list role",this.listRole);
    })
  }

  isShowCreate = false;
  showModalCreate(): void {
    this.isShowCreate = true;
  }


  handleOk(): void {
    console.log('Button ok clicked!');
    this.isShowCreate = false;

  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isShowCreate = false;
  }

  //button submit thêm nhân viên
  confirm(){
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    if (this.validateForm.valid){
      let formSubmit = new Employee();
      formSubmit.fullName= this.validateForm.controls.fullName.value;
      formSubmit.email=this.validateForm.controls.email.value;
      formSubmit.dateOfBirth=this.validateForm.controls.dateOfBirth.value;
      formSubmit.gender=this.validateForm.controls.gender.value;
      formSubmit.phoneNumber=this.validateForm.controls.phoneNumber.value;
      formSubmit.startDate=this.validateForm.controls.startDate.value;
      formSubmit.departmentId=this.validateForm.controls.department.value;
      formSubmit.roleId=this.validateForm.controls.role.value;
      formSubmit.managerId= this.validateForm.controls.manager.value;
      console.warn("formD",formSubmit);
      this.eservice.createEmployee(formSubmit).subscribe(res=>{
        this.notification.create('success', 'Thành công', 'Thêm nhân viên thành công');
        this.isShowCreate = false;
        this.validateForm.reset();
        this.getAllEmployee();
      } ,(error:any)=>{
        this.notification.create('error', 'Thất bại', 'Thêm nhân viên thất bại');
      });     
   } 
  }

  //Button delete nhân viên
  showConfirm(employeeId): void {
    this.modal.confirm({
      nzTitle: '<i>Bạn có muốn xóa nhân viên?</i>',
      nzContent: '' ,
      
      nzOnOk: () => {
        console.log('OK')
        this.eservice.deleteEmployee(employeeId).subscribe(res=>{
          this.notification.create('success', 'Thành công', 'Xóa nhân viên thành công');
          this.getAllEmployee();
        },(error: any)=>{
          this.notification.create('error', 'Thất bại', 'Xóa nhân viên thất bại');
        })
      }
    });
    
  }

  //Hiển thị giá trị Edit lên Input
  isShowEdit = false;
  idEmployee:number;
  showModalEdit(id): void {
    this.isShowEdit = true;
    this.idEmployee=id;
    this.eservice.getEmployeesId(id).subscribe((data: any)=>{
      this.validateFormEdit.controls.fullName.setValue(data.fullName);
      this.validateFormEdit.controls.email.setValue(data.email);
      this.validateFormEdit.controls.dateOfBirth.setValue(data.dateOfBirth);
      this.validateFormEdit.controls.gender.setValue(data.gender);
      this.validateFormEdit.controls.phoneNumber.setValue(data.phoneNumber);
      this.validateFormEdit.controls.startDate.setValue(data.startDate);
      this.validateFormEdit.controls.department.setValue(data.departmentId);
      this.validateFormEdit.controls.role.setValue(data.roleId);
      this.validateFormEdit.controls.manager.setValue(data.managerId);
    })
  }

  handleOkMiddle(): void {
    this.submitEdit();
    console.log('click ok');
    //this.isShowEdit = false;
  }

  handleCancelMiddle(): void {
    this.isShowEdit = false;
  }

  //Button submit Edit
  submitEdit(){
    for (const i in this.validateFormEdit.controls) {
      this.validateFormEdit.controls[i].markAsDirty();
      this.validateFormEdit.controls[i].updateValueAndValidity();
    }
    if (this.validateFormEdit.valid){
   
      let formSubmitE = new Employee();
      //formSubmitE.employeeId=this.idEmployee;
      formSubmitE.fullName= this.validateFormEdit.controls.fullName.value;
      formSubmitE.email=this.validateFormEdit.controls.email.value;
      formSubmitE.dateOfBirth=this.validateFormEdit.controls.dateOfBirth.value;
      formSubmitE.gender=this.validateFormEdit.controls.gender.value;
      formSubmitE.phoneNumber=this.validateFormEdit.controls.phoneNumber.value;
      formSubmitE.startDate=this.validateFormEdit.controls.startDate.value;
      formSubmitE.departmentId=this.validateFormEdit.controls.department.value;
      formSubmitE.roleId=this.validateFormEdit.controls.role.value;
      formSubmitE.managerId= this.validateFormEdit.controls.manager.value;
      formSubmitE.status=true;
      console.warn("formEdit",formSubmitE);
      this.eservice.editEmployee(this.idEmployee,formSubmitE).subscribe(res=>{
        this.notification.create('success', 'Thành công', 'Sửa nhân viên thành công');
        
      //  this.validateForm.reset();
        this.getAllEmployee();
      } ,(error:any)=>{
        this.notification.create('error', 'Thất bại', 'Sửa nhân viên thất bại');
      });    
      this.isShowEdit = false;
    }
  }
  

  

  //Button reset password
  resetPassword(id:number){
    console.warn("id em",id);
    this.authService.ResetPassword(id).subscribe((data:any)=>{
      this.notification.create('success','Thành công', 'Thay đổi mật khẩu thành công')
    },(error:any)=>{
      this.notification.create('error','Thất bại','Thay đổi mật khẩu thất bại')
    }
    );
  }

  reLoad(){
    window.location.reload();
  }
 
  //get danh sach Department
  getAllDepartment(){
    this.dService.getDepartment().subscribe(res=>{
      this.listDepartment = res;
      console.log("listDepartment",this.listDepartment);
    })
  }

  

  //Creat modal creat Deparments
  isShowModalCreateDepartment=false;
  showModalCreateDepartment():void {
    this.isShowModalCreateDepartment=true;
  }
  handleOkDepartment(): void {
    this.isShowModalCreateDepartment = false;

  }
  
  handleCancleDepartment():void{
    this.isShowModalCreateDepartment=false;
  }
  //button Confirm Department
  confirmDepartment(){
    for(const i in this.validateCreateFormDepartment.controls){
      this.validateCreateFormDepartment.markAsDirty[i];
      this.validateCreateFormDepartment.updateValueAndValidity[i];
    }
    if(this.validateCreateFormDepartment.valid){
      let formSubmit= new Department();
      formSubmit.departmentName=this.validateCreateFormDepartment.controls.departmentName.value;
      formSubmit.description=this.validateCreateFormDepartment.controls.description.value;
      formSubmit.status=true;
      this.dService.createDepartment(formSubmit).subscribe(res=>{
        this.notification.create('success', 'Thành công', 'Tạo phòng ban thành công');
        this.isShowModalCreateDepartment=false;
        this.validateCreateFormDepartment.reset();
      },
      (err:any)=>{
        this.notification.create('error', 'Thất bại', 'Tạo phòng ban thất bại');
      });   
       
    }
  }
  
  //show list Department
  isShowDepartment=false;
  showDepartment():void{
    this.isShowDepartment=true;
  }

  handleCancleShowDepartment():void{
    this.isShowDepartment=false;
  }
  showConfirmDeleteDepartment(id){
    this.modal.confirm({
      nzTitle: '<i>Bạn có muốn xóa?</i>',
      nzContent: '' ,
      
      nzOnOk: () => {
        this.dService.deleteDepartment(id).subscribe(res=>{
          this.notification.create('success', 'Thành công', 'Xóa phòng ban thành công');
          window.location.reload();
        },(error: any)=>{
          this.notification.create('error', 'Thất bại', 'Xóa phòng ban thất bại');
        })
      }
    });
    
  }
}
