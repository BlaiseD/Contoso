import { AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

export class NumberValidators {

    static range(min: number, max: number): ValidatorFn {
        return (c: AbstractControl): { [key: string]: boolean } | null => {
            if (c.value && (isNaN(c.value) || c.value < min || c.value > max)) {
                return { 'range': true };
            }
            return null;
        };
    }

    //all these work
    //use NumberValidators.mustBeNumber()
    static mustBeNumber(): ValidatorFn {
        return (c: AbstractControl): { [key: string]: boolean } | null => {
            if (c.value && (isNaN(c.value))) {
                return { 'mustBeNumber': true };
            }
            return null;
        };
    }

    //all these work
    //use NumberValidators.mustBeANumber
    static mustBeANumber(c: AbstractControl): ValidationErrors | null {
        if (c.value && (isNaN(c.value))) {
            return { 'mustBeANumber': true };
        }
        return null;
    }

    //all these work
    static mustReallyBeANumber(c: AbstractControl): ValidationErrors {
        if (c.value && (isNaN(c.value))) {
            return { 'mustReallyBeANumber': true };
        }
        return null;
    }
}