import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseStudentsEnrolledComponent } from './course-students-enrolled.component';

describe('CourseStudentsEnrolledComponent', () => {
  let component: CourseStudentsEnrolledComponent;
  let fixture: ComponentFixture<CourseStudentsEnrolledComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CourseStudentsEnrolledComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseStudentsEnrolledComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
