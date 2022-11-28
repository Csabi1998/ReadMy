import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';
import { LogsDataService } from './../../../api/logs/logs-data.service';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css'],
})
export class TaskDetailsComponent implements OnInit, OnDestroy {
  constructor(
    private route: ActivatedRoute,
    private logsDataService: LogsDataService,
    private taskDataService: TaskDataService
  ) {}
  task!: TaskUnitResponse;

  taskSub!: Subscription;
  projectId!: string;
  taskId!: string;

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
      this.taskId = params['taskId'];
      this.taskSub = this.taskDataService.selectedTask.subscribe((task) => {
        this.task = task!;
      });

      this.task = this.taskDataService.selectedTask.value!;
    });
  }

  ngOnDestroy() {
    this.taskSub.unsubscribe();
  }
}
