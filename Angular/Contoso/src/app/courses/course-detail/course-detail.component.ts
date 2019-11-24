import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';

import { ICourse } from '../icourse';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})
export class CourseDetailComponent implements OnInit, OnDestroy {
  constructor(private _route: ActivatedRoute,
    private _courseService: CourseService) { }

  public title: string = 'Courses';
  public course: ICourse;
  errorMessage: string;
  private sub: Subscription;

  ngOnInit() {
    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getCourse(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  getCourse(id: number) {
    this._courseService.getCourse(id).subscribe(
      c => this.course = c,
      error => this.errorMessage = <any>error);
  }
}
