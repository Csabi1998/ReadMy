import { Location } from '@angular/common';
import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { ProjectResponse } from 'src/app/api/projects/models/projectResponse';
import { ProjectDataService } from './../../../api/projects/project-data.service';
import { UserDataService } from './../../../api/users/user-data.service';

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css'],
})
export class EditProjectComponent implements OnInit, AfterViewInit, OnDestroy {
  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private projectDataService: ProjectDataService,
    private userDataService: UserDataService,
    private toastr: ToastrService
  ) {}

  @ViewChild('projectForm', { static: false }) projectForm!: NgForm;
  @ViewChild('addParticipantForm', { static: false })
  addParticipantForm!: NgForm;

  isLoading = false;
  projectId?: string;
  projectUnderEdit?: ProjectResponse;
  subscription?: Subscription;

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

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  get possibleNewParticipants() {
    const results = this.userDataService.users.value.slice().filter((user) => {
      return !(
        this.projectUnderEdit!.participants.some((participant) => {
          return participant.id === user.id;
        }) || user.id === this.projectUnderEdit!.creator.id
      );
    });
    return results;
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.projectId = params['id'];
    });
    if (!this.isNew) {
      this.projectDataService.setSelectedProject(this.projectId!);
      this.subscription = this.projectDataService.selectedProject.subscribe(
        (project) => {
          this.projectUnderEdit = project;
        }
      );
      if (this.projectUnderEdit === undefined) {
        this.toastr.error('Project not found');
        this.location.back();
      }
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

    const addParticipantObs = this.projectDataService.addParticipantToProject(
      this.projectId!,
      form.value.participantSelector
    );

    addParticipantObs.subscribe({
      next: (resData) => {
        this.isLoading = false;
        this.toastr.success('Participant added');
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage);
        this.isLoading = false;
      },
    });

    this.addParticipantForm.setValue({
      participantSelector: '',
    });
  }

  back(): void {
    this.location.back();
  }
}
