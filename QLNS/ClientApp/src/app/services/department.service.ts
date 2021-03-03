// import { Pagination } from './../modals/Pagination';
// import { Observable } from 'rxjs';
// import { Injectable } from '@angular/core';
// import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { Department } from '../modals/Deparment';
// @Injectable({
//   providedIn: 'root'
// })
// export class DepartmentService {
//   token = localStorage.getItem('TOKEN');
//   constructor(private http: HttpClient) { }
//   getDepartment(): Observable<Pagination<Department>> {
//     var reqHeader = new HttpHeaders({
//       // 'Content-Type': 'application/json',
//       'Authorization': `Bearer ${this.token}`
//     });

//     return this.http.get<Pagination<Department>>(`https://localhost:44359/api/Departments`,{ headers: reqHeader });
//   }
// }

import { Pagination } from './../modals/Pagination';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Department } from '../modals/Deparment';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  token = localStorage.getItem('TOKEN');
  reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  });
  constructor(private http: HttpClient) {
    
   }
  
  getDepartment(): Observable<Pagination<Department>> {
    

    return this.http.get<Pagination<Department>>(`${environment.apiUrl}api/Departments`,{ headers: this.reqHeader });
  }

  createDepartment(form){
    return this.http.post(`${environment.apiUrl}api/Departments/Create`,form,{headers:this.reqHeader});
  }
  editDepartment(id,form){
    return this.http.put(`${environment.apiUrl}api/Departments/${id}`,form,{headers:this.reqHeader});
  }
  deleteDepartment(id){
    return this.http.delete(`${environment.apiUrl}api/Departments/${id}`, { headers: this.reqHeader })
  }
}
