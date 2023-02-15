import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { MaterialInfo } from '../models/material-info';
import { NikprogApiService } from './nikprog-api.service';

@Injectable({
  providedIn: 'root'
})
export class MaterialInfoApiService extends NikprogApiService<MaterialInfo>{
  getMaterialInfosByModuleId(resourseUrl: string, id: string | number): Observable<MaterialInfo[]> {

    return this.httpClient.get<MaterialInfo[]>(`/${resourseUrl}/${id}`, { headers: this.getHeaderWithUserToken() })
      .pipe(
        catchError(this.handleError)
      );
  }

  post(resourseUrl: string, resource: MaterialInfo): any {
    return this.httpClient.post<any>(`/${resourseUrl}`, resource, { headers: this.getHeaderWithUserToken() })
      .subscribe(() => catchError(this.handleError));
  }
}


