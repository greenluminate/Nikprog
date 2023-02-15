import { Component, Input, SimpleChanges } from '@angular/core';
import { Guid } from 'guid-typescript';
import { MaterialInfo } from '../models/material-info';
import { MaterialInfoApiService } from '../services/material-info-api.service';

@Component({
  selector: 'app-create-material',
  templateUrl: './create-material.component.html',
  styleUrls: ['./create-material.component.scss']
})
export class CreateMaterialComponent {
  @Input() moduleId: any;
  public newMaterialInfo: MaterialInfo = new MaterialInfo();

  constructor(private materialInfoApiService: MaterialInfoApiService) { }

  ngOnChanges(changes: SimpleChanges): void {
  }

  public Create() {
    this.newMaterialInfo.id = Guid.create().toString();
    this.newMaterialInfo.moduleId = this.moduleId;
    this.newMaterialInfo.sequenceNum = undefined;
    //this.newMaterialInfo.sequenceNum = this.modulesCount;//This is WRONG it should be solve on serverside!!! It is temporary.
    this.materialInfoApiService.post('materialInfo', this.newMaterialInfo);
  }

  public IsSendable(): boolean {
    let prop: any = this.newMaterialInfo;
    for (let field in this.newMaterialInfo) {
      if (<string>prop[field] == '' && field != 'id' && field != 'sequenceNum' && field != 'moduleId') {
        return false;
      }
    }
    return true;
  }
}
