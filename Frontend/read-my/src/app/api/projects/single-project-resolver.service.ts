import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectResponse } from './models/projectResponse';
import { ProjectDataService } from './project-data.service';

@Injectable({
  providedIn: 'root',
})
export class SingleProjectResolverService implements Resolve<ProjectResponse> {
  constructor(private projectDataService: ProjectDataService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): ProjectResponse | Observable<ProjectResponse> | Promise<ProjectResponse> {
    const currentlyNeededProject = this.projectDataService.getProjectById(
      route.params['id']
    );
    if (currentlyNeededProject) {
      this.projectDataService.setSelectedProject(currentlyNeededProject.id);
      return currentlyNeededProject;
    } else {
      console.log('fetching project with id: ' + route.params['id']);
      return this.projectDataService.fetchProjectById(route.params['id']);
    }
  }
}
