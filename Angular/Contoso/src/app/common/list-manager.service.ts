import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ListManagerService {

  constructor() { }

  public itemExists<T>(item: T, arr: T[], matchprops: string[]): boolean {
    let found: boolean = false;
    for (let i in arr) {
      let allKeysMetch: boolean = true;
      for (let j in matchprops) {
        if (item[matchprops[j]] !== arr[i][matchprops[j]]) {
          allKeysMetch = false;
          break;
        }
      }
      if (allKeysMetch){
        found = true;
        break;
      }
    }
    
    return found;
  }

  public mergeLists<T>(arr1: T[], arr2: T[], matchprops: string[]): T[] {
    let arr3: T[] = [];
    for (let i in arr1) {
      var shared = false;
      for (let j in arr2) {
        let allKeysMetch: boolean = true;
        for (let k in matchprops) {
          if (arr2[j][matchprops[k]] != arr1[i][matchprops[k]]) {
            allKeysMetch = false;
            break;
          }
        }
        if (allKeysMetch) {
          shared = true;
          break;
        }
      }
      if (!shared) arr3.push(arr1[i])
    }

    return arr3.concat(arr2);
  }

  public renameProperties<T>(arr1: T[], props1: string[], props2: string[]) {
    arr1.forEach(element => {
      for (let i in props1) {
        if (props1[i] !== props2[i]) {
          Object.defineProperty
            (
            element,
            props2[i],
            Object.getOwnPropertyDescriptor(element, props1[i])
            );
          delete element[props1[i]];
        }
      }
    });

    return arr1;
  }
}
