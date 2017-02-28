import { Injectable } from '@angular/core';
import { Headers, Http, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { PagedResult } from './paged-result'
import { EventSummary } from './event-summary'
import { EventDetails } from './event-details'

@Injectable()
export class EventService {

  private eventQueryApiBaseUrl = 'http://event-queryapi.ucas.local'
  private eventsPath = 'events';

  constructor(private http: Http) { }

  getEvents(pageNumber: number, pageSize: number, orderBy: string, ascending: boolean): Observable<PagedResult<EventSummary>> {
    
    const url = `${this.eventQueryApiBaseUrl}/${this.eventsPath}`;
    let params = new URLSearchParams();
    params.set('pageNumber', pageNumber.toString());
    params.set('pageSize', pageSize.toString());
    params.set('orderBy', orderBy);
    params.set('ascending', ascending.toString());

    return this.http
      .get(url, { search: params} )
      .map(response => response.json() as PagedResult<EventSummary>)
      .catch((error:any) => Observable.throw(error.json().error) || 'Server Error');
  }

  getEventDetails(id: string): Observable<EventDetails> {
    
    const url = `${this.eventQueryApiBaseUrl}/${this.eventsPath}/${id}`;
    
    return this.http
      .get(url)
      .map(response => response.json() as EventDetails)
      .catch((error:any) => Observable.throw(error.json().error) || 'Server Error');
  }
}