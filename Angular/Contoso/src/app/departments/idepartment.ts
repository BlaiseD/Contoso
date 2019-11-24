import { IBaseModel } from '../common/ibase-model';

export interface IDepartment extends IBaseModel {
    departmentID: number;
    name: string;
    budget: number;
    startDate: Date;
    instructorID: number;
    rowVersion: string;
    administratorName: string;
}
