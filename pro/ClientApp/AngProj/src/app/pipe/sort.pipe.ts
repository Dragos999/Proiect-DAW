import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  transform(list1:string[]): string[] {
    if(!list1){
      return [];
    }else{
      return list1.sort();
    }
  }

}
