import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { UserResponse } from './models/userResponse';
import { UserDataService } from './user-data.service';

@Injectable({
  providedIn: 'root',
})
export class UserResolverService implements Resolve<UserResponse[]> {
  constructor(private userDataService: UserDataService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): UserResponse[] | Observable<UserResponse[]> | Promise<UserResponse[]> {
    const users = this.userDataService.users.value;

    if (users.length === 0) {
      return this.userDataService.fetchUsers();
    } else {
      return users;
    }
  }
}
