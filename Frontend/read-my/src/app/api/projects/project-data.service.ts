import { Injectable } from '@angular/core';
import { BehaviorSubject, combineLatest, flatMap, tap } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectService } from './project.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectDataService {
  constructor(private projectService: ProjectService) {}

  projects = new BehaviorSubject<ProjectResponse[]>([]);
  selectedProject = new BehaviorSubject<ProjectResponse | undefined>(undefined);

  setSelectedProject(id: string) {
    this.selectedProject.next(this.getProjectById(id));
  }

  clearSelectedProject() {
    this.selectedProject.next(undefined);
  }

  getProjectById(id: string) {
    return this.projects.value.find((project) => project.id === id);
  }

  fetchProjects() {
    return this.projectService.getAllProjects().pipe(
      tap((projects) => {
        this.projects.next(projects);
      })
    );
  }

  fetchProjectById(id: string) {
    return this.projectService.getProjectById(id).pipe(
      tap((project) => {
        console.log(project);
        this.selectedProject.next(project);
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

  addParticipantToProject(projektId: string, userId: string) {
    return this.projectService
      .addParticipant({
        projektId,
        userId,
      })
      .pipe(
        flatMap(() =>
          combineLatest(this.fetchProjectById(projektId), this.fetchProjects())
        )
      );
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

  deleteProject(id: string) {
    return this.projectService
      .deleteProject(id)
      .pipe(flatMap(() => this.fetchProjects()));
  }
}
