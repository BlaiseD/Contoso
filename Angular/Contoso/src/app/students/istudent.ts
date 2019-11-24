import { IEnrollment } from './ienrollment';
import { IBaseModel } from '../common/ibase-model';

export interface IStudent extends IBaseModel {
    id: number;
    lastName: string;
    firstName: string;
    fullName: string;
    enrollmentDate: Date;
    enrollments: IEnrollment[];
}
