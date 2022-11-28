import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, tap } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { AddProjectParticipantDto } from './models/addProjectParticipantDto';
import { CreateProjectDto } from './models/createProjectDto';
import { CreateProjectResponse } from './models/createProjectResponse';
import { DeleteEntityResponse } from './models/deleteEntityResponse';
import { ProjectsListResponse } from './models/projectsListResponse';
import { UpdateProjectDto } from './models/updateProjectDto';
import { UpdateProjectResponse } from './models/updateProjectResponse';

import handleError from '../handleError';
import { UpdateEntityResponse } from './models/updateEntityResponse';

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
    console.log('getAllProjects called');
    return this.httpClient.get('Projects').pipe(
      map((projectList: ProjectsListResponse) => projectList.projects ?? []),
      tap((response) => console.log(response)),
      catchError(handleError)
    );
  }

  updateProject(
    updateDto: UpdateProjectDto
  ): Observable<UpdateProjectResponse> {
    return this.httpClient.put('Projects', updateDto).pipe(
      tap((response) => console.log(response)),
      catchError(handleError)
    );
  }

  deleteProject(id: string): Observable<DeleteEntityResponse> {
    return this.httpClient.delete(`Projects/${id}`).pipe(
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }

  getProjectById(projectId: string): Observable<ProjectResponse> {
    return this.httpClient.get(`Projects/${projectId}`).pipe(
      tap((response: any) => console.log(response)),
      catchError(handleError)
    );
  }

  addParticipant(
    addProjectParticipantDto: AddProjectParticipantDto
  ): Observable<UpdateEntityResponse> {
    return this.httpClient
      .put('Projects/participant', addProjectParticipantDto)
      .pipe(
        tap((response: any) => console.log(response)),
        catchError(handleError)
      );
  }
}
