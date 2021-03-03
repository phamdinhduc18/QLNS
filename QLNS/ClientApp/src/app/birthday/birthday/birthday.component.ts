import { FormGroup, FormBuilder,FormControl,NgForm } from '@angular/forms';
import { EmployeeService } from './../../services/employee.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-birthday',
  templateUrl: './birthday.component.html',
  styleUrls: ['./birthday.component.css']
})
export class BirthdayComponent implements OnInit {

  constructor(private service: EmployeeService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getBirthDayMonth();
    this.getBirthDayNoti();
    this.currenDay();

    this.monthForm = this.fb.group({
      month: [null]
    })
  }
  
  //list tháng sinh nhật hiện tại
  listBirthDayMonth: any;
  getBirthDayMonth(){
    this.service.getBirthDayMonth().subscribe(res=>{
      this.listBirthDayMonth = res;
    //  console.log("listbirthDay: ", this.listBirthDayMonth);
      this.countBirthDayMonth();
    })
  }

  //list ngày sinh nhật hiện tại
  listBirthDayNoti:any;
  getBirthDayNoti(){
    this.service.getBirthDay().subscribe(res=>{
      this.listBirthDayNoti = res;
    //  console.log("list birthday: ",this.listBirthDayNoti);
      this.countBirthDayNoti();
    })
  }

  countBirthDay: number;
  countBirthDayNoti(){
    this.countBirthDay = this?.listBirthDayNoti.length;
   // console.log("count birthday today: ",this.countBirthDay);
  }

  countMonth: number;
  countBirthDayMonth(){
    this.countMonth = this?.listBirthDayMonth.length;
  }

  //list tháng sinh nhật nhập vào
  monthForm : FormGroup;
  month:number;
  listMonth: any;
  submitForm(): void {
    this.month= this.monthForm.value.month;
    this.service.getMonth(this.month).subscribe(res=>{
      this.listMonth = res;
      console.log("list month: ",this.listMonth);
    })
  }

  mm :any;
  dd: any;
  today: any;
  currenDay(){
    this.today = new Date();
    this.dd = String(this.today.getDate()).padStart(2, '0');
    this.mm = String(this.today.getMonth() + 1).padStart(2, '0');
    this.today = this.dd + '/' + this.mm  ;
  }
 
}
