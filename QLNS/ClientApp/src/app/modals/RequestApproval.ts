import { Employee } from "./Employee";

export class RequestApproval {
    id: number;
    createDate:Date;
    type:string;
    status?:number;
    typeTimeOff:string;
    reason:string;
    fromTime:Date;
    toTime:Date;
    rejectedReason:string;
    employeeId:number;
    approverId:number;
    employeeName:string;
    employee:Employee;
    userApprovalID: number;
}
