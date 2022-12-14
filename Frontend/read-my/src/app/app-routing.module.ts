import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogResolverService } from './api/logs/log-resolver.service';
import { ProjectResolverService } from './api/projects/project-resolver.service';
import { SingleProjectResolverService } from './api/projects/single-project-resolver.service';
import { SingleTaskResolverService } from './api/tasks/single-task-resolver.service';
import { TasksResolverService } from './api/tasks/tasks-resolver.service';
import { UserResolverService } from './api/users/user-resolver.service';
import { AdminGuard } from './auth/admin.guard';
import { AuthGuard } from './auth/auth.guard';
import { PmGuard } from './auth/pm.guard';
import { AuthComponent } from './pages/auth/auth.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { EditLogItemComponent } from './pages/logs/edit-log-item/edit-log-item.component';
import { MyLogsComponent } from './pages/logs/my-logs/my-logs.component';
import { EditProjectComponent } from './pages/projects/edit-project/edit-project.component';
import { ProjectDetailsComponent } from './pages/projects/project-details/project-details.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { EditTaskComponent } from './pages/tasks/edit-task/edit-task.component';
import { TaskDetailsComponent } from './pages/tasks/task-details/task-details.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'register',
        canActivate: [AdminGuard],
        component: RegisterComponent,
      },
      {
        path: 'projects',
        resolve: [ProjectResolverService],
        component: ProjectsComponent,
      },
      {
        path: 'projects/new',
        component: EditProjectComponent,
        canActivate: [PmGuard],
      },
      {
        path: 'projects/:id',
        resolve: [SingleProjectResolverService, TasksResolverService],
        component: ProjectDetailsComponent,
      },
      { path: 'projects/:id/tasks/new', component: EditTaskComponent },
      {
        path: 'projects/:id/tasks/:taskId/edit',
        resolve: [TasksResolverService],
        canActivate: [PmGuard],

        component: EditTaskComponent,
      },
      {
        path: 'projects/:id/tasks/:taskId',
        resolve: [SingleTaskResolverService, LogResolverService],
        component: TaskDetailsComponent,
      },
      {
        path: 'projects/:id/tasks/:taskId/logs/new',
        component: EditLogItemComponent,
      },
      {
        path: 'my-logs',
        resolve: [LogResolverService],
        component: MyLogsComponent,
      },
      {
        path: 'projects/:id/tasks/:taskId/logs/:logId/edit',
        component: EditLogItemComponent,
      },

      {
        path: 'projects/:id/edit',
        resolve: [ProjectResolverService, UserResolverService],
        component: EditProjectComponent,
        canActivate: [PmGuard],
      },
      { path: '**', redirectTo: '/projects' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
