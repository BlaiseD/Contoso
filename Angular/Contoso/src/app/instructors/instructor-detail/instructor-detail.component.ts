import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';

import { IInstructor } from '../iinstructor';
import { InstructorService } from '../instructor.service';

@Component({
  selector: 'app-instructor-detail',
  templateUrl: './instructor-detail.component.html',
  styleUrls: ['./instructor-detail.component.css']
})
export class InstructorDetailComponent implements OnInit, OnDestroy {

  constructor(private _route: ActivatedRoute,
    private _instructorService: InstructorService) { }

  public title: string = 'Instructors';
  public instructor: IInstructor;
  errorMessage: string;
  private sub: Subscription;

  ngOnInit() {
    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getInstructor(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  getInstructor(id: number) {
    this._instructorService.getInstructor(id).subscribe(
      c => this.instructor = c,
      error => this.errorMessage = <any>error);
  }
}
