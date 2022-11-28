import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, tap } from 'rxjs';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import handleError from '../handleError';
import { DeleteEntityResponse } from '../projects/models/deleteEntityResponse';
import { CreateTaskunitDto } from './models/createTaskunitDto';
import { CreateTaskunitResponse } from './models/createTaskunitResponse';
import { TaskUnitsListResponse } from './models/taskUnitsListResponse';
import { UpdateTaskunitDto } from './models/updateTaskunitDto';
import { UpdateTaskunitResponse } from './models/updateTaskunitResponse';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor(private httpClient: HttpClient) {}

  getTasksOfProject(projectId: string): Observable<TaskUnitResponse[]> {
    return this.httpClient.get(`Tasks/list/${projectId}`).pipe(
      map((taskList: TaskUnitsListResponse) => taskList.tasks ?? []),
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }

  createTask(
    createTaskunitDto: CreateTaskunitDto
  ): Observable<CreateTaskunitResponse> {
    return this.httpClient.post('Tasks', createTaskunitDto).pipe(
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }

  updateTask(updateDto: UpdateTaskunitDto): Observable<UpdateTaskunitResponse> {
    return this.httpClient.put('Tasks', updateDto).pipe(
      tap((response) => console.log(response)),
      catchError(handleError)
    );
  }

  deleteTask(id: string): Observable<DeleteEntityResponse> {
    return this.httpClient.delete(`Tasks/${id}`).pipe(
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }

  getTaskById(projectId: string): Observable<TaskUnitResponse> {
    return this.httpClient.get(`Tasks/${projectId}`).pipe(
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }
}
