import { Component, OnInit } from '@angular/core';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-message-new',
  templateUrl: './message-new.component.html',
  styleUrls: ['./message-new.component.css']
})
export class MessageNewComponent implements OnInit {
  model: any = {};

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
  }

  newMessage() {
    this.messageService.newMessage(this.model).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }
}
