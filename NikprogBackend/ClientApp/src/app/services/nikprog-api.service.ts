import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NikprogApiService<T> {

  constructor(protected httpClient: HttpClient) {
  }

  getList(resourseUrl: string): Observable<T[]> {

    return this.httpClient.get<T[]>(`/${resourseUrl}`, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  get(resourseUrl: string, id: string | number): Observable<T> {

    return this.httpClient.get<T>(`/${resourseUrl}/${id}`, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  post(resourseUrl: string, resource: T): Observable<any> {
    return this.httpClient.post(`/${resourseUrl}`, resource, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(resourseUrl: string, id: string | number): Observable<any> {
    return this.httpClient.delete(`/${resourseUrl}/${id}`, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  update(resourseUrl: string, resource: T) {

    return this.httpClient.put(`/${resourseUrl}`, resource, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  protected handleError(error: HttpErrorResponse) {
    // Handle the HTTP error here
    return throwError('Something went wrong.');//throwError(error.message);
  } // Test it with Postman

  protected getHeaderWithUserToken(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    });
  }
}
