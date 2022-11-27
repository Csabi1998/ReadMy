import { Location } from '@angular/common';
import { Component, Input } from '@angular/core';
import { TaskUnitResponse } from './../../../api/tasks/models/taskunitResponse';

@Component({
  selector: 'app-task-details-card',
  templateUrl: './task-details-card.component.html',
  styleUrls: ['./task-details-card.component.css'],
})
export class TaskDetailsCardComponent {
  constructor(private location: Location) {}

  @Input() shouldShowEditAndDeleteButton: boolean = false;
  @Input() task!: TaskUnitResponse;

  back(): void {
    this.location.back();
  }
}
