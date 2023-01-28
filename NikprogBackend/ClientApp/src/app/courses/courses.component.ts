import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent {

  public courses: Course[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Course[]>(baseUrl + 'course', {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      })
    }).subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

}

interface Course {
  id: string;
  name: string;
  description: string;
  difficulty: string;
  photoUrl: string;
  isHidden: boolean;
}
