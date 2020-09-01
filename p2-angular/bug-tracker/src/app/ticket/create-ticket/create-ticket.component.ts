import { Component, OnInit } from '@angular/core';
import { TicketModel } from 'src/app/models/ticket_model';
import { TicketService } from '../services/ticket.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.css']
})
export class CreateTicketComponent implements OnInit {

  model = new TicketModel;
  projId: number;

  constructor(
    private ticketService: TicketService,
    private route: ActivatedRoute, 
    ) { }

  ngOnInit(): void {
  }

  add(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    console.log('id: ' + id);
    this.ticketService.addTicket( id, 
      {title: this.model.title.trim(), 
      description: this.model.description.trim(), 
      created: new Date(),
      dev: this.model.dev.trim(),
      submitter: this.model.submitter.trim(),
      priority: this.model.priority.trim(),
      status: this.model.status.trim(),
      type: this.model.type.trim(),
      } as TicketModel)
      .subscribe();                        
    console.log("subscribe");
  }

}
