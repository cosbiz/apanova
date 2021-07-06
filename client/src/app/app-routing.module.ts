import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { MessageDetailComponent } from './messages/message-detail/message-detail.component';
import { MessageListComponent } from './messages/message-list/message-list.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'users', component: UserListComponent},
      {path: 'users/:id', component: UserDetailComponent},
      {path: 'messages', component: MessageListComponent},
      {path: 'messages/:id', component: MessageDetailComponent},
      {path: 'dashboard', component: DashboardComponent},
    ]
  },
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
