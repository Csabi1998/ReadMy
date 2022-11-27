import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './pages/auth/auth.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { EditProjectComponent } from './pages/projects/edit-project/edit-project.component';
import { ProjectDetailsComponent } from './pages/projects/project-details/project-details.component';
import { ProjectsComponent } from './pages/projects/projects.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'projects', component: ProjectsComponent },
  { path: 'projects/new', component: EditProjectComponent },
  { path: 'projects/:id', component: ProjectDetailsComponent },
  { path: '**', redirectTo: '/auth' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
