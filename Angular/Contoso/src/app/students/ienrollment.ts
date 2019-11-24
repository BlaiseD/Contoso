import { IBaseModel } from '../common/ibase-model';
export interface IEnrollment extends IBaseModel {
    enrollmentID: number;
    courseID: number;
    studentID: number;
    gradeLetter: string;
    courseTitle: string;
}