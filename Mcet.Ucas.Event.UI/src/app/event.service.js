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
var http_1 = require('@angular/http');
var Observable_1 = require('rxjs/Observable');
require('rxjs/add/observable/throw');
require('rxjs/add/operator/map');
require('rxjs/add/operator/catch');
var EventService = (function () {
    function EventService(http) {
        this.http = http;
        this.eventQueryApiBaseUrl = 'http://event-queryapi.ucas.local';
        this.eventsPath = 'events';
    }
    EventService.prototype.getEvents = function (pageNumber, pageSize, orderBy, ascending) {
        var url = this.eventQueryApiBaseUrl + "/" + this.eventsPath;
        var params = new http_1.URLSearchParams();
        params.set('pageNumber', pageNumber.toString());
        params.set('pageSize', pageSize.toString());
        params.set('orderBy', orderBy);
        params.set('ascending', ascending.toString());
        return this.http
            .get(url, { search: params })
            .map(function (response) { return response.json(); })
            .catch(function (error) { return Observable_1.Observable.throw(error.json().error) || 'Server Error'; });
    };
    EventService.prototype.getEventDetails = function (id) {
        var url = this.eventQueryApiBaseUrl + "/" + this.eventsPath + "/" + id;
        return this.http
            .get(url)
            .map(function (response) { return response.json(); })
            .catch(function (error) { return Observable_1.Observable.throw(error.json().error) || 'Server Error'; });
    };
    EventService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], EventService);
    return EventService;
}());
exports.EventService = EventService;
//# sourceMappingURL=event.service.js.map