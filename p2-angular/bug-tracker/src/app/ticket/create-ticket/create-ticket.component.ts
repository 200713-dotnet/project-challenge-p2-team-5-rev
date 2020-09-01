import { Component, OnInit } from '@angular/core';
import { TicketModel } from 'src/app/models/ticket_model';
import { TicketService } from '../services/ticket.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.css'],
})
export class CreateTicketComponent implements OnInit {
  model = new TicketModel();
  projId: number;

  developers = ['dev1', 'dev2', 'dev3'];
  priorityList = ['high', 'medium', 'low'];
  statusList = ['open', 'closed', 'delayed']
  typeList = ['bug/error', 'ui', 'build'];

  constructor(
    private ticketService: TicketService,
    private route: ActivatedRoute, 
    private router: Router
    ) { }

  ngOnInit(): void {}

  add(): void {
    const id = +this.route.snapshot.paramMap.get('projectId');
    console.log('id: ' + id);
    this.ticketService
      .addTicket(id, {
        title: this.model.title.trim(),
        description: this.model.description.trim(),
        dateCreated: new Date(),
        dev: this.model.dev,
        submitter: this.model.submitter,
        priority: this.model.priority.trim(),
        status: this.model.status.trim(),
        type: this.model.type.trim(),
      } as TicketModel)
      .subscribe();                        
    console.log("subscribe");
    this.router.navigate([ '/tickets/', id ]);
  }
}
