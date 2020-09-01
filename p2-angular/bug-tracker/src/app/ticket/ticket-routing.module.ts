import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewTicketsComponent } from '../ticket/view-tickets/view-tickets.component'
import { CreateTicketComponent } from '../ticket/create-ticket/create-ticket.component'

const routes: Routes = [
  { path: '', component: ViewTicketsComponent },
  { path: 'add-ticket/:projectId', component: CreateTicketComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketRoutingModule { }
