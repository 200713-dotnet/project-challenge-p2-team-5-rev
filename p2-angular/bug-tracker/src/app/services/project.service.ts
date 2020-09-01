import { Injectable } from '@angular/core';
import { ProjectModel } from '../models/project_model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private projectUrl = 'http://localhost:5000/api/project';

  // projectId: number = 1;

  constructor(private http: HttpClient) { }

  getProjects(): Observable<ProjectModel[]>{
    // let projects: ProjectModel[] = [
    //   {id: 1, title: "rand title1", description: "proj rand description", managerName: "rand manager title"},
    //   {id: 1, title: "rand title2", description: "proj rand description", managerName: "rand manager title"},
    //   {id: 1, title: "rand title3", description: "proj rand description", managerName: "rand manager title"}
    // ]
    console.log("getting");
    return this.http.get<ProjectModel[]>(this.projectUrl);
  }

  getProject(id: number): Observable<ProjectModel> {
    console.log("getting single project");
    return this.http.get<ProjectModel>(this.projectUrl + '/' + id);
  }

  addProject(project: ProjectModel): Observable<ProjectModel> {
    console.log("posting: " + project.title);
    return this.http.post<ProjectModel>(this.projectUrl, project, this.httpOptions);
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  // setProjectId(id: number): void {
  //   this.projectId = id;
  // }

}
