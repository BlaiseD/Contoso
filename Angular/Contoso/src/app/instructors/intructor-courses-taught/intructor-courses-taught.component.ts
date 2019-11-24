import { Component, OnInit, Input } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DataSourceRequestState } from '@progress/kendo-data-query';

import { IGridResult } from '../../common/igrid-result';
import { GridService } from '../../common/grid.service';

@Component({
  selector: 'app-intructor-courses-taught',
  templateUrl: './intructor-courses-taught.component.html',
  styleUrls: ['./intructor-courses-taught.component.css']
})
export class IntructorCoursesTaughtComponent implements OnInit {

  constructor(private _gridService: GridService) { }

  @Input() public instructor: any;

  public title: string = 'Courses Taught by Selected Instructor';
  public courses: IGridResult;
  private relativeUrl: string = '/Instructors/GetCourses';

  private state: DataSourceRequestState = {
    skip: 0,
    take: 5
  };

  public dataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.state.filter = {
      filters: [{
        field: 'instructorID', operator: 'eq', value: this.instructor.id
      }],
      logic: 'and'
    }

    this._gridService.fetch(state, this.relativeUrl)
      .subscribe(r => this.courses = r);
  }

  ngOnInit() {
    this.state.filter = {
      filters: [{
        field: 'instructorID', operator: 'eq', value: this.instructor.id
      }],
      logic: 'and'
    }
    this._gridService.fetch(this.state, this.relativeUrl)
      .subscribe(r => this.courses = r);
  }

}
