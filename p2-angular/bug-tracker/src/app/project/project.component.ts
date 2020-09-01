import { Component, OnInit } from '@angular/core';
import {ProjectModel} from '../models/project_model'
import { ProjectService } from '../services/project.service'
import { Router } from '@angular/router';


@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  projects: ProjectModel[];

  constructor(
    private projectService: ProjectService,
    ) { }

  ngOnInit(){
    this.getProjects();
    // added this random text
    console.log("rand text");
  }

  getProjects(): void{
    this.projectService.getProjects().subscribe(proj => this.projects = proj);
  }

  // goToTickets(id: number): void {
  //   this.projectService.setProjectId(id);
  //   this.router.navigate([ '/tickets/1']); // CHANGE MEEEEEEE
  // }
}
