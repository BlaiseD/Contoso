
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';

import { IStudent } from './istudent';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private _url = `${this.baseUrl}/Students`;
  constructor(private _http: HttpClient, @Inject('baseUrl') private baseUrl) { }

  getStudent(id: number): Observable<IStudent> {
    const url = `${this._url}/${id}`;
    return this._http.get<IStudent>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }
  deleteStudent(id: number): Observable<Response> {
    const url = `${this._url}/${id}`;
    return this._http.delete<Response>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  updateStudent(stud: IStudent): Observable<Response> {
    const url = `${this._url}/${stud.id}`;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.put<Response>(url, JSON.stringify(stud), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  insertStudent(dept: IStudent): Observable<IStudent> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.post<IStudent>(this._url, JSON.stringify(dept), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  private handleError(error: Response) {
    console.error(JSON.stringify(error));
    return observableThrowError(error || 'Server error');
  }
}
