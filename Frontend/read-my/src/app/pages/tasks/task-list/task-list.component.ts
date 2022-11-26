import { Component } from '@angular/core';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
})
export class TaskListComponent {
  tasks = [
    {
      id: '1',
      name: 'Task 1',
      description: 'Description 1',
      type: 'Meeting',
      totalHours: 10,
    },
    {
      id: '2',
      name: 'Task 2',
      description: 'Description 1',
      type: 'Meeting',
      totalHours: 10,
    },
    {
      id: '3',
      name: 'Task 3',
      description: 'Description 1',
      type: 'Meeting',
      totalHours: 10,
    },
  ];
}
