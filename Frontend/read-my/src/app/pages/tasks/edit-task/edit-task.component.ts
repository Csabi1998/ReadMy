import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css'],
})
export class EditTaskComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location
  ) {}
  isLoading = false;
  taskId?: string;

  onSubmit(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }
  }

  get isNew() {
    return this.taskId === undefined;
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.taskId = params['taskId'];
    });
  }

  back(): void {
    this.location.back();
  }
}
