import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { CourseListComponent } from '../course-list/course-list.component';
import { CourseCreateComponent } from '../course-create/course-create.component';
import { CourseEditComponent } from '../course-edit/course-edit.component';
import { CourseDetailComponent } from '../course-detail/course-detail.component';
import { CourseDeleteComponent } from '../course-delete/course-delete.component';


@NgModule({
  imports: [
    CommonModule,
    ButtonsModule,
    DropDownsModule,
    GridModule,
    BrowserAnimationsModule,
    RouterModule.forChild([
        { path: 'courses', component: CourseListComponent },
        { path: 'course-create', component: CourseCreateComponent },
        { path: 'course-edit/:id', component: CourseEditComponent },
        { path: 'course-delete/:id', component: CourseDeleteComponent },
        { path: 'course-detail/:id', component: CourseDetailComponent }
    ]),
    ReactiveFormsModule,
    AngularFontAwesomeModule
  ],
  declarations: [
    CourseListComponent,
    CourseCreateComponent,
    CourseEditComponent,
    CourseDetailComponent,
    CourseDeleteComponent
  ]
})
export class CourseModule { }
