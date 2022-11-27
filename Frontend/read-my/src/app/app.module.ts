import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InterceptorService } from './auth/interceptor.service';

import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoaderComponent } from './common/components/loader/loader.component';
import { NavbarComponent } from './common/components/navbar/navbar.component';
import { ArrowDownIconComponent } from './common/icons/arrow-down-icon/arrow-down-icon.component';
import { ArrowUpIconComponent } from './common/icons/arrow-up-icon/arrow-up-icon.component';
import { DeleteIconComponent } from './common/icons/delete-icon/delete-icon.component';
import { EditIconComponent } from './common/icons/edit-icon/edit-icon.component';
import { AuthComponent } from './pages/auth/auth.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { EditLogItemComponent } from './pages/logs/edit-log-item/edit-log-item.component';
import { LogItemComponent } from './pages/logs/log-item/log-item.component';
import { LogListComponent } from './pages/logs/log-list/log-list.component';
import { EditProjectComponent } from './pages/projects/edit-project/edit-project.component';
import { ProjectCardComponent } from './pages/projects/project-card/project-card.component';
import { ProjectDetailsComponent } from './pages/projects/project-details/project-details.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { EditTaskComponent } from './pages/tasks/edit-task/edit-task.component';
import { TaskDetailsComponent } from './pages/tasks/task-details/task-details.component';
import { TaskListComponent } from './pages/tasks/task-list/task-list.component';
import { TaskDetailsCardComponent } from './pages/tasks/task-details-card/task-details-card.component';
import { MyLogsComponent } from './pages/logs/my-logs/my-logs.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AuthComponent,
    LoaderComponent,
    ProjectsComponent,
    ProjectCardComponent,
    ProjectDetailsComponent,
    TaskListComponent,
    ArrowUpIconComponent,
    ArrowDownIconComponent,
    EditTaskComponent,
    EditProjectComponent,
    LogItemComponent,
    LogListComponent,
    EditLogItemComponent,
    RegisterComponent,
    TaskDetailsComponent,
    EditIconComponent,
    DeleteIconComponent,
    TaskDetailsCardComponent,
    MyLogsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
