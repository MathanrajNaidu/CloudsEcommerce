import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from './../environments/environment';
@Injectable({
  providedIn: 'root',
})
export class RestApiService {
  // Define API
  constructor(private http: HttpClient) {}
  /*========================================
    CRUD Methods for consuming RESTful API
  =========================================*/
  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  // HttpClient API get() method
  get<T>(url:string): Observable<T> {
    return this.http
      .get<T>(url)
      .pipe(retry(1), catchError(this.handleError));
  }
  
  // HttpClient API post() method
  post<T>(body: any, url:string): Observable<T> {
    return this.http
      .post<T>(
        url,
        JSON.stringify(body),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }
  // HttpClient API put() method => Update employee
  put<T>(id: any, body: T, url:string): Observable<T> {
    return this.http
      .put<T>(
        url + id,
        JSON.stringify(body),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }
  // HttpClient API delete() method 
  delete<T>(id: any, url:string) {
    return this.http
      .delete<T>(url + id, this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }
  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}