import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectDataService } from './project-data.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectResolverService implements Resolve<ProjectResponse[]> {
  constructor(
    private projectDataService: ProjectDataService,
    private router: Router,
    private toastr: ToastrService
  ) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | ProjectResponse[]
    | Observable<ProjectResponse[]>
    | Promise<ProjectResponse[]> {
    const projects = this.projectDataService.projects.value;

    if (projects.length === 0) {
      let fetchedProjects: ProjectResponse[] = [];
      this.projectDataService.fetchProjects().subscribe({
        next: (projects) => {
          fetchedProjects = projects.slice();
        },
        error: (err) => {
          {
            fetchedProjects = [];
            this.toastr.warning(
              'Go back quickly before they notice!',
              'Who goes here?!'
            );
            this.router.navigate(['/']);
          }
        },
      });
      return fetchedProjects;
    } else {
      return projects;
    }
  }
}
