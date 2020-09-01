import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { ProjectModel } from '../models/project_model';
import { ProjectComponent } from '../project/project.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css'],
})
export class CreateProjectComponent implements OnInit {

  model = new ProjectModel();
  managerList = [1111, 22222, 33333]

  constructor(
    private projectService: ProjectService,
    private router: Router
    ) { }
    
  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  add(): void {
    this.projectService
      .addProject({
        title: this.model.title.trim(),
        description: this.model.description.trim(),
        manager: this.model.manager,
      } as ProjectModel)
      .subscribe();
    // .subscribe(project => {
    //   this.projectComponent.projects.push(project);
    // });
  }
}
