import { Injectable } from '@angular/core';
import { BehaviorSubject, flatMap, tap } from 'rxjs';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskService } from './task.service';

@Injectable({
  providedIn: 'root',
})
export class TaskDataService {
  constructor(private taskService: TaskService) {}

  tasks = new BehaviorSubject<TaskUnitResponse[]>([]);
  selectedTask = new BehaviorSubject<TaskUnitResponse | undefined>(undefined);

  setSelectedTask(id: string) {
    this.selectedTask.next(this.getTaskById(id));
  }

  clearTasks() {
    this.tasks.next([]);
    this.selectedTask.next(undefined);
  }

  fetchTasks(projectId: string) {
    return this.taskService.getTasksOfProject(projectId).pipe(
      tap((tasks) => {
        this.tasks.next(tasks);
      })
    );
  }

  getTaskById(id: string) {
    return this.tasks.value.find((task) => task.id === id);
  }

  fetchTaskById(id: string) {
    return this.taskService.getTaskById(id).pipe(
      tap((task) => {
        this.selectedTask.next(task);
      })
    );
  }

  createTask(
    name: string,
    description: string,
    type: string,
    projectId: string
  ) {
    return this.taskService
      .createTask({
        name,
        description,
        type,
        projectId,
      })
      .pipe(flatMap(() => this.fetchTasks(projectId)));
  }

  updateTask(
    name: string,
    description: string,
    id: string,
    type: string,
    projectId: string
  ) {
    return this.taskService
      .updateTask({
        name,
        description,
        id,
        type,
      })
      .pipe(flatMap(() => this.fetchTasks(projectId)));
  }

  deleteTask(id: string, projectId: string) {
    return this.taskService
      .deleteTask(id)
      .pipe(flatMap(() => this.fetchTasks(projectId)));
  }
}
