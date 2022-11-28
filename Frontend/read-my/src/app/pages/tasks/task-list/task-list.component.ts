import { Component, Input } from '@angular/core';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
})
export class TaskListComponent {
  @Input('tasks') tasks: TaskUnitResponse[] = [];
}
