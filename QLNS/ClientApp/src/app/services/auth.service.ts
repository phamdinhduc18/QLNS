import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { constants } from 'buffer';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import {environment} from '../../environments/environment'
import { Constant, HandleLocalStore } from './HandleLocalSore';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper=new JwtHelperService();
  username: string;
  currentUser: any = JSON.parse(localStorage.getItem("CURRENTUSER"));

  constructor(private _http: HttpClient) {
    
   }
   login(email:string,password: string): Observable<any>{
     return this._http.post(`${environment.apiUrl}Authorization/login`,{
      email:email,
      password:password
     }).pipe(
       map(user=>{
         if(user){
          localStorage.setItem("CURRENTUSER",JSON.stringify(user))
          HandleLocalStore.writeToken(user["accessToken"])
          HandleLocalStore.writeRefreshToken(user["refreshToken"])
         }
         else{
           this.logOut();
         }
         return user;
       
       })
     );
   }
  
   getUserName(){
     let item=JSON.parse(localStorage.getItem("CURRENTUSER"));
     this.username=item.username;
     console.log(this.username)
     return this.username;
   }
   

    loginIn(){
     const token=HandleLocalStore.getToken();
     return token && 
      !this.jwtHelper.isTokenExpired(token);
   }
   logOut(){
    localStorage.removeItem(Constant.LOCALVARIABLENAME.TOKEN)
    localStorage.removeItem(Constant.LOCALVARIABLENAME.REFRESH_TOKEN)
    localStorage.removeItem("CURRENTUSER");
   }
   
   token = localStorage.getItem('TOKEN');
   ChangePassword(currentPassword: string, newPassword: string){
     console.log(this.token);
    var reqHeader = new HttpHeaders({
      // 'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`
    });
    return this._http.post(`${environment.apiUrl}api/employees/update-password`, { id:this.currentUser.id,
      currentPassword, newPassword
    },{ headers: reqHeader }
  ).pipe();
  }
  
  ResetPassword(EmployeeId: number){
    var reqHeader = new HttpHeaders({
      // 'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`
    });
    return this._http.post(`${environment.apiUrl}api/employees/reset-password`,{
      id:EmployeeId
    },{ headers: reqHeader }).pipe();
  }
  
}
