import { Component } from '@angular/core';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent {
  project: ProjectResponse = {
    id: '1',
    name: 'Project 1',
    description: 'Project 1 description',
    participants: [],
    creationDate: new Date(),
    creator: {
      id: '1',
      name: 'User 1',
    },
  };

  projectDetails = {
    project: this.project,
    tasks: [
      {
        id: '1',
        name: 'Task 1',
        description: 'Description 1',
        type: 'Meeting',
        totalHours: 10,
      },
      {
        id: '2',
        name: 'Task 2',
        description: 'Description 1',
        type: 'Meeting',
        totalHours: 10,
      },
      {
        id: '3',
        name: 'Task 3',
        description: 'Description 1',
        type: 'Meeting',
        totalHours: 10,
      },
    ],
  };
}
