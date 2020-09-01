import { UserModel } from './user_model';

export class ProjectModel {
  projectId: number;
  title: string;
  manager: UserModel;
  description: string;
  constructor() {}
}
