import { EmployeeService } from './../services/employee.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { RequestapprovalService } from '../services/requestapproval.service';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  validateFormChangePW!: FormGroup;
  username: string;
  constructor(
    private notification: NzNotificationService,
    private fb:FormBuilder,
    private _authen: AuthService,
    private _route: Router,
    private route: ActivatedRoute,
    private reqService: RequestapprovalService,
    private employeeService : EmployeeService
    ) { }
    
  isCollapsed = false;
  isLoadingTwo= false;
  title = "";
  idLeader:number; 

  ngOnInit(): void {
    this.username=this._authen.getUserName();
    this.GetOnNoti();

    let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
    this.idLeader= item.id; console.log("idLeader",this.idLeader);
  //  console.log("aaaa",item);

    this.getBirthDayNoti();
    this.permisonNoti();
    //call validateFormChangePW
    this.validateFormChangePW=this.fb.group({
      currentPassword: [null,[Validators.required]],
      newPassword:[null,[this.passwordValidator]],
      rePassword:[null,[this.confirmValidator]]
    },{
      updateOn:'change'
    });
  }
  loadTwo(){
   this._authen.logOut()
     this._route.navigate([""]);
  }
  onActivate(componentReference) {
    this.title = componentReference.title;
  }
  listNoti:any;

  listNotiPQ:any;
  
  GetOnNoti(){
    
    this.reqService.getNotification().subscribe(res=>
      {
        this.listNoti=res;
        console.log("list noti",this.listNoti);
        this.listNotiPQ = this.listNoti.filter(d => d.employeeId == this.idLeader);
        console.log("listnotiPQ",this.listNotiPQ);
        this.countNoti();
       // this.count= this?.listNotiPQ
      });
      
  }

 
 
  listBirthDayNoti:any;
  getBirthDayNoti(){
    this.employeeService.getBirthDay().subscribe(res=>{
      this.listBirthDayNoti = res;
      console.log("list birthday: ",this.listBirthDayNoti);
      this.countBirthDayNoti();
    })
  }

  count: number;
  countNoti(){
    //this.count = this?.listNoti.length;
    this.count= this?.listNotiPQ.length;
    console.log("count noti",this.count);
  }

  countBirthDay: number;
  countBirthDayNoti(){
    this.countBirthDay = this?.listBirthDayNoti.length;
    console.log("count birthday today: ",this.countBirthDay);
  }

  isRole : boolean = false;
  permisonNoti(){
    let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
    console.log('item ============');
    console.log(item);
    console.log(item.roleId);
    this.isRole = item.roleId == 4;
  }
  isVisible = false;
  isOkLoading = false;

  showModal(): void {
    this.isVisible = true;
  }
  handleCancel(): void {
    this.isVisible = false;
  }


  //Modal BirthDay
  isShowBirthDay = false;
  showModalBirthDay(): void {
    this.isShowBirthDay = true;
  }
  handleBirthDayCancel(): void {
    this.isShowBirthDay = false;
  }
  
  //Modal ChangePW
  isShowChangePW=false;
  showModalChangePW():void {
    this.isShowChangePW=true;
  }
   handleCancelChangePW():void{
     this.isShowChangePW=false;
   }
   handleOkChangePW(): void {
    this.isShowChangePW = false;

  }
   //validatorPassWord
   passwordValidator=(control: FormControl): {[s:string]:boolean}=>{
    const regEx: RegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    if(!control.value){
      return{error:true,required:true};
    }else if(control.value===this.validateFormChangePW.controls.currentPassword.value){
        return{same:true,error:true};
    }
    return {};
   }

   //validator confirm PW
   confirmValidator = (control:FormControl): {[s:string]:boolean}=>{
     if(!control.value){
       return {error:true,required:true};
     } else if (control.value !== this.validateFormChangePW.controls.newPassword.value){
       return {confirm:true,error:true};
     }
     return{};
   }
  
   //submit change PW
   submitFormChangePW():void{
     let errorCount=0;
     for(const i in this.validateFormChangePW.controls){
        this.validateFormChangePW.controls[i].markAsDirty();
        this.validateFormChangePW.controls[i].updateValueAndValidity();
        if(this.validateFormChangePW.controls[i].errors!=null){
          errorCount++;
        }
     }

     if(errorCount<1){
       this._authen.ChangePassword(this.validateFormChangePW.value.currentPassword,this.validateFormChangePW.value.newPassword).subscribe(()=>{
         this.notification.create(
           'success',
           'Thành công',
           'Đổi mật khẩu thành công.'
           )
           this._authen.logOut();
           this.isShowChangePW=false;
           this._route.navigate([""]);
       },(error)=>{
        this.notification.create(
          'error',
          'Thất bại',
          `${error.error}`
        );
       }
       );
     }
   }
   

  toggleCollapsed(): void {
    this.isCollapsed = !this.isCollapsed;
  }
}
