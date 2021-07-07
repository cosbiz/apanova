import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { MessageDetailComponent } from './messages/message-detail/message-detail.component';
import { MessageListComponent } from './messages/message-list/message-list.component';
import { MessageNewComponent } from './messages/message-new/message-new.component';
import { MessagePanelComponent } from './messages/message-panel/message-panel.component';
import { RegisterComponent } from './register/register.component';
import { UserInfoComponent } from './users/user-info/user-info.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'users', component: UserListComponent},
      {path: 'users/details', component: UserInfoComponent, canActivate: [AdminGuard]},
      {path: 'messages', component: MessagePanelComponent},
      {path: 'message/new', component: MessageNewComponent},
      {path: 'message/list', component: MessageListComponent},
      {path: 'message/detail', component: MessageDetailComponent},
      {path: 'message/:id', component: MessageDetailComponent},
      {path: 'dashboard', component: DashboardComponent, canActivate: [AdminGuard]},
      {path: 'register', component: RegisterComponent, canActivate: [AdminGuard]},
    ]
  },
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
