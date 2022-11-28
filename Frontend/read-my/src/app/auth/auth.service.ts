import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { TaskDataService } from 'src/app/api/tasks/task-data.service';
import { LogsDataService } from '../api/logs/logs-data.service';
import { ProjectDataService } from '../api/projects/project-data.service';
import { LoginResponse } from '../api/users/models/loginResponse';
import { UserData } from '../api/users/models/userData';
import { UserDataService } from '../api/users/user-data.service';
import { UserService } from './../api/users/user.service';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user = new BehaviorSubject<UserData | null>(null);

  constructor(
    private tokenService: TokenService,
    private userService: UserService,
    private router: Router,
    private taskDataService: TaskDataService,
    private logsDataService: LogsDataService,
    private projectDataService: ProjectDataService,
    private userDataService: UserDataService
  ) {}

  public login(username: string, password: string): Observable<any> {
    return this.userService
      .login({ userName: username, password: password })
      .pipe(tap(this.handleAuth));
  }

  public logout() {
    this.user.next(null);
    this.tokenService.removeToken();
    this.logsDataService.clearLogs();
    this.userDataService.clearUsers();
    this.taskDataService.clearTasks();
    this.projectDataService.clearProjects();

    this.router.navigate(['/auth']);
  }

  private handleAuth = (res: LoginResponse) => {
    this.tokenService.token = res.token || null;
    this.user.next(this.tokenService.userData);
  };

  public autoLogin() {
    const userData = this.tokenService.userData;
    if (!userData) return;
    this.user.next(userData);
  }

  public get isLoggedIn() {
    return this.user.value !== null;
  }

  public get isAdmin() {
    return this.user.value?.isAdmin;
  }

  public get isWorker() {
    return this.user.value?.isWorker ?? false;
  }
  public get isPM() {
    return this.user.value?.isPM ?? false;
  }
}
