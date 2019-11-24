import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { debounceTime, map } from 'rxjs/operators';

import { ICourse } from '../icourse';
import { IDepartment } from '../../departments/idepartment';
import { CourseService } from '../course.service';
import { DepartmentService } from '../../departments/department.service';
import { GenericValidator } from '../../common/generic-validator';
import { NumberValidators } from '../../common/number-validators';
import { entityStateType } from '../../common/entity-state-type';

@Component({
  selector: 'app-course-create',
  templateUrl: './course-create.component.html',
  styleUrls: ['./course-create.component.css']
})
export class CourseCreateComponent implements OnInit, AfterViewInit, OnDestroy {

  constructor(private fb: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _courseService: CourseService,
    private _departmentService: DepartmentService) {
    this.validationMessages = {
      credits: {
        min: 'Credits must between 0 and 5 inclusive.',
        max: 'Credits must between 0 and 5 inclusive.',
        mustBeNumber: "Credits must between 0 and 5 inclusive.",
        required: 'Credits field is required.'
      },
      departmentID: {
        required: 'Department is required.'
      },
      title: {
        required: 'Title is required.'
      },
      courseID: {
        required: 'Number is required.'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  public pageTitle: string = 'Course';
  public placeHolder: any =
    {
      name: 'Select department...',
      departmentID: null
    };
  public course: ICourse = {
    "courseID": null,
    "title": null,
    "credits": null,
    "departmentID": null,
    "departmentName": null,
    entityState: entityStateType.Added
  };

  public departments: any[] = [];
  errorMessage: string;
  private sub: Subscription;
  courseForm: FormGroup;

  // Use with the generic validation message class
  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  ngOnInit() {
    this.courseForm = this.fb.group({
      credits: ['', [Validators.required, Validators.min(0), Validators.max(5), NumberValidators.mustBeNumber()]],
      departmentID: ['', Validators.required],
      title: ['', Validators.required],
      courseID: ['', Validators.required]
    });

    this.getDepartments();
  }

  ngOnDestroy() {
  }

  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    // Run validation on valueChanges after debounceTime
    this.courseForm.valueChanges.pipe(debounceTime(500)).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.courseForm);
    });
  }

  getDepartments() {
    this._departmentService.getDepartments()
      .subscribe(departments => this.departments = departments,
        error => this.errorMessage = <any>error);
  }

  submitClick(): void {

    if (!(this.courseForm.dirty && this.courseForm.valid))
      return;

    let c = Object.assign({}, this.course, this.courseForm.value);

    this._courseService.insertCourse(c)
      .subscribe(course => {
        this._router.navigate(['/courses']);
      },
        error => this.errorMessage = <any>error);

  }
}
