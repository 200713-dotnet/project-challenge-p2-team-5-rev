import { Injectable } from '@angular/core';
import { ProjectModel } from '../models/project_model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  private projectUrl =
    'https://bugtrackerservice.azurewebsites.net/api/project';

  constructor(private http: HttpClient) {}

  getProjects(): Observable<ProjectModel[]> {
    console.log('getting');
    return this.http.get<ProjectModel[]>(this.projectUrl);
  }

  getProject(id: number): Observable<ProjectModel> {
    console.log('getting single project');
    return this.http.get<ProjectModel>(this.projectUrl + '/' + id);
  }

  addProject(project: ProjectModel): Observable<ProjectModel> {
    console.log('posting: ' + project.title);
    return this.http.post<ProjectModel>(
      this.projectUrl,
      project,
      this.httpOptions
    );
  }

  deleteProject(project: ProjectModel | number): Observable<ProjectModel> {
    const id = typeof project === 'number' ? project : project.projectId;
    const url = `${this.projectUrl}/${id}`;
    return this.http.delete<ProjectModel>(url, this.httpOptions);
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
}
