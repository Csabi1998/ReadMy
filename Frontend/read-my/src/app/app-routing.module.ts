import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './pages/auth/auth.component';
import { ProjectDetailsComponent } from './pages/projects/project-details/project-details.component';
import { ProjectsComponent } from './pages/projects/projects.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'projects', component: ProjectsComponent },
  { path: 'projects/:id', component: ProjectDetailsComponent },
  { path: '**', redirectTo: '/auth' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
