import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, tap } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { CreateProjectDto } from './models/createProjectDto';
import { CreateProjectResponse } from './models/createProjectResponse';
import { ProjectsListResponse } from './models/projectsListResponse';

import handleError from '../handleError';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  constructor(private httpClient: HttpClient) {}

  createProject(
    createProjectDto: CreateProjectDto
  ): Observable<CreateProjectResponse> {
    return this.httpClient.post('Projects', createProjectDto).pipe(
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }

  getAllProjects(): Observable<ProjectResponse[]> {
    return this.httpClient.get('Projects').pipe(
      map((projectList: ProjectsListResponse) => projectList.projects ?? []),
      tap((response) => console.log(response)),
      catchError(handleError)
    );
  }
}
