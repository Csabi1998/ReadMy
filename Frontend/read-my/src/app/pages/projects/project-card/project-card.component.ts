import { Location } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProjectDataService } from 'src/app/api/projects/project-data.service';
import { ProjectResponse } from './../../../api/projects/models/projectResponse';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.css'],
})
export class ProjectCardComponent {
  constructor(
    private location: Location,
    private projectDataService: ProjectDataService,
    private toastr: ToastrService
  ) {}
  @Input() project!: ProjectResponse;
  @Input() shouldShowDetailsButton: boolean = true;
  @Input() shouldShowEditAndDeleteButton: boolean = false;
  @Input() shouldShowBackButton: boolean = false;

  back(): void {
    this.location.back();
  }

  get participants() {
    return this.project.participants.map((p) => p.name).join(', ');
  }

  deleteProject(): void {
    const obs = this.projectDataService.deleteProject(this.project.id);

    obs.subscribe({
      next: (resData) => {
        this.toastr.success('Project deleted!');
        if (this.shouldShowBackButton) this.back();
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage);
      },
    });
  }
}
