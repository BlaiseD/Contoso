import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { debounceTime, map } from 'rxjs/operators';

import { IStudent } from '../istudent';
import { StudentService } from '../student.service';
import { GenericValidator } from '../../common/generic-validator';
import { DateService } from '../../common/date.service';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit, AfterViewInit, OnDestroy {

  constructor(private fb: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _studentService: StudentService,
    private _dateService: DateService) {
    this.validationMessages = {
      firstName: {
        required: 'First Name is required.'
      },
      lastName: {
        required: 'Last Name is required.'
      },
      enrollmentDate: {
        required: 'Enrollment Date is required.'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }
  public title: string = 'Student';
  public student: IStudent;

  errorMessage: string;
  private sub: Subscription;
  studentForm: FormGroup;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  ngOnInit() {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      enrollmentDate: ['', Validators.required]
    });
    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getStudent(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  ngAfterViewInit(): void {
    this.studentForm.valueChanges.pipe(debounceTime(500)).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.studentForm);
    });
  }

  getStudent(id: number) {
    this._studentService.getStudent(id).subscribe(
      stud => 
      {
        this.student = stud;
        this.studentForm.patchValue({
          firstName: this.student.firstName,
          lastName: this.student.lastName,
          enrollmentDate: this._dateService.convertToDate(this.student.enrollmentDate)
      });
      },
      error => this.errorMessage = <any>error);
  }

  submitClick(): void {

    if (!(this.studentForm.dirty && this.studentForm.valid))
      return;

    let s = Object.assign({}, this.student, this.studentForm.value);

    this._studentService.updateStudent(s)
      .subscribe(course => {
        this._router.navigate(['/students']);
      },
      error => this.errorMessage = <any>error);

  }
}
