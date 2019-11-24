import { IBaseModel } from '../common/ibase-model';

export interface IOfficeAssignment extends IBaseModel {
    instructorID: number;
    location: string;
}
