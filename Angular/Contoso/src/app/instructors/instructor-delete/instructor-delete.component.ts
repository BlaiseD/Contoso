import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { IInstructor } from '../iinstructor';
import { InstructorService } from '../instructor.service';

@Component({
  selector: 'app-instructor-delete',
  templateUrl: './instructor-delete.component.html',
  styleUrls: ['./instructor-delete.component.css']
})
export class InstructorDeleteComponent implements OnInit, OnDestroy {

  constructor(private _route: ActivatedRoute,
    private _router: Router,
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
      instructor => this.instructor = instructor,
      error => this.errorMessage = <any>error);
  }

  submitClick(): void {
    this._instructorService.deleteInstructor(this.instructor.id)
      .subscribe(instructor => {
        this._router.navigate(['/instructors']);
      },
        error => this.errorMessage = <any>error);
  }
}
