
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';

import {
  toDataSourceRequestString,
  translateDataSourceResultGroups,
  DataSourceRequestState,
} from '@progress/kendo-data-query';

import { ProgressService } from '../progress/progress.service';
import { IGridResult } from './igrid-result';

@Injectable({
  providedIn: 'root'
})
export class GridService {

  constructor(private _http: HttpClient, private progressService: ProgressService, @Inject('baseUrl') private baseUrl) { }

  public fetch(state: DataSourceRequestState, relativeUrl: string): Observable<IGridResult> {
    const queryStr = `${toDataSourceRequestString(state)}`; //serialize the state
    const hasGroups = state.group && state.group.length;

    return this._http
      .get<IGridResult>(`${this.baseUrl}${relativeUrl}?${queryStr}`)
      .pipe
      (
        tap(({ data, total, aggregateResults }: any) => 
          {
            console.log("Data: " + JSON.stringify(data));
            console.log("Total: " + JSON.stringify(total));
            console.log("AggregateResults: " + JSON.stringify(aggregateResults));
          }),
        map(({ data, total, aggregateResults }: any) => // process the response
          (<IGridResult>{
            //if there are groups convert them to compatible format
            data: hasGroups ? translateDataSourceResultGroups(data) : data,
            total: total,
            aggregateResult: this.progressService.translateAggregateResults(aggregateResults)
          })),
        catchError(this.handleError)
      );
  }

  private handleError(error: Response) {
    console.error(JSON.stringify(error));
    return observableThrowError(error || 'Server error');
  }
}
