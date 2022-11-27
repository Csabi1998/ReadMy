import { Location } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ProjectResponse } from './../../../api/projects/models/projectResponse';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.css'],
})
export class ProjectCardComponent {
  constructor(private location: Location) {}
  @Input() project!: ProjectResponse;
  @Input() shouldShowDetailsButton: boolean = true;
  @Input() shouldShowEditAndDeleteButton: boolean = false;
  @Input() shouldShowBackButton: boolean = false;

  back(): void {
    this.location.back();
  }
}
