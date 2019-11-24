import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DataSourceRequestState } from '@progress/kendo-data-query';

import { IGridResult } from '../../common/igrid-result';
import { GridService } from '../../common/grid.service';

@Component({
  selector: 'app-instructor-list',
  templateUrl: './instructor-list.component.html',
  styleUrls: ['./instructor-list.component.css']
})
export class InstructorListComponent implements OnInit {

  constructor(private _gridService: GridService) { }

  public title: string = 'Instructors';
  public aggregates: any[] = [{ field: 'lastName', aggregate: 'count' },{ field: 'hireDate', aggregate: 'min' }];
  //public aggregates: any[] = [{ field: 'hireDate', aggregate: 'min' }];
  public instructors: IGridResult;
  public aggregateResult: any = {};
  private relativeUrl: string = '/Instructors';
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
        this.instructors = r;
        this.aggregateResult = r.aggregateResult;
        
        console.log("Total: " + JSON.stringify(this.instructors.aggregateResult.lastName));
      });
  }

  ngOnInit() {
    this._gridService.fetch(this.state, this.relativeUrl).subscribe(r => {
      this.instructors = r;
      this.aggregateResult = r.aggregateResult;
      console.log("Total: " + JSON.stringify(this.instructors.aggregateResult.lastName));
    });
  }

}
