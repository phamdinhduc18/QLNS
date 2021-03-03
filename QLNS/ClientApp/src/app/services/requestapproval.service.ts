import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Pagination } from '../modals/Pagination';
import { RequestApproval } from '../modals/RequestApproval';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})

export class RequestapprovalService {

  constructor(protected http:HttpClient,private authService: AuthService) { }
 
  token=localStorage.getItem("TOKEN")
 reqHeader = new HttpHeaders({
    'Authorization': `Bearer ${this.token}`
  });

  getRequestapproval(): Observable<Pagination<RequestApproval>> {
   

    const url = `${environment.apiUrl}api/RequestApprovals/GetAll`;
    return this.http.get<Pagination<RequestApproval>>(url, { headers: this.reqHeader })
  }
  createRequestapproval(form) {
    
    return this.http.post(`${environment.apiUrl}api/RequestApprovals/Create`,form,{ headers: this.reqHeader });
    }

  getNotification(){
  
    return this.http.get(`${environment.apiUrl}api/Notification/GetAll`, { headers: this.reqHeader })
  }
  delNotification(id){
  
    return this.http.post(`${environment.apiUrl}api/Notification/delete/${id}`, { headers: this.reqHeader })
  }

  updateStatus(id){
  
    return this.http.post(`${environment.apiUrl}api/RequestApprovals/update/${id}`,{headers:this.reqHeader})
  }
  deleteRequestApproval(id){
    return this.http.delete(`${environment.apiUrl}api/RequestApprovals/${id}`, { headers: this.reqHeader })
  }
  // updateStatusDeny(id){
  
  //   return this.http.post(`${environment.apiUrl}api/RequestApprovals/updatedeny/${id}`,{headers:this.reqHeader})
  // }

  updateStatusDeny(id,form){
    var reqHeader = new HttpHeaders({
      // 'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`
    });
    return this.http.post(`https://localhost:44359/api/RequestApprovals/updatedeny/${id}`,form,{ headers: reqHeader });
  }

}