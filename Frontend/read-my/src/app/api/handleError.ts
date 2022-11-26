import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

export default function handleError(errorRes: HttpErrorResponse) {
  console.log(errorRes);
  if (!errorRes.error || !errorRes.error.error) {
    return throwError(() => new Error('An unknown error occurred!'));
  } else {
    return throwError(() => new Error(errorRes.error.error.message));
  }
}
