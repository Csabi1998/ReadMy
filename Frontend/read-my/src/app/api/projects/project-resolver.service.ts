import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectDataService } from './project-data.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectResolverService implements Resolve<ProjectResponse[]> {
  constructor(private projectDataService: ProjectDataService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | ProjectResponse[]
    | Observable<ProjectResponse[]>
    | Promise<ProjectResponse[]> {
    const projects = this.projectDataService.projects.value;

    if (projects.length === 0) {
      return this.projectDataService.fetchProjects();
    } else {
      return projects;
    }
  }
}
