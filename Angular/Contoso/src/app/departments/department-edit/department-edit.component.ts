import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { debounceTime, map } from 'rxjs/operators';

import { IDepartment } from '../idepartment';
import { DepartmentService } from '../department.service';
import { InstructorService } from '../../instructors/instructor.service';
import { GenericValidator } from '../../common/generic-validator';
import { NumberValidators } from '../../common/number-validators';
import { DateService } from '../../common/date.service';

@Component({
  selector: 'app-department-edit',
  templateUrl: './department-edit.component.html',
  styleUrls: ['./department-edit.component.css']
})
export class DepartmentEditComponent implements OnInit, AfterViewInit, OnDestroy {

  constructor(private fb: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _departmentService: DepartmentService,
    private _instructorService: InstructorService,
    private _dateService: DateService) {
    this.validationMessages = {
      budget: {
        required: 'Budget is required.',
        mustBeNumber: 'Budget must be a positive number.'
      },
      instructorID: {
        required: 'Administrator is required.'
      },
      name: {
        required: 'Name is required.'
      },
      startDate: {
        required: 'Start Date is required.'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  public title: string = 'Department';
  public placeHolder: any =
    {
      fullName: 'Select instructor...',
      id: null
    };
  public department: IDepartment;
  public instructors: any[];

  errorMessage: string;
  private sub: Subscription;
  departmentForm: FormGroup;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  ngOnInit() {
    this.departmentForm = this.fb.group({
      budget: ['', [Validators.required, NumberValidators.mustBeNumber()]],
      instructorID: ['', Validators.required],
      name: ['', Validators.required],
      startDate: ['', Validators.required]
    });
    this.sub = this._route.params.subscribe(
      params => {
        let id = +params['id'];
        this.getDepartment(id);
      });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  ngAfterViewInit(): void {
    this.departmentForm.valueChanges.pipe(debounceTime(500)).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.departmentForm);
    });
  }

  getDepartment(id: number) {
    this._departmentService.getDepartment(id).subscribe(
      dept => {
        this.department = dept;
        this.departmentForm.patchValue({
          budget: this.department.budget,
          instructorID: this.department.instructorID,
          name: this.department.name,
          startDate: this._dateService.convertToDate(this.department.startDate)
        });
      },
      error => this.errorMessage = <any>error);

    this._instructorService.getDropdownList(["fullName", "id"])
      .subscribe(instructors => this.instructors = instructors,
        error => this.errorMessage = <any>error);
  }

  submitClick(): void {

    if (!(this.departmentForm.dirty && this.departmentForm.valid))
      return;

    let d = Object.assign({}, this.department, this.departmentForm.value);

    this._departmentService.updateDepartment(d)
      .subscribe(course => {
        this._router.navigate(['/departments']);
      },
        error => this.errorMessage = <any>error);

  }
}
