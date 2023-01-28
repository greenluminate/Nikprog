import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router, RouterModule } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Course } from '../models/course';
import { Module } from '../models/module';
import { NikprogApiService } from '../services/nikprog-api.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.scss']
})
export class CourseDetailsComponent implements OnInit {
  public id: string = "";
  public name: string = "";
  public course!: Course | null;
  public modules: Module[] = [];

  constructor(private router: Router, private route: ActivatedRoute, private courseApiService: NikprogApiService<Course>, private moduleApiService: NikprogApiService<Module>) {
    this.id = (this.router.getCurrentNavigation()?.extras.state)?.id;

    this.route.params.subscribe(params => {
      this.name = params.name;
    });
  }

  ngOnInit(): void {
    this.courseApiService.get("course", this.id).subscribe(course => {
      this.course = course;
    });

    this.moduleApiService.getList("module").subscribe(modules => {
      this.modules = modules as Module[]//ToDo: serverside: write to get modules by course id!
    });
  }
}
