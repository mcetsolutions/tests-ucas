import { Component } from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'my-app',
  template: `
    <h1>{{title}}</h1>
    <nav>
      <a routerLink="/events" routerLinkActive="active">Events</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  styleUrls: [ './app.component.css' ]
})

export class AppComponent {
  title = 'Mcet Solutions Ltd. - UCAS Event Viewer';
}
