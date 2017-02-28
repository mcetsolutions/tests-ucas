"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var common_1 = require('@angular/common');
require('rxjs/add/operator/switchMap');
var event_service_1 = require('./event.service');
var EventDetailsComponent = (function () {
    function EventDetailsComponent(eventService, route, location) {
        this.eventService = eventService;
        this.route = route;
        this.location = location;
    }
    EventDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params
            .switchMap(function (params) { return _this.eventService.getEventDetails(params['id']); })
            .subscribe(function (event) { return _this.event = event; });
    };
    EventDetailsComponent.prototype.goBack = function () {
        this.location.back();
    };
    EventDetailsComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'my-event-details',
            templateUrl: './event-details.component.html',
            styleUrls: ['./event-details.component.css']
        }), 
        __metadata('design:paramtypes', [event_service_1.EventService, router_1.ActivatedRoute, common_1.Location])
    ], EventDetailsComponent);
    return EventDetailsComponent;
}());
exports.EventDetailsComponent = EventDetailsComponent;
//# sourceMappingURL=event-details.component.js.map