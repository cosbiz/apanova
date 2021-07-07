import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: any;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.getUsers()
  }

  getUsers() {
    this.accountService.getUsers().subscribe((users) => {
      this.users = users;
    })
  }

  deleteUser(id: number) {
    this.accountService.deleteUser(id).subscribe(() => {
      this.users.splice(
        this.users.findIndex(m => m.id == id), 1
      )
    })
  }

}
