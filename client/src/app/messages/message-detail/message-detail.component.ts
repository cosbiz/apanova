import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { AccountService } from 'src/app/_services/account.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-message-detail',
  templateUrl: './message-detail.component.html',
  styleUrls: ['./message-detail.component.css']
})
export class MessageDetailComponent implements OnInit {
  message: any;

  constructor(private messageService: MessageService, private route: ActivatedRoute, private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadMessage();
  }

  loadMessage() {
    this.messageService.getMessage(this.route.snapshot.paramMap.get('id')).subscribe(message => {
      this.message = message;
    })
  }

  updateMessage() {
    this.messageService.updateMessage(this.message.id, this.message).subscribe(() => {
      console.log(this.message);
    })
  }
}
