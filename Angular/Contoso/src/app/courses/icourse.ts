import { IBaseModel } from '../common/ibase-model';

export interface ICourse extends IBaseModel {
    courseID: number;
    title: string;
    credits: number;
    departmentID: number;
    departmentName: string;
}
