import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { SwaggerComponent } from './swagger/swagger.component';
import { LoginComponent } from './login/login.component';
import { MicrosoftLoginProvider, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import { LogoutComponent } from './logout/logout.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseDetailsComponent } from './course-details/course-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SwaggerComponent,
    LoginComponent,
    LogoutComponent,
    CoursesComponent,
    CourseDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'home', redirectTo: '/', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'courses', component: CoursesComponent },
      { path: 'course/:id', component: CourseDetailsComponent },
      { path: 'swagger', component: SwaggerComponent },
      { path: '**', redirectTo: '/', pathMatch: 'full' }
    ])
  ],
  providers: [
    /*{ provide: MAT_DATE_LOCALE, useValue: 'hu-HU' },*/

    {// ToDo: Somehow force it to redirect mode instead of popup mode ( in abacritt/angularx-social-login I did not found options for it)
      // Problem with login: somethimes it automatically authenticates the user, so we can not chose or switch between users.
      // Problem with logout: it logs the user out of every o365 authed apps.
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: MicrosoftLoginProvider.PROVIDER_ID,
            provider: new MicrosoftLoginProvider(
              'feede3dd-2323-4aa4-b0c9-6a3608ccb9d8', {
              authority: 'https://login.microsoftonline.com/1d6a56fa-705a-4bbc-8004-67a21d5e9b97',
              redirect_uri: 'https://localhost:44431'
            })
          }
        ],
        onError: (err: String) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
