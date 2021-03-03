import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { environment } from 'src/environments/environment';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  validateForm!: FormGroup;
  constructor(private notification: NzNotificationService,
    private fb: FormBuilder,
    private authService: AuthService,
    private rout: Router) { if (localStorage.getItem('CURRENTUSER') === null) {
      this.notification.create(
        'error',
        'Chưa đăng nhập',
        'Chuyển sang trang đăng nhập'
      );
      setTimeout(() => {
        rout.navigate(['login']);
      }, 1500);
    } }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      currentPassword: [null, [Validators.required]],
      newPassword: [null, [
        this.passwordValidator
      ]],
      rePassword: [null, [this.confirmValidator]]
    }, {
      updateOn: 'change'
    });
  }

  passwordValidator = (control: FormControl): { [s: string]: boolean } => {
    const regEx: RegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    if (!control.value) {
      return { error: true, required: true };
    } else if (control.value === this.validateForm.controls.currentPassword.value) {
      return { same: true, error: true };

    } else if (!control.value.match(regEx)) {
      return { pattern: true, error: true };
    }

    return {};
  }
  
  confirmValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { error: true, required: true };
    } else if (control.value !== this.validateForm.controls.newPassword.value) {
      return { confirm: true, error: true };
    }
    return {};
  }
  

  submitForm(): void {
    let errorCount = 0;
    for (const i in this.validateForm.controls) {

      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
      if (this.validateForm.controls[i].errors !== null) {
        errorCount++;
      }
    }
    
    if (errorCount < 1) {
      this.authService.ChangePassword(this.validateForm.value.currentPassword, this.validateForm.value.newPassword).subscribe(() => {
        this.notification.create(
          'success',
          'Thành công',
          'Đổi mật khẩu thành công.'
        );
        this.authService.logOut();

      }, (error) => {
        this.notification.create(
          'error',
          'Thất bại',
          `${error.error}`
        );
      });
    }
  }
}
