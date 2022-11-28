import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectDataService } from 'src/app/api/projects/project-data.service';
import { TaskUnitResponse } from 'src/app/api/tasks/models/taskunitResponse';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent implements OnInit, OnDestroy {
  constructor(
    private route: ActivatedRoute,
    private projectDataService: ProjectDataService,
    private taskDataService: TaskDataService,
    private authService: AuthService
  ) {}
  project!: ProjectResponse;
  taskList: TaskUnitResponse[] = [];
  projectSub!: Subscription;
  taskListSub!: Subscription;
  projectId?: string;

  get isWorker(): boolean {
    return this.authService.isWorker;
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
      this.projectSub = this.projectDataService.selectedProject.subscribe(
        (project) => {
          this.project = project!;
        }
      );
      this.taskListSub = this.taskDataService.tasks.subscribe((taskList) => {
        this.taskList = taskList.slice();
      });
      let project = this.projectDataService.selectedProject.value;

      this.project = project!;

      this.taskList = this.taskDataService.tasks.value.slice();
    });
  }

  ngOnDestroy() {
    this.projectSub.unsubscribe();
    this.taskListSub.unsubscribe();
  }
}
