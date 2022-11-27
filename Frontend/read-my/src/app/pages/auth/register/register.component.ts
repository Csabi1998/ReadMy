import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/api/users/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  isLoading = false;

  constructor(
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  onSubmit(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }

    const userName = form.value.username;
    const password = form.value.password;
    const role = form.value.roleSelector;
    const fullName = form.value.fullname;
    this.isLoading = true;

    const authObs = this.userService.register({
      userName,
      password,
      fullName,
      role,
    });

    authObs.subscribe({
      next: (resData) => {
        this.isLoading = false;
        this.toastr.success(
          `${fullName} is added to the workspace!`,
          'Registration successful'
        );
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage);
        this.isLoading = false;
      },
    });

    form.reset();
  }
}
