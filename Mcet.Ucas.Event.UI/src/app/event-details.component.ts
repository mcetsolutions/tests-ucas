import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { EventService } from './event.service';
import { EventDetails } from './event-details';

@Component({
  moduleId: module.id,
  selector: 'my-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: [ './event-details.component.css' ]
})

export class EventDetailsComponent implements OnInit {

  event: EventDetails;

  constructor(
    private eventService: EventService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.route.params
      .switchMap((params: Params) => this.eventService.getEventDetails(params['id']))
      .subscribe(event => this.event = event);
  }

  goBack(): void {
    this.location.back();
  }

}
