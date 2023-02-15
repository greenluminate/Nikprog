import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { Module } from '../models/module';
import { NikprogApiService } from './nikprog-api.service';

@Injectable({
  providedIn: 'root'
})
export class ModuleApiService extends NikprogApiService<Module>{
  getModulesByCourseId(resourseUrl: string, id: string | number): Observable<Module[]> {

    return this.httpClient.get<Module[]>(`/${resourseUrl}/${id}`, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  post(resourseUrl: string, resource: Module): any {
    return this.httpClient.post<any>(`/${resourseUrl}`, resource, { headers: this.getHeaderWithUserToken() })
      .subscribe(() => catchError(this.handleError));
  }
}
