import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DataSourceRequestState } from '@progress/kendo-data-query';

import { IGridResult } from '../../common/igrid-result';
import { GridService } from '../../common/grid.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  constructor(private _gridService: GridService) { }

  public title: string = 'Courses';
  public aggregates: any[] = [{ field: 'credits', aggregate: 'sum' }];
  public courses: IGridResult;
  public aggregateResult: any = {};
  private relativeUrl: string = '/Courses';
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
        this.courses = r;
        this.aggregateResult = r.aggregateResult;
        
        console.log("Total: " + JSON.stringify(this.courses.aggregateResult.credits));
      });
  }

  ngOnInit() {
    this._gridService.fetch(this.state, this.relativeUrl).subscribe(r => {
      this.courses = r;
      this.aggregateResult = r.aggregateResult;
      console.log("Total: " + JSON.stringify(this.courses.aggregateResult.credits));
    });
  }
}
