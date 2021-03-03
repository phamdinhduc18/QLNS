import { EmployeeService } from './../services/employee.service';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { RequestApprovalTypeEnum } from 'src/shared/constant';
import { RequestApproval } from '../modals/RequestApproval';
import { AuthService } from '../services/auth.service';
import { RequestapprovalService } from '../services/requestapproval.service';


@Component({
  selector: 'app-requestapproval',
  templateUrl: './requestapproval.component.html',
  styleUrls: ['./requestapproval.component.css']
})
export class RequestapprovalComponent implements OnInit,OnChanges {

  constructor(private fb: FormBuilder,private authen: AuthService,private reqService:RequestapprovalService, private emService: EmployeeService) { }
  ngOnChanges(changes: SimpleChanges): void {
    console.log('ajaj')
    console.log(changes)
    
  }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      type: [null, [Validators.required]],
     // time: [null, this.dayValidators],
     toTime: [null,this.dayValidators],
      fromTime :[null, this.dayValidators],
      half: [false],
      typeoftime: [null,[this.validateIfChecked()]],
      reason: [null, [Validators.required]],
  
    });

    this.formDeny = this.fb.group({
      rejectedReason:[null, [Validators.required]]
    })

    // if(this.authen.loginIn){
    //  const url=this.reqService.GetAll();
    //   console.log(url)
    // }
    // else{
    //   this.authen.logOut();
    // }
    this.getAll();
    this.getAllEmployee();
  }

  dayValidators =(control: FormControl): { [s: string]: boolean }=>
  {
    if (!control.value) {
      return { error: true, required: true };
    }
    return{};
  }
  
  idRole: any; 
  listEmTotal:any;  //Ds quyen Employee (chi Employee thay)
  //listEm:any;
  listAdmin: any; //Ds quyen admin (thay het)
  idDepartment:any;
  listLeader:any;
  getAll(){
    let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
    console.log("item---",item);
    this.idRole = item.roleId;
    this.idDepartment= item.departmentId;
    
  this.reqService.getRequestapproval().subscribe(res=>{
    this.listAdmin =res;
    console.log("listAdmin",this.listAdmin);
    this.listEmTotal = this.listAdmin.filter(e=> e.employeeId == item.id);
    this.listLeader = this.listAdmin.filter(e=>e.approverId== item.departmentId);
    console.log("listtoLeader: ", this.listLeader);
  }) 
  
  }
 


  listOfAllData: RequestApproval[] = [];
  setType(type: any) {
    return RequestApprovalTypeEnum[type];
  }
  isHalf=false;
  
  validateIfChecked(): ValidatorFn {
    return (form: FormGroup): ValidationErrors | null => {
      var a= this.validateForm;
      if (a && a.controls['half'].value && !a.controls.typeoftime.value
        ) {
        return {
          'err': true
        };
      }
      return null;
    }
  }

  //button Create
  isVisible = false;
  showModal(): void {
    this.isVisible = true;
  }
  
  datediff(first, second) {
    // Take the difference between the dates and divide by milliseconds per day.
    // Round to nearest whole number to deal with DST.
    return Math.round((second-first)/(1000*60*60*24));
}
errorObject: any={IsOk : true, ErrorMessage:''};
  Validate(model:RequestApproval){
    let countDays = this.datediff(model.toTime, model.fromTime)+1;
    console.log('countDays ---------------------');
    console.log("ngayket thuc",model.fromTime);
    console.log("ngay bat dau",model.toTime);
    console.log(countDays);
    if (countDays<=0 || countDays >2) {
      this.errorObject.IsOk=false;
      this.errorObject.ErrorMessage="Ngày khong hop le";
      return ;
    }
    this.errorObject.IsOk = true;
    
  }


  isEdit=false;
  editId=0;
  isConfirmLoading = false;
  saiNgay:boolean=true;
  handleOk(): void {
   for(const i in this.validateForm.controls){
     this.validateForm.controls[i].markAsDirty();
     this.validateForm.controls[i].updateValueAndValidity();
   }
   if(this.validateForm.valid){
     var entity=new RequestApproval();
     entity.type=this.validateForm.controls.type.value;
     entity.status=0;
     if(this.isHalf)
     entity.typeTimeOff=this.validateForm.controls.typeoftime.value;
     else entity.typeTimeOff='AllDay';
    //  entity.fromTime=this.validateForm.controls.time.value[0];
    //   entity.toTime=this.validateForm.controls.time.value[1];

    entity.toTime= this.validateForm.controls.toTime.value;
    entity.fromTime= this.validateForm.controls.fromTime.value;
      entity.reason=this.validateForm.controls.reason.value;
     entity.employeeId=JSON.parse(localStorage.getItem('CURRENTUSER')).id;
     console.log("list app",entity);  
     this.Validate(entity);
     if (!this.errorObject.IsOk) {
      //  alert(this.errorObject.ErrorMessage);
       this.saiNgay=false;
       //show lỗi;
       return;
     };


     this.reqService.createRequestapproval(entity).subscribe(req=>{
      this.getAll();
     });
     
     this.isConfirmLoading = true;
    setTimeout(() => {
      this.isVisible = false;
      this.isConfirmLoading = false;
      
    }, 1000);
    
   }
   else this.isConfirmLoading=false;
  }
  typeList = RequestApprovalTypeEnum;
  validateForm: FormGroup;
  TypeChange(value) {
  }

  handleCancle(): void {
    this.validateForm.reset();
    this.isVisible = false;
    this.isEdit=false;
    this.saiNgay=true;
  }
  //Duyệt đơn xin nghỉ phép
  Accept(id){
    this.reqService.updateStatus(id).subscribe(e=>{
      console.log("DA UPDATE")
      this.getAll();
    })
  }
  DeleteRequestApproval(id){
    this.reqService.deleteRequestApproval(id).subscribe(e=>{console.log("da xoa")});
    this.reqService.delNotification(id).subscribe(e=>{
      console.log("da xoa");
    })
    window.location.reload();
  }
 
  listEmployee: any;
  getAllEmployee(){
    this.emService.getEmployees().subscribe(res=>{
      this.listEmployee = res;
      
    })
  }

  isShowDeny=false;
  idRequestApproval:any;
  showDeny(id)
  {
    this.isShowDeny = true;
    this.idRequestApproval=id;
  }
  handleDenyCancel(): void {
    this.isShowDeny = false;
  }
  
  formDeny: FormGroup;
  deny: RequestApproval;
  submitDeny(){
    this.deny = new RequestApproval();
    this.deny.rejectedReason = this.formDeny.controls.rejectedReason.value;
    this.reqService.updateStatusDeny(this.idRequestApproval,this.deny).subscribe(res=>{
    this.isShowDeny=false;
    window.location.reload();
    })
  }
}
