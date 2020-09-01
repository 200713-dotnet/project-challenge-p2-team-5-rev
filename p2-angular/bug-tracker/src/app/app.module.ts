import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectComponent } from './project/project.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateProjectComponent } from './create-project/create-project.component';
import { TicketModule } from './ticket/ticket.module'

@NgModule({
  declarations: [
    AppComponent,
    ProjectComponent,
    CreateProjectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    TicketModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
