import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { PagedResult } from './paged-result'
import { EventSummary } from './event-summary';
import { EventService } from './event.service'

@Component({
  moduleId: module.id,
  selector: 'my-events',
  templateUrl: './events.component.html',
  styleUrls: [ './events.component.css' ] 
})

export class EventsComponent implements OnInit  {

  selectedEvent: EventSummary;
  events: Observable<EventSummary[]>;
  
  pageNumber: number = 1;
  pageSize: number = 10;
  totalResults: number;
  loading: boolean;
  titleWidth: number = 50;

  orderByFieldNames: [string, string][] = [
    [ "Title", "Title" ],
    [ "Start Date", "StartDate" ],
    [ "Location", "Location" ]
  ];
  selectedOrderByField: string = "StartDate";

  orderByDirections: [string, boolean][] = [
    [ "Ascending", true ],
    [ "Descending", false ]
  ];
  selectedAscendingOrder: boolean = false;

  constructor(
    private router: Router,
    private eventService: EventService) { }

  getEvents(pageNumber?: number): void {

    if (pageNumber) {
      this.pageNumber = pageNumber;
    }

    this.loading = true;
    this.events = this.eventService.getEvents(this.pageNumber, this.pageSize, this.selectedOrderByField, this.selectedAscendingOrder)
      .do(res => {
        this.totalResults = res.totalResults;
        this.pageNumber = res.pageNumber;
        this.loading = false;
      })
      .map(res => res.items);
  }

  ngOnInit(): void {
    this.getEvents();
  }

  gotoDetail(event: EventSummary): void {
    this.selectedEvent = event;
    this.router.navigate(['/detail', this.selectedEvent.id]);
  }
}