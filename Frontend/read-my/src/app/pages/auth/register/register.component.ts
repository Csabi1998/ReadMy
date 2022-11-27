import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  isLoading = false;

  constructor() {}

  onSubmit(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }
  }
}
