import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css'],
})
export class EditProjectComponent implements OnInit {
  constructor(private route: ActivatedRoute, private router: Router) {}
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
  }

  onSubmitNewParticipant(form: NgForm) {
    console.log(form.value);
    if (!form.valid) {
      return;
    }
  }
}
