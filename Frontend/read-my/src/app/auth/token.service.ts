import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { UserData } from '../api/users/models/userData';
import { AppConstants } from './../common/app-constants';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  public set token(value: string | null) {
    console.log(value);
    if (value) localStorage.setItem(AppConstants.TOKEN_KEY, value);
  }

  public get token() {
    return localStorage.getItem(AppConstants.TOKEN_KEY);
  }

  public get userData() {
    const token = localStorage.getItem(AppConstants.TOKEN_KEY);
    if (token === null) return null;
    const userData = jwt_decode<UserData>(token);
    console.log(userData);
    return userData;
  }

  public removeToken() {
    localStorage.removeItem(AppConstants.TOKEN_KEY);
  }
}
