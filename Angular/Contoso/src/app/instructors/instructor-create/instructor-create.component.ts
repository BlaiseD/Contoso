import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

import { IInstructor } from '../iinstructor';
import { InstructorService } from '../instructor.service';
import { CourseService } from '../../courses/course.service';
import { GenericValidator } from '../../common/generic-validator';
import { ICourseAssignment } from '../icourse-assignment';
import { entityStateType } from '../../common/entity-state-type';
import { ListManagerService } from '../../common/list-manager.service';

@Component({
  selector: 'app-instructor-create',
  templateUrl: './instructor-create.component.html',
  styleUrls: ['./instructor-create.component.css']
})
export class InstructorCreateComponent implements OnInit, AfterViewInit, OnDestroy {

  constructor(private fb: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _instructorService: InstructorService,
    private _courseService: CourseService,
    private _listManagerService: ListManagerService) {
    this.validationMessages = {
      firstName: {
        required: 'Name is required.'
      },
      lastName: {
        required: 'Name is required.'
      },
      hireDate: {
        required: 'Hire Date is required.'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  public title: string = 'Instructor';
  public placeHolder: string = 'Select courses';

  public instructor: IInstructor = {
    id: 0,
    lastName: null,
    firstName: null,
    fullName: null,
    hireDate: null,
    officeAssignment: null,
    courses: [],
    entityState: entityStateType.Added
  };
  public courses: ICourseAssignment[];

  errorMessage: string;
  private sub: Subscription;
  instructorForm: FormGroup;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  ngOnInit() {
    this.instructorForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      hireDate: ['', Validators.required],
      officeAssignment: this.fb.group({location:['']}),
      courses: [[]]
    });
    this.getCourses();
  }

  ngOnDestroy() {
  }

  ngAfterViewInit(): void {
    this.instructorForm.valueChanges.pipe(debounceTime(500)).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.instructorForm);
    });
  }

  getCourses() {
    this._courseService.getDropdownList({ courseTitle: "title", courseID: "courseID", department: "DepartmentName" })
      .subscribe(courses => {

        courses.forEach(element => {
          element.entityState = entityStateType.Added;
        });
        console.log(JSON.stringify(courses));
        this.courses = courses;
      },
        error => this.errorMessage = <any>error);
  }

  public onValueChange(value) {
    console.log("valueChange : ", value);
  }

  submitClick(): void {

    if (!(this.instructorForm.dirty && this.instructorForm.valid)) {
      this.backToList();
      return;
    }
    this.instructorForm.value.courses.forEach(element => {
      element.entityState = entityStateType.Added;//All courses should be added for a new instructor
      // element.entityState = this._listManagerService.itemExists(element, this.instructor.courses, ["courseID"])
      //   ? entityStateType.Unchanged
      //   : entityStateType.Added;
    });

    //NO Courses should be pre-existing
    // this.instructor.courses.forEach(element => {
    //   if (!this._listManagerService.itemExists(element, this.instructorForm.value.courses, ["courseID"]))
    //     element.entityState = entityStateType.Deleted;
    // });

    

    let ins = Object.assign({}, this.instructor, this.instructorForm.value);
    ins.courses = this._listManagerService.mergeLists(this.instructor.courses, this.instructorForm.value.courses, ["courseID"]);
    ins.entityState = entityStateType.Added;
    ins.typeFullName = "Contoso.Domain.Entities.InstructorModel";

    console.log("INS: " + JSON.stringify(ins))
    console.log("this.instructor: " + JSON.stringify(this.instructor))

    let officeAssignmentForm = this.instructorForm.get("officeAssignment");
    if (this.instructorForm.get("officeAssignment").dirty)
      ins.officeAssignment.entityState = entityStateType.Added;

    this._instructorService.insertInstructor(ins)
      .subscribe(course => {
        this.backToList();
      },
        error => this.errorMessage = <any>error);
  }

  onBack(): void {
    this.backToList();
  }

  backToList(): void {
    // Reset the form to clear the flags
    this.instructorForm.reset();
    this._router.navigate(['/instructors']);
  }
}
