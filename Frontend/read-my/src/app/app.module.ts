import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InterceptorService } from './auth/interceptor.service';

import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoaderComponent } from './common/components/loader/loader.component';
import { NavbarComponent } from './common/components/navbar/navbar.component';
import { AuthComponent } from './pages/auth/auth.component';
import { LandingComponent } from './pages/landing/landing.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AuthComponent,
    LoaderComponent,
    LandingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
