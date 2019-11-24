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

import { DepartmentListComponent } from '../department-list/department-list.component';
import { DepartmentCreateComponent } from '../department-create/department-create.component';
import { DepartmentEditComponent } from '../department-edit/department-edit.component';
import { DepartmentDetailComponent } from '../department-detail/department-detail.component';
import { DepartmentDeleteComponent } from '../department-delete/department-delete.component';

@NgModule({
  imports: [
    CommonModule,
    ButtonsModule,
    DropDownsModule,
    DatePickerModule,
    GridModule,
    BrowserAnimationsModule,
    RouterModule.forChild([
      { path: 'departments', component: DepartmentListComponent },
      { path: 'department-create', component: DepartmentCreateComponent },
      { path: 'department-edit/:id', component: DepartmentEditComponent },
      { path: 'department-delete/:id', component: DepartmentDeleteComponent },
      { path: 'department-detail/:id', component: DepartmentDetailComponent }
  ]),
  ReactiveFormsModule,
  AngularFontAwesomeModule
  ],
  declarations: [
    DepartmentListComponent,
    DepartmentCreateComponent,
    DepartmentEditComponent,
    DepartmentDetailComponent,
    DepartmentDeleteComponent
  ]
})
export class DepartmentModule { }
