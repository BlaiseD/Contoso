import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';

import { StudentDeleteComponent } from '../student-delete/student-delete.component';
import { StudentEditComponent } from '../student-edit/student-edit.component';
import { StudentDetailComponent } from '../student-detail/student-detail.component';
import { StudentListComponent } from '../student-list/student-list.component';
import { StudentCreateComponent } from '../student-create/student-create.component';

@NgModule({
  imports: [
    CommonModule,
    ButtonsModule,
    DatePickerModule,
    GridModule,
    BrowserAnimationsModule,
    RouterModule.forChild([
        { path: 'students', component: StudentListComponent },
        { path: 'student-create', component: StudentCreateComponent },
        { path: 'student-edit/:id', component: StudentEditComponent },
        { path: 'student-delete/:id', component: StudentDeleteComponent },
        { path: 'student-detail/:id', component: StudentDetailComponent }
    ]),
    ReactiveFormsModule
  ],
  declarations: [
    StudentListComponent,
    StudentCreateComponent,
    StudentEditComponent,
    StudentDetailComponent,
    StudentDeleteComponent]
})
export class StudentModule { }
