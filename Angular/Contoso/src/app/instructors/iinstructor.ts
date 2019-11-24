import { IBaseModel } from '../common/ibase-model';
import { ICourseAssignment } from './icourse-assignment';
import { IOfficeAssignment } from './ioffice-assignment';

export interface IInstructor extends IBaseModel {
    id: number;
    lastName: string;
    firstName: string;
    fullName: string;
    hireDate: Date;
    officeAssignment: IOfficeAssignment;
    courses: ICourseAssignment[];
}
