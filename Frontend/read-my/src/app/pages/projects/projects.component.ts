import { Component } from '@angular/core';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent {
  public projects: Array<ProjectResponse> = [
    {
      id: '1',
      name: 'Project 1',
      description: 'Description 1',
      creator: 'Creator 1',
      creationDate: new Date(),
      praticipants: ['Participant 1', 'Participant 2'],
    },
    {
      id: '2',
      name: 'Project 2',
      description: 'Description 2',
      creator: 'Creator 2',
      creationDate: new Date(),
      praticipants: ['Participant 1', 'Participant 2'],
    },
    {
      id: '3',
      name: 'Project 2',
      description: 'Description 2',
      creator: 'Creator 2',
      creationDate: new Date(),
      praticipants: ['Participant 1', 'Participant 2'],
    },
    {
      id: '4',
      name: 'Project 2',
      description: 'Description 2',
      creator: 'Creator 2',
      creationDate: new Date(),
      praticipants: ['Participant 1', 'Participant 2'],
    },
  ];
}
