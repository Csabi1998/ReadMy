import { Component } from '@angular/core';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent {
  projectDetails = {
    project: {
      id: '1',
      name: 'Project 1',
      description: 'Description 1',
      creator: 'Creator 1',
      creationDate: new Date(),
      praticipants: ['Participant 1', 'Participant 2'],
    },
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
