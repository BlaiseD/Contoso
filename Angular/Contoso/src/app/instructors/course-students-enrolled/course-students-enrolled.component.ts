import { Component, OnInit, Input } from '@angular/core';
import { DataSourceRequestState } from '@progress/kendo-data-query';

import { IGridResult } from '../../common/igrid-result';
import { GridService } from '../../common/grid.service';

@Component({
  selector: 'app-course-students-enrolled',
  templateUrl: './course-students-enrolled.component.html',
  styleUrls: ['./course-students-enrolled.component.css']
})
export class CourseStudentsEnrolledComponent implements OnInit {

  constructor(private _gridService: GridService) { }

  @Input() public course: any;

  public title: string = 'Students Enrolled in Selected Course ';
  public students: IGridResult;
  private relativeUrl: string = '/Courses/GetEnrollments';

  private state: DataSourceRequestState = {
    skip: 0
  };

  ngOnInit() {
    this.state.filter = {
      filters: [{
        field: 'courseID', operator: 'eq', value: this.course.courseID
      }],
      logic: 'and'
    }
    this._gridService.fetch(this.state, this.relativeUrl).subscribe(r => {
      this.students = r;
      console.log("Students Total: " + JSON.stringify(this.students));
    });
  }

}
