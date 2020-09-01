import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { ProjectModel } from '../models/project_model';
import { ProjectComponent } from '../project/project.component';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css'],
})
export class CreateProjectComponent implements OnInit {
  managers = ['manager1', 'manager2', 'manager3'];

  model = new ProjectModel();

  constructor(private projectService: ProjectService) {}

  ngOnInit(): void {}

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
