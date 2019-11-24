import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DataSourceRequestState } from '@progress/kendo-data-query';

import { IGridResult } from '../../common/igrid-result';
import { GridService } from '../../common/grid.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  constructor(private _gridService: GridService) { }

  public title: string = 'Students';
  public aggregates: any[] = [{ field: 'lastName', aggregate: 'count' },{ field: 'enrollmentDate', aggregate: 'min' }];
  public students: IGridResult;
  public aggregateResult: any = {};
  private relativeUrl: string = '/Students';
  private state: DataSourceRequestState = {
    skip: 0,
    take: 5,
    aggregates: this.aggregates
  };

  errorMessage: string;

  public dataStateChange(state: DataStateChangeEvent): void {
    if (state && state.group) {
      state.group.map(group => group.aggregates = this.aggregates);
    }

    this.state = state;
    this.state.aggregates = this.aggregates;

    this._gridService.fetch(state, this.relativeUrl)
      .subscribe(r => 
      {
        this.students = r;
        this.aggregateResult = r.aggregateResult;
        
        //console.log("Total: " + JSON.stringify(this.students.aggregateResult.credits));
        console.log("All Results: " + JSON.stringify(this.students));
      });
  }

  stringify(item: any){
    return JSON.stringify(item);
  }

  ngOnInit() {
    this._gridService.fetch(this.state, this.relativeUrl).subscribe(r => {
      this.students = r;
      this.aggregateResult = r.aggregateResult;
      //console.log("Total: " + JSON.stringify(this.students.aggregateResult.credits));
      console.log("All Results: " + JSON.stringify(this.students));
    });
  }
}
