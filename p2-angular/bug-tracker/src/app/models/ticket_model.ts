import { UserModel } from './user_model';

export class TicketModel {
  ticketId: number;
  title: string;
  description: string;
  dateCreated: Date;
  dev: UserModel;
  submitter: UserModel;
  updater: UserModel;
  priority: string;
  status: string;
  type: string;

  constructor() {}
}
