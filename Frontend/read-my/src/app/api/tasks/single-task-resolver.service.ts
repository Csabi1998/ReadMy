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
export class SingleTaskResolverService implements Resolve<TaskUnitResponse> {
  constructor(private taskDataService: TaskDataService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | TaskUnitResponse
    | Observable<TaskUnitResponse>
    | Promise<TaskUnitResponse> {
    const currentlyNeededTask = this.taskDataService.getTaskById(
      route.params['taskId']
    );
    if (currentlyNeededTask) {
      this.taskDataService.setSelectedTask(currentlyNeededTask.id);
      return currentlyNeededTask;
    } else {
      return this.taskDataService.fetchTaskById(route.params['taskId']);
    }
  }
}
