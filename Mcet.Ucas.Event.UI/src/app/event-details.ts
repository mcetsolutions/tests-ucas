import { EventSummary } from './event-summary'

export class EventDetails extends EventSummary {
  organiser: string;
  category: number;
  description: string;
}