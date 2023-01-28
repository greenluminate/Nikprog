import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatUrl'
})
export class FormatUrlPipe implements PipeTransform {

  transform(entityName: string): string {
    return entityName.toLowerCase().replace(' ', '-');
  }

}
