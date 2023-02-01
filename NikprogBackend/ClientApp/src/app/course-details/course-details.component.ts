import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from '../models/course';
import { Module } from '../models/module';
import { ModuleApiService } from '../services/module-api.service';
import { NikprogApiService } from '../services/nikprog-api.service';
import { UserService } from '../services/user.service';

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
      this.modules = modules as Module[] //ToDo:Problem: State became empty on f5
    });
  }

}
