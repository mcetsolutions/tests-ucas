import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule }    from '@angular/http';
import { TruncateModule } from 'ng2-truncate'

import { AppRoutingModule }     from './app-routing.module';

import {Ng2PaginationModule} from 'ng2-pagination';

import { AppComponent }  from './app.component';
import { EventDetailsComponent } from './event-details.component';
import { EventsComponent }     from './events.component';
import { EventService }         from './event.service';

@NgModule({
  imports: [ 
    BrowserModule,
    FormsModule,
    HttpModule,
    Ng2PaginationModule,
    AppRoutingModule,
    TruncateModule
  ],
  declarations: [
    AppComponent,
    EventDetailsComponent,
    EventsComponent
  ],
  providers: [ EventService ],
  bootstrap: [ AppComponent ]
})

export class AppModule { }