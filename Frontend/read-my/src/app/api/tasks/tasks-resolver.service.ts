import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';

@Injectable({
  providedIn: 'root',
})
export class TasksResolverService implements Resolve<TaskUnitResponse[]> {
  constructor(private taskDataService: TaskDataService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | TaskUnitResponse[]
    | Observable<TaskUnitResponse[]>
    | Promise<TaskUnitResponse[]> {
    const projectId = route.params['id'];
    console.log('fetching tasks for project: ' + projectId);
    return this.taskDataService.fetchTasks(projectId);
  }
}
