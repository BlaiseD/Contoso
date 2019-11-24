import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { AboutComponent } from './about/about.component';

import { StudentModule } from './students/student/student.module';
import { DepartmentModule } from './departments/department/department.module';
import { CourseModule } from './courses/course/course.module';
import { InstructorModule } from './instructors/instructor/instructor.module';

import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'welcome', component: WelcomeComponent },
      { path: 'about', component: AboutComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
    ]),
    CourseModule,
    StudentModule,
    DepartmentModule,
    InstructorModule,
    GridModule,
    NgbModule,
    BrowserAnimationsModule
  ],
  providers: [
    { provide: 'baseUrl', useValue: 'http://localhost:20054/api' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
