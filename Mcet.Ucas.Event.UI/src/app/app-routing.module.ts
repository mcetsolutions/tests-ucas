import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EventsComponent }      from './events.component';
import { EventDetailsComponent }  from './event-details.component';

const routes: Routes = [
  { path: '', redirectTo: '/events', pathMatch: 'full' },
  { path: 'detail/:id', component: EventDetailsComponent },
  { path: 'events',     component: EventsComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}
