import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, InjectionToken } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Course } from '../models/course';
import { NikprogApiService } from '../services/nikprog-api.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})

export class CoursesComponent {
  public courses: Course[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private apiService: NikprogApiService<Course>) {
    this.apiService.getList("course").subscribe(courses => { this.courses = courses as Course[] });
  }
}
