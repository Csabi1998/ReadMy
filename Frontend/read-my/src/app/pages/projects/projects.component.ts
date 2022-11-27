import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectDataService } from 'src/app/api/projects/project-data.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent implements OnInit, OnDestroy {
  projects: ProjectResponse[] = [];
  subscription!: Subscription;

  constructor(private projectDataService: ProjectDataService) {}

  ngOnInit() {
    this.subscription = this.projectDataService.projects.subscribe(
      (projects: ProjectResponse[]) => {
        this.projects = projects.slice();
      }
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
