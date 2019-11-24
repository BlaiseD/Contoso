
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';

import { ICourse } from './icourse';


@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private _url = `${this.baseUrl}/Courses`;
  constructor(private _http: HttpClient, @Inject('baseUrl') private baseUrl) { }

  getCourses(): Observable<ICourse[]> {
    return this._http.get<ICourse[]>(this._url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  getCourse(id: number): Observable<ICourse> {
    const url = `${this._url}/${id}`;
    return this._http.get<ICourse>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  /*key is the member name to create in the anonymous object
    * and value is the member on the source object
  */
  getDropdownList(selects: { [key: string]: string }): Observable<any[]> {
    const url = `${this._url}/GetDropdownList`;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.post<any[]>(url, JSON.stringify(selects), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  deleteCourse(id: number): Observable<Response> {
    const url = `${this._url}/${id}`;
    return this._http.delete<Response>(url).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  updateCourse(dept: ICourse): Observable<Response> {
    const url = `${this._url}/${dept.courseID}`;
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.put<Response>(url, JSON.stringify(dept), options).pipe
      (
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
      );
  }

  insertCourse(dept: ICourse): Observable<ICourse> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this._http.post<ICourse>(this._url, JSON.stringify(dept), options).pipe
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
