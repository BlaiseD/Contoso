
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';

import { IInstructor } from './iinstructor';

@Injectable({
  providedIn: 'root'
})
export class InstructorService {

  constructor(private _http: HttpClient, @Inject('baseUrl') private baseUrl) { }

  private _url = `${this.baseUrl}/Instructors`;

  getInstructors(): Observable<IInstructor[]> {
    return this._http.get<IInstructor[]>(`${this._url}/GetInstructors`).pipe
      (
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getInstructor(id: number): Observable<IInstructor> {
    const url = `${this._url}/${id}`;
    return this._http.get<IInstructor>(url).pipe
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

  deleteInstructor(id: number): Observable<Response> {
    const url = `${this._url}/${id}`;
    return this._http.delete<Response>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  updateInstructor(ins: IInstructor): Observable<Response> {
    const url = `${this._url}/${ins.id}`;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.put<Response>(url, JSON.stringify(ins), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  insertInstructor(ins: IInstructor): Observable<IInstructor> {
    const url = this._url;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.post<IInstructor>(url, JSON.stringify(ins), options).pipe
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
