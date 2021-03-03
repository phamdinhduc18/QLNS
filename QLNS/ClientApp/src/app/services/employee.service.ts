import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../modals/Employee';
import { environment } from '../../environments/environment'
import { Pagination } from '../modals/Pagination';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  token = localStorage.getItem('TOKEN');
  constructor(private _http: HttpClient) {

  }
  
  getEmployees(): Observable<Pagination<Employee>> {
    var reqHeader = new HttpHeaders({
      // 'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`
    });

    const url = `${environment.apiUrl}api/employees`;
    return this._http.get<Pagination<Employee>>(url, { headers: reqHeader }).pipe();
  }

  createEmployee(form){
    var reqHeader = new HttpHeaders({
      // 'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.token}`
    });
    
    return this._http.post(`https://localhost:44359/api/Employees/Create`,form,{ headers: reqHeader })
  }
deleteEmployee(id){
  var reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  });
  return this._http.delete(`https://localhost:44359/api/Employees/${id}`,{ headers: reqHeader });
}
getEmployeesId(id: any) {
  var reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  });

  return this._http.get(`https://localhost:44359/api/Employees/${id}`,{ headers: reqHeader });
}
editEmployee(id,form){
  var reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  });
  return this._http.put(`https://localhost:44359/api/Employees/update/${id}`,form,{ headers: reqHeader });
}

//current birthday
getBirthDay() {
  var reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  });
  return this._http.get(`https://localhost:44359/api/Employees/BirthDayCurrent`,{ headers: reqHeader })
}

//current month
getBirthDayMonth() {
  var reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  }); 
  return this._http.get(`https://localhost:44359/api/Employees/BirthDayMonthCurrent`,{ headers: reqHeader })
}

//month
getMonth(month: number) {
  var reqHeader = new HttpHeaders({
    // 'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.token}`
  }); 
  return this._http.get(`https://localhost:44359/api/Employees/BirthDayMonth?month=${month}`,{ headers: reqHeader })
}

}
