import { IBaseModel } from "../common/ibase-model";

export interface ICourseAssignment extends IBaseModel
{
    instructorID: number;
    courseID: number;
    courseTitle: string;
}