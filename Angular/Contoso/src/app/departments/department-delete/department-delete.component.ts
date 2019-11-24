import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { IDepartment } from '../idepartment';
import { DepartmentService } from '../department.service';

@Component({
  selector: 'app-department-delete',
  templateUrl: './department-delete.component.html',
  styleUrls: ['./department-delete.component.css']
})
export class DepartmentDeleteComponent implements OnInit, OnDestroy {

  constructor(private _route: ActivatedRoute,
    private _router: Router,
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
      department => this.department = department,
      error => this.errorMessage = <any>error);
  }

  submitClick(): void {
    this._departmentService.deleteDepartment(this.department.departmentID)
      .subscribe(department => {
        this._router.navigate(['/departments']);
      },
        error => this.errorMessage = <any>error);
  }

}
