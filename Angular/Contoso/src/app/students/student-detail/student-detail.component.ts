import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';

import { IStudent } from '../istudent';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.css']
})
export class StudentDetailComponent implements OnInit {

  constructor(private _route: ActivatedRoute,
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
      c => this.student = c,
      error => this.errorMessage = <any>error);
  }
}
