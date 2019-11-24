import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { IStudent } from '../istudent';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-delete',
  templateUrl: './student-delete.component.html',
  styleUrls: ['./student-delete.component.css']
})
export class StudentDeleteComponent implements OnInit {

  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private _studentService: StudentService) { }

  public title: string = 'Students';
  public student: IStudent;
  errorMessage: string;
  private sub: Subscription;

  ngOnInit() {
    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getStudent(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  getStudent(id: number) {
    this._studentService.getStudent(id).subscribe(
      student => this.student = student,
      error => this.errorMessage = <any>error);
  }

  submitClick(): void {
    this._studentService.deleteStudent(this.student.id)
      .subscribe(student => {
        this._router.navigate(['/students']);
      },
        error => this.errorMessage = <any>error);
  }

}
