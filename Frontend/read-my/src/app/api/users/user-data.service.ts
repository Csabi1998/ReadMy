import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { UserResponse } from './models/userResponse';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class UserDataService {
  constructor(private userService: UserService) {}

  users = new BehaviorSubject<UserResponse[]>([]);

  fetchUsers() {
    return this.userService.getAllUsers().pipe(
      tap((users) => {
        this.users.next(users);
      })
    );
  }
}
