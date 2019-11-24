import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntructorCoursesTaughtComponent } from './intructor-courses-taught.component';

describe('IntructorCoursesTaughtComponent', () => {
  let component: IntructorCoursesTaughtComponent;
  let fixture: ComponentFixture<IntructorCoursesTaughtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntructorCoursesTaughtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntructorCoursesTaughtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
