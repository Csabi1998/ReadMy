import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProjectDataService } from './../../../api/projects/project-data.service';

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css'],
})
export class EditProjectComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private projectDataService: ProjectDataService,
    private toastr: ToastrService
  ) {}
  isLoading = false;
  projectId?: string;

  participants = ['Participant 1', 'Participant 2'];

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
    });
  }

  get isNew() {
    return this.projectId === undefined;
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }

    const name = form.value.projectName;
    const description = form.value.description;

    this.isLoading = true;
    if (this.isNew) {
      const createProjObs = this.projectDataService.addProject(
        name,
        description
      );

      createProjObs.subscribe({
        next: (resData) => {
          this.isLoading = false;
          this.toastr.success('Project created!');
          this.back();
        },
        error: (errorMessage) => {
          console.log(errorMessage);
          this.toastr.error(errorMessage);
          this.isLoading = false;
        },
      });
    } else {
    }

    form.reset();
  }

  onSubmitNewParticipant(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }
  }

  back(): void {
    this.location.back();
  }
}
