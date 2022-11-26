import { Injectable } from '@angular/core';
import { AppConstants } from './../common/app-constants';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  public set token(value: string | null) {
    if (value) localStorage.setItem(AppConstants.TOKEN_KEY, value);
  }

  public get token() {
    return localStorage.getItem(AppConstants.TOKEN_KEY);
  }

  public removeToken() {
    localStorage.removeItem(AppConstants.TOKEN_KEY);
  }
}
