import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MessageListComponent } from './messages/message-list/message-list.component';
import { MessageDetailComponent } from './messages/message-detail/message-detail.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MessagePanelComponent } from './messages/message-panel/message-panel.component';
import { MessageNewComponent } from './messages/message-new/message-new.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { CommonModule } from '@angular/common';
import { UserInfoComponent } from './users/user-info/user-info.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MessageListComponent,
    MessageDetailComponent,
    UserListComponent,
    DashboardComponent,
    MessagePanelComponent,
    MessageNewComponent,
    UserInfoComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
