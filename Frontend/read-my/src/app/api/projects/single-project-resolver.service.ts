import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ProjectResponse } from './models/projectResponse';
import { ProjectDataService } from './project-data.service';

@Injectable({
  providedIn: 'root',
})
export class SingleProjectResolverService implements Resolve<ProjectResponse> {
  constructor(
    private projectDataService: ProjectDataService,
    private router: Router,
    private toastr: ToastrService
  ) {}
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
      let fetchedProject!: ProjectResponse;
      this.projectDataService.fetchProjectById(route.params['id']).subscribe({
        next: (project) => {
          fetchedProject = project;
        },
        error: (err) => {
          {
            this.toastr.warning(
              'Go back quickly before they notice!',
              'Who goes here?!'
            );
            this.router.navigate(['/']);
          }
        },
      });
      return fetchedProject;
    }
  }
}
