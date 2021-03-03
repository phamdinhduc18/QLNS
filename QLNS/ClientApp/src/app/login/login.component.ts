import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { NzNotificationService   } from 'ng-zorro-antd/notification';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  validateForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private _authService: AuthService,
    private _route: Router,
    private notification:NzNotificationService  
    ) { }

    ngOnInit(): void {
    if(this._authService.loginIn()){
      this._route.navigate(['home'])
    }
    
    

    this.validateForm=this.fb.group({
      email:["admin@admin.com",[Validators.required]],
      password: ["12345678",[Validators.required]],
      remember: [true,[]]
    })

  //   this.validateForm=new FormGroup({
  //   email: new FormControl("", [Validators.required, Validators.email]),
  //   password: new FormControl("", [
  //   Validators.required,
  //   Validators.pattern("^[a-zA-Z0-9]*"),
  // ]),
  //   });
  }
  
  submitForm(){
  
    this._authService.login(this.validateForm.value.email,this.validateForm.value.password).subscribe(rs=>{
      console.log(rs)
      if(rs?.username){
        this._route.navigate(['home'])

      }
      else{
            this.notification.create(
      
      'error',
      'Error',
      rs.message ?rs.message : 'You check again information'
    );

      }

    },error=>{
      
  
    });
  }

}
