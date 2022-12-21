import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

const baseUrl = 'http://localhost:5174/api/simplecalculator/';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  constructor(private http: HttpClient,) { }

  get httpOptions(): any {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        // 'Authorization': 'Bearer ' + this.authService.getSession('token')
        
      })
    }
  };

  postRequest(endpoint: string, data: any) : Observable<any> {
    return this.http.post<any>(baseUrl+endpoint, data, this.httpOptions)
      .pipe(
        // catchError(this.handleError('addHero', hero))
      );

  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {      
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
