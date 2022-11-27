import { Injectable } from '@angular/core';
import { BehaviorSubject, flatMap, tap } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectService } from './project.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectDataService {
  constructor(private projectService: ProjectService) {}

  projects = new BehaviorSubject<ProjectResponse[]>([]);

  getProjectById(id: string) {
    console.log(this.projects.value, id);
    return this.projects.value.find((project) => project.id === id);
  }

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
      .pipe(flatMap(() => this.fetchProjects()));
  }

  updateProject(name: string, description: string, id: string) {
    return this.projectService
      .updateProject({
        name,
        description,
        id,
      })
      .pipe(flatMap(() => this.fetchProjects()));
  }
}
