import { Injectable } from '@angular/core';
import { TicketModel } from 'src/app/models/ticket_model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProjectService } from 'src/app/services/project.service';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  ticketUrl: string = 'https://bugtrackerservice.azurewebsites.net/api/ticket/';

  constructor(
    private http: HttpClient,
    private projectService: ProjectService
  ) {}

  getTickets(projectId: number): Observable<TicketModel[]> {
    console.log('getting tickets....');
    return this.http.get<TicketModel[]>(
      this.ticketUrl + 'getticketsbyprojectid/' + projectId
    );
  }

  addTicket(id: number, ticket: TicketModel): Observable<TicketModel> {
    return this.http.post<TicketModel>(
      this.ticketUrl,
      ticket,
      this.httpOptions
    );
  }

  deleteTicket(ticket: TicketModel | number): Observable<TicketModel> {
    const id = typeof ticket === 'number' ? ticket : ticket.ticketId;
    const url = `${this.ticketUrl}${id}`;
    // console.log("id: " + id)
    // console.log(url)
    return this.http.delete<TicketModel>(url, this.httpOptions);
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
}
