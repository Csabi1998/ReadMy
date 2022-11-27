import { Location } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectDataService } from './../../../api/projects/project-data.service';

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css'],
})
export class EditProjectComponent implements OnInit, AfterViewInit {
  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private projectDataService: ProjectDataService,
    private toastr: ToastrService
  ) {}

  @ViewChild('projectForm', { static: false }) projectForm!: NgForm;

  isLoading = false;
  projectId?: string;
  projectUnderEdit?: ProjectResponse;

  ngAfterViewInit(): void {
    if (!this.isNew) {
      setTimeout(() => {
        this.projectForm.setValue({
          projectName: this.projectUnderEdit!.name,
          description: this.projectUnderEdit!.description,
        });
      }, 1);
    }
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
    });
    if (!this.isNew) {
      this.projectUnderEdit = this.projectDataService.getProjectById(
        this.projectId!
      );
      if (this.projectUnderEdit === undefined) {
        this.toastr.error('Project not found');
        this.location.back();
      }

      console.log(this.projectUnderEdit);
    }
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
      const updateProjObs = this.projectDataService.updateProject(
        name,
        description,
        this.projectId!
      );

      updateProjObs.subscribe({
        next: (resData) => {
          this.isLoading = false;
          this.toastr.success('Project updated!');
          this.back();
        },
        error: (errorMessage) => {
          console.log(errorMessage);
          this.toastr.error(errorMessage);
          this.isLoading = false;
        },
      });
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
