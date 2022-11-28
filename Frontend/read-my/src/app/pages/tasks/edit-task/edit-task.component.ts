import { Location } from '@angular/common';
import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css'],
})
export class EditTaskComponent implements OnInit, AfterViewInit, OnDestroy {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private taskDataService: TaskDataService,
    private toastr: ToastrService
  ) {}

  isLoading = false;
  taskId?: string;
  projectId!: string;
  taskUnderEdit?: TaskUnitResponse;
  subscription?: Subscription;
  @ViewChild('taskForm', { static: false }) taskForm!: NgForm;

  onSubmit(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }

    const name = form.value.taskTitle;
    const description = form.value.description;
    const type = form.value.taskTypeSelector;
    this.isLoading = true;

    if (this.isNew) {
      const createTaskObs = this.taskDataService.createTask(
        name,
        description,
        type,
        this.projectId
      );

      createTaskObs.subscribe({
        next: (resData) => {
          this.isLoading = false;
          this.toastr.success('Task created!');
          this.back();
        },
        error: (errorMessage) => {
          console.log(errorMessage);
          this.toastr.error(errorMessage);
          this.isLoading = false;
        },
      });
    } else {
      const updateTaskObs = this.taskDataService.updateTask(
        name,
        description,
        this.taskId!,
        type,
        this.projectId!
      );

      updateTaskObs.subscribe({
        next: (resData) => {
          this.isLoading = false;
          this.toastr.success('Task updated!');
          this.back();
        },
        error: (errorMessage) => {
          console.log(errorMessage);
          this.toastr.error(errorMessage);
          this.isLoading = false;
        },
      });
    }

    form.reset();
  }

  get isNew() {
    return this.taskId === undefined;
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
  ngAfterViewInit(): void {
    if (!this.isNew) {
      setTimeout(() => {
        this.taskForm.setValue({
          taskTitle: this.taskUnderEdit!.name,
          description: this.taskUnderEdit!.description,
          taskTypeSelector: this.taskUnderEdit!.type,
        });
      }, 1);
    }
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.taskId = params['taskId'];
      this.projectId = params['id'];
    });
    if (!this.isNew) {
      this.taskDataService.setSelectedTask(this.taskId!);
      this.subscription = this.taskDataService.selectedTask.subscribe(
        (task) => {
          this.taskUnderEdit = task;
        }
      );
      if (this.taskUnderEdit === undefined) {
        this.toastr.error('Task not found');
        this.location.back();
      }
    }
  }

  back(): void {
    this.location.back();
  }
}
