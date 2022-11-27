import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectService } from './project.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectDataService {
  constructor(private projectService: ProjectService) {}

  projects = new BehaviorSubject<ProjectResponse[]>([]);

  fetchProjects() {
    return this.projectService.getAllProjects().pipe(
      tap((projects) => {
        this.projects.next(projects);
      })
    );
  }

  addProject(name: string, description: string) {
    return this.projectService
      .createProject({
        name,
        description,
      })
      .pipe(tap(() => this.fetchProjects()));
  }
}
