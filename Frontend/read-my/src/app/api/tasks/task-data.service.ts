import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskService } from './task.service';

@Injectable({
  providedIn: 'root',
})
export class TaskDataService {
  constructor(private taskService: TaskService) {}

  tasks = new BehaviorSubject<TaskUnitResponse[]>([]);

  fetchTasks(projectId: string) {
    return this.taskService.getTasksOfProject(projectId).pipe(
      tap((tasks) => {
        this.tasks.next(tasks);
      })
    );
  }
}
