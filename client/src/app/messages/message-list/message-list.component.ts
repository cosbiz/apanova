import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { AccountService } from 'src/app/_services/account.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  messages: any;

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.getMessages()
  }

  getMessages() {
    this.messageService.getMessages().subscribe((messages) => {
      this.messages = messages;
    })
  }
}
