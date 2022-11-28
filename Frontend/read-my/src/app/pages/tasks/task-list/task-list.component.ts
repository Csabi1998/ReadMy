import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
})
export class TaskListComponent implements OnInit {
  @Input('tasks') tasks: TaskUnitResponse[] = [];

  constructor(
    private taskDataService: TaskDataService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
    });
  }

  projectId!: string;

  deleteTask(taskId: string) {
    const obs = this.taskDataService.deleteTask(taskId, this.projectId);

    obs.subscribe({
      next: (resData) => {
        this.toastr.success('Task deleted!');
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage);
      },
    });
  }
}
