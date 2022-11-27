import { Component } from '@angular/core';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css'],
})
export class TaskDetailsComponent {
  task: TaskUnitResponse = {
    id: '1',
    name: 'Task 1',
    description: 'Task 1 description',
    type: 'Meeting',
    sumOfLogs: 234,
    creationDate: new Date(),
    serialNumber: '91346590',
  };
}
