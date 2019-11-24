
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';
import { IEnrollmentStats } from './enrollment-stats';

@Injectable({
    providedIn: 'root'
})
export class AboutService {

    constructor(private _http: HttpClient, @Inject('baseUrl') private baseUrl) { }

    getStats(): Observable<IEnrollmentStats[]> {
        return this._http.get<IEnrollmentStats[]>(`${this.baseUrl}/about`)
            .pipe(
                tap(data => console.log(JSON.stringify(data))),
                catchError(this.handleError)
            );
    }

    private handleError(error: Response) {
        console.error(error);
        return observableThrowError(error || 'Server error');
    }
}
