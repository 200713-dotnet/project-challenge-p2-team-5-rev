import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TicketRoutingModule } from './ticket-routing.module';
import { ViewTicketsComponent } from './view-tickets/view-tickets.component';
import { CreateTicketComponent } from './create-ticket/create-ticket.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ViewTicketsComponent, CreateTicketComponent],
  imports: [
    CommonModule,
    TicketRoutingModule,
    FormsModule
  ]
})
export class TicketModule { }
