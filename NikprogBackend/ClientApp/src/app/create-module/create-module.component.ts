import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Module } from '../models/module';
import { NikprogApiService } from '../services/nikprog-api.service';

@Component({
  selector: 'app-create-module',
  templateUrl: './create-module.component.html',
  styleUrls: ['./create-module.component.scss']
})
export class CreateModuleComponent implements OnChanges {
  @Input() courseId: any;
  public newModule: Module = new Module();

  constructor(private moduleApiService: NikprogApiService<Module>) { }

  ngOnChanges(changes: SimpleChanges): void {
  }

  public Create() {
    this.newModule.id = Guid.create().toString();
    this.newModule.courseId = this.courseId;
    this.newModule.sequenceNum = 23;
    this.moduleApiService.post('module', this.newModule);
  }

  public IsSendable(): boolean {
    let prop: any = this.newModule;
    for (let field in this.newModule) {
      if (<string>prop[field] == '' && field != 'id' && field != 'sequenceNum' && field != 'courseId') {
        return false;
      }
    }
    return true;
  }
}
