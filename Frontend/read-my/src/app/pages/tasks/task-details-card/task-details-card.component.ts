import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';
import { TaskUnitResponse } from './../../../api/tasks/models/taskunitResponse';

@Component({
  selector: 'app-task-details-card',
  templateUrl: './task-details-card.component.html',
  styleUrls: ['./task-details-card.component.css'],
})
export class TaskDetailsCardComponent implements OnInit {
  constructor(
    private location: Location,
    private taskDataService: TaskDataService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  @Input() shouldShowEditAndDeleteButton: boolean = false;
  @Input() task!: TaskUnitResponse;
  projectId!: string;

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
    });
  }

  back(): void {
    this.location.back();
  }

  deleteTask(): void {
    const obs = this.taskDataService.deleteTask(this.task.id, this.projectId);

    obs.subscribe({
      next: (resData) => {
        this.toastr.success('Task deleted!');
        this.back();
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage);
      },
    });
  }
}
