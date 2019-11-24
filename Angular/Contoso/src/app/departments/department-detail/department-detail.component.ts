import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';

import { IDepartment } from '../idepartment';
import { DepartmentService } from '../department.service';

@Component({
  selector: 'app-department-detail',
  templateUrl: './department-detail.component.html',
  styleUrls: ['./department-detail.component.css']
})
export class DepartmentDetailComponent implements OnInit, OnDestroy {

  constructor(private _route: ActivatedRoute,
    private _departmentService: DepartmentService) { }

  public title: string = 'Departments';
  public department: IDepartment;
  errorMessage: string;
  private sub: Subscription;

  ngOnInit() {
    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getDepartment(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  getDepartment(id: number) {
    this._departmentService.getDepartment(id).subscribe(
      c => this.department = c,
      error => this.errorMessage = <any>error);
  }

}
