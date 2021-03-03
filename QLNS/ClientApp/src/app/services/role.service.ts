import { Pagination } from './../modals/Pagination';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class RoleService {
  token = localStorage.getItem('TOKEN');
  constructor(private http: HttpClient) { }
  getRole(){
    var reqHeader = new HttpHeaders({
      // 'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`
    });

    return this.http.get(`https://localhost:44359/api/roles/getall`,{ headers: reqHeader });
  }
}
