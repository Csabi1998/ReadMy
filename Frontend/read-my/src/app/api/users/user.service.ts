import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, tap } from 'rxjs';
import handleError from '../handleError';
import { LoginDto } from './models/loginDto';
import { LoginResponse } from './models/loginResponse';
import { UserResponse } from './models/userResponse';
import { UsersListResponse } from './models/usersListResponse';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  getAllUsers(): Observable<UserResponse[]> {
    return this.httpClient.get('Users').pipe(
      map(
        (userListResponse: UsersListResponse) => userListResponse.users ?? []
      ),
      tap((users) => console.log(users)),
      catchError(handleError)
    );
  }

  login(loginDto: LoginDto): Observable<LoginResponse> {
    return this.httpClient.post('Users/login', loginDto).pipe(
      tap((response) => console.log(response)),
      catchError(handleError)
    );
  }
}
