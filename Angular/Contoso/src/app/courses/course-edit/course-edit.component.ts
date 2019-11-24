import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { debounceTime, map } from 'rxjs/operators';

import { ICourse } from '../icourse';
import { CourseService } from '../course.service';
import { DepartmentService } from '../../departments/department.service';
import { GenericValidator } from '../../common/generic-validator';
import { NumberValidators } from '../../common/number-validators';

@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.css']
})
export class CourseEditComponent implements OnInit, AfterViewInit, OnDestroy {

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
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  public title: string = 'Course';
  public placeHolder: any =
    {
      name: 'Select department...',
      departmentID: null
    };
  public course: ICourse;

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
      //credits: ['', [Validators.required, Validators["min"].apply(Validators, [0]), Validators["max"].apply(Validators, [5]), NumberValidators.mustBeNumber()]],
      departmentID: ['', Validators.required],
      title: ['', Validators.required]
    });

    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getCourse(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    // Run validation on valueChanges after debounceTime
    this.courseForm.valueChanges.pipe(debounceTime(500)).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.courseForm);
    });
  }

  getCourse(id: number) {
    this._courseService.getCourse(id).subscribe(
      course => {
        this.course = course;
        this.courseForm.patchValue({
          courseID: this.course.courseID,
          credits: this.course.credits,
          departmentID: this.course.departmentID,
          title: this.course.title
        });
      },
      error => this.errorMessage = <any>error);

    this._departmentService.getDropdownList(["name", "departmentId"])
      .subscribe(departments => this.departments = departments,
        error => this.errorMessage = <any>error);
  }

  submitClick(): void {

    if (!(this.courseForm.dirty && this.courseForm.valid))
      return;

    let c = Object.assign({}, this.course, this.courseForm.value);

    this._courseService.updateCourse(c)
      .subscribe(course => {
        this._router.navigate(['/courses']);
      },
        error => this.errorMessage = <any>error);

  }
}
