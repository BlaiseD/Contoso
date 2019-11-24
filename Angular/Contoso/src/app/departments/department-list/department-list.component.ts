import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DataSourceRequestState } from '@progress/kendo-data-query';

import { IGridResult } from '../../common/igrid-result';
import { GridService } from '../../common/grid.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  constructor(private _gridService: GridService) { }

  public title: string = 'Departments';
  public aggregates: any[] = [{ field: 'administratorName', aggregate: 'min' },{ field: 'name', aggregate: 'count' },{ field: 'budget', aggregate: 'sum' },{ field: 'startDate', aggregate: 'min' }];
  public departments: IGridResult;
  public aggregateResult: any = {};
  private relativeUrl: string = '/Departments';
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
        this.departments = r;
        this.aggregateResult = r.aggregateResult;
        
        console.log("Total: " + JSON.stringify(this.departments.aggregateResult.credits));
      });
  }

  ngOnInit() {
    this._gridService.fetch(this.state, this.relativeUrl).subscribe(r => {
      this.departments = r;
      this.aggregateResult = r.aggregateResult;
      console.log("Total: " + JSON.stringify(this.departments.aggregateResult.credits));
    });
  }

}
