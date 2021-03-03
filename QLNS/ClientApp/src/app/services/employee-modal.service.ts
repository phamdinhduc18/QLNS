import { EventEmitter, Injectable, Output } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Employee } from '../modals/Employee';

@Injectable()
export class EmployeeModalService {

  private modal$=new BehaviorSubject<Employee>(null);

  @Output() newItemEvent = new EventEmitter<Employee>();

  constructor() { }
  getModalObserver(): Observable<Employee>{
    return this.modal$.asObservable();
  }

  bindDataModal(emp: Employee){
    this.modal$.next(emp);
    this.newItemEvent.emit(emp);
  }
}
