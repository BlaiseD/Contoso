import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { debounceTime, map } from 'rxjs/operators';

import { IStudent } from '../istudent';
import { StudentService } from '../student.service';
import { GenericValidator } from '../../common/generic-validator';
import { entityStateType } from '../../common/entity-state-type';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.css']
})
export class StudentCreateComponent implements OnInit, AfterViewInit {

  constructor(private fb: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _studentService: StudentService) {
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
  public student: IStudent = {//must initialize the student for the form to be visible
    id: 0,
    lastName: null,
    firstName: null,
    fullName: null,
    enrollmentDate: null,
    enrollments: null,
    entityState: entityStateType.Added
  };

  errorMessage: string;
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
  }

  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    // Run validation on valueChanges after debounceTime
    this.studentForm.valueChanges.pipe(debounceTime(500)).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.studentForm);
    });
  }

  submitClick(): void {

    if (!(this.studentForm.dirty && this.studentForm.valid))
      return;

    let s = Object.assign({}, this.student, this.studentForm.value);

    this._studentService.insertStudent(s)
      .subscribe(course => {
        this._router.navigate(['/students']);
      },
      error => this.errorMessage = <any>error);

  }
}
