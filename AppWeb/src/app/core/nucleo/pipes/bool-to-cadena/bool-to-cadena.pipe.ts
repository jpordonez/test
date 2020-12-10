import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'boolToCadena'
})
export class BoolToCadenaPipe implements PipeTransform {

  transform(value: boolean, valorPositivo: string, valorNegativo: string): any {
    return value ? valorPositivo : valorNegativo;
  }

}
