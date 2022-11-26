import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from './../common/app-constants';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root',
})
export class InterceptorService implements HttpInterceptor {
  constructor(private tokenService: TokenService) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const modifiedReq = req.clone({
      url: `${AppConstants.BASE_URL}${req.url}`,
      headers: req.headers.set(
        'Authorization',
        `Bearer ${this.tokenService.token}`
      ),
    });
    return next.handle(modifiedReq);
  }
}
