import { Component, ElementRef, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from '../models/course';
import { Module } from '../models/module';
import { ModuleApiService } from '../services/module-api.service';
import { NikprogApiService } from '../services/nikprog-api.service';
import { UserService } from '../services/user.service';
import {
  CdkDragDrop, CdkDragEnter, CdkDragMove,
  moveItemInArray
} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.scss'],
})
export class CourseDetailsComponent implements OnInit {
  public id: string = "";
  public name: string = "";

  public course!: Course | null;
  public modules: Module[] = [];

  dropListContainer?: ElementRef;
  dropListReceiverElement?: HTMLElement;
  dragDropInfo?: {
    dragIndex: number;
    dropIndex: number;
  };

  constructor(private router: Router, private route: ActivatedRoute,
    public userService: UserService,
    private courseApiService: NikprogApiService<Course>,
    private moduleApiService: ModuleApiService) {
    this.id = (this.router.getCurrentNavigation()?.extras.state)?.id;

    this.route.params.subscribe(params => {
      this.name = params.name;
    });
  }

  ngOnInit(): void {
    this.getCourse();
    this.getModules();
  }

  private getCourse(): void {
    this.courseApiService.get('course', this.id).subscribe(course => {
      this.course = course;
    });
  }

  private getModules(): void {
    this.moduleApiService.getModulesByCourseId('module/GetModulesByCourseId', this.id).subscribe(modules => {
      this.modules = modules as Module[]; //ToDo:Problem: State became empty on f5
      this.modules = this.modules.sort((ml, mr) => (ml.sequenceNum ?? 0) - (mr.sequenceNum ?? 0));
    });
  }
  public readLocalStorageValue(key: string) {
    return localStorage.getItem(key);
  }

  dragEntered(event: CdkDragEnter<number>) {
    const drag = event.item;
    const dropList = event.container;
    const dragIndex = drag.data;
    const dropIndex = dropList.data;

    this.dragDropInfo = { dragIndex, dropIndex };
    console.log('dragEntered', { dragIndex, dropIndex });

    const phContainer = dropList.element.nativeElement;
    const phElement = phContainer.querySelector('.cdk-drag-placeholder');

    if (phElement) {
      phContainer.removeChild(phElement);
      phContainer.parentElement?.insertBefore(phElement, phContainer);

      moveItemInArray(this.modules, dragIndex, dropIndex);
    }
  }

  dragMoved(event: CdkDragMove<number>) {
    if (!this.dropListContainer || !this.dragDropInfo) return;

    const placeholderElement =
      this.dropListContainer.nativeElement.querySelector(
        '.cdk-drag-placeholder'
      );

    const receiverElement =
      this.dragDropInfo.dragIndex > this.dragDropInfo.dropIndex
        ? placeholderElement?.nextElementSibling
        : placeholderElement?.previousElementSibling;

    if (!receiverElement) {
      return;
    }

    receiverElement.style.display = 'none';
    this.dropListReceiverElement = receiverElement;
  }

  dragDropped(event: CdkDragDrop<number>) {
    if (!this.dropListReceiverElement) {
      return;
    }

    this.dropListReceiverElement.style.removeProperty('display');
    this.dropListReceiverElement = undefined;
    this.dragDropInfo = undefined;
  }
}
