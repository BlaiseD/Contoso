
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';

import { IDepartment } from './idepartment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private _http: HttpClient, @Inject('baseUrl') private baseUrl) { }
  private _url = `${this.baseUrl}/Departments`;

  getDepartments(): Observable<IDepartment[]> {
    return this._http.get<IDepartment[]>(`${this._url}/GetDepartments`).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  getDepartment(id: number): Observable<IDepartment> {
    const url = `${this._url}/${id}`;
    return this._http.get<IDepartment>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  getDropdownList(selects: string[]): Observable<any[]> {
    const url = `${this._url}/GetDropdownList`;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.post<any[]>(url, JSON.stringify(selects), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  deleteDepartment(id: number): Observable<Response> {
    const url = `${this._url}/${id}`;
    return this._http.delete<Response>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  updateDepartment(dept: IDepartment): Observable<Response> {
    const url = `${this._url}/${dept.departmentID}`;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.put<Response>(url, JSON.stringify(dept), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  insertDepartment(dept: IDepartment): Observable<IDepartment> {
    const url = this._url;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.post<IDepartment>(url, JSON.stringify(dept), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  private handleError(error: Response) {
    console.error(error);
    return observableThrowError(error || 'Server error');
  }
}
