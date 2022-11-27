import { ProjectParticipantResponse } from './projectParticipantResponse';

export interface ProjectResponse {
  id: string;
  name: string;
  description: string;
  creator: ProjectParticipantResponse;
  creationDate: Date;
  participants: Array<ProjectParticipantResponse>;
}
