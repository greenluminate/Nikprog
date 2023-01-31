import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { MaterialInfo } from '../models/material-info';
import { MaterialInfoApiService } from '../services/material-info-api.service';

@Component({
  selector: 'app-material-info',
  templateUrl: './material-info.component.html',
  styleUrls: ['./material-info.component.scss']
})
export class MaterialInfoComponent implements OnChanges, OnInit {
  @Input() moduleId: any;

  public materialInfos: MaterialInfo[] = [];

  constructor(private materialInfoApiService: MaterialInfoApiService) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log(this.moduleId);
    this.materialInfoApiService
      .getMaterialInfosByModuleId('materialInfo/GetMaterialInfosByModuleId', this.moduleId)
      .subscribe(materialInfos => {
        this.materialInfos = materialInfos as MaterialInfo[]
      });
  }
}
