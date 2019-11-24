import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { InstructorListComponent } from '../instructor-list/instructor-list.component';
import { InstructorCreateComponent } from '../instructor-create/instructor-create.component';
import { InstructorEditComponent } from '../instructor-edit/instructor-edit.component';
import { InstructorDetailComponent } from '../instructor-detail/instructor-detail.component';
import { InstructorDeleteComponent } from '../instructor-delete/instructor-delete.component';
import { IntructorCoursesTaughtComponent } from '../intructor-courses-taught/intructor-courses-taught.component';
import { CourseStudentsEnrolledComponent } from '../course-students-enrolled/course-students-enrolled.component';

@NgModule({
  imports: [
    CommonModule,
    ButtonsModule,
    DropDownsModule,
    DatePickerModule,
    GridModule,
    BrowserAnimationsModule,
    RouterModule.forChild([
        { path: 'instructors', component: InstructorListComponent },
        { path: 'instructor-create', component: InstructorCreateComponent },
        { path: 'instructor-edit/:id', component: InstructorEditComponent },
        { path: 'instructor-delete/:id', component: InstructorDeleteComponent },
        { path: 'instructor-detail/:id', component: InstructorDetailComponent }
    ]),
    ReactiveFormsModule,
    AngularFontAwesomeModule
  ],
  declarations: [
    InstructorListComponent,
    InstructorCreateComponent,
    InstructorEditComponent,
    InstructorDetailComponent,
    InstructorDeleteComponent,
    IntructorCoursesTaughtComponent,
    CourseStudentsEnrolledComponent
  ]
})
export class InstructorModule { }
