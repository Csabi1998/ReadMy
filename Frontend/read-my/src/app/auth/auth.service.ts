import { Injectable } from '@angular/core';
import { BehaviorSubject, map, take } from 'rxjs';
import { LoginResponse } from '../api/users/models/loginResponse';
import { UserData } from '../api/users/models/userData';
import { UserService } from './../api/users/user.service';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user = new BehaviorSubject<UserData | null>(null);

  constructor(
    private tokenService: TokenService,
    private userService: UserService
  ) {}

  public login(username: string, password: string) {
    this.userService
      .login({ userName: username, password: password })
      .subscribe({
        next: this.handleAuth,
        error: (e) => console.error(e),
      });
  }

  public logout() {
    this.user.next(null);
    this.tokenService.removeToken();
  }

  private handleAuth(res: LoginResponse) {
    this.tokenService.token = res.token || null;
    this.user.next(this.tokenService.userData);
  }

  public autoLogin() {
    const userData = this.tokenService.userData;
    if (!userData) return;
    this.user.next(userData);
  }

  public get isLoggedIn() {
    return this.user.pipe(
      take(1),
      map((user) => user !== null)
    );
  }

  public get isAdmin() {
    return this.user.pipe(
      take(1),
      map((user) => user?.isAdmin ?? false)
    );
  }

  public get isWorker() {
    return this.user.pipe(
      take(1),
      map((user) => user?.isWorker ?? false)
    );
  }
  public get isPM() {
    return this.user.pipe(
      take(1),
      map((user) => user?.isPM ?? false)
    );
  }
}
