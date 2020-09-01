import { Component, OnInit } from '@angular/core';
import { TicketModel } from '../../models/ticket_model'
import { TicketService } from '../services/ticket.service'
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ProjectModel } from 'src/app/models/project_model';
import { ProjectService } from 'src/app/services/project.service';


@Component({
  selector: 'app-view-tickets',
  templateUrl: './view-tickets.component.html',
  styleUrls: ['./view-tickets.component.css']
})
export class ViewTicketsComponent implements OnInit {

  tickets: TicketModel[];
  project: ProjectModel;

  constructor(
    private ticketService: TicketService, 
    private projectService: ProjectService,
    private route: ActivatedRoute, 
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getTickets();
  }

  getTickets(): void {
    const id = +this.route.snapshot.paramMap.get('projectId');
    this.getProject(id);
    this.ticketService.getTickets(id)
      .subscribe(t => this.tickets = t);
  }

  getProject(id: number): void {
    this.projectService.getProject(id)
      .subscribe(p => this.project = p);
  }

  delete(ticket: TicketModel): void {
    this.tickets = this.tickets.filter(t => t !== ticket);
    console.log(ticket.ticketId)
    this.ticketService.deleteTicket(ticket.ticketId).subscribe();
  }

  goBack(): void {
    this.location.back();
  }

}
