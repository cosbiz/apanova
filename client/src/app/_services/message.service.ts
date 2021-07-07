import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  getMessages() {
    return this.http.get(this.baseUrl + 'messages')
  }

  getMessage(id: any) {
    return this.http.get(this.baseUrl + 'messages/' + id)
  }

  newMessage(model: any) {
    return this.http.post(this.baseUrl + 'messages/newMessage', model)
  }

  updateMessage(id: number, message: any) {
    return this.http.put(this.baseUrl + 'messages/' + id, message);
  }
}
