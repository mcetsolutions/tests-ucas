import { InMemoryDbService } from 'angular-in-memory-web-api';
export class InMemoryDataService implements InMemoryDbService {
  createDb() {

    let eventdetails = [
    {
        "organiser": "Abed Nadir",
        "category": 3,
        "description": "Description for event 'Widget Corp'",
        "id": "9c7d3825-c9ca-43a8-8560-be5afc833016",
        "title": "Widget Corp",
        "location": "Central Perk",
        "startDate": new Date("2015-01-28T11:00:00+00:00")
    },
    {
        "organiser": "The man they call Jayne",
        "category": 2,
        "description": "Description for event 'Atc Contracting'",
        "id": "774e685d-d876-4ae9-a96e-cee30ffe8ad2",
        "title": "Atc Contracting",
        "location": "The Shire",
        "startDate": new Date("2015-01-25T08:00:00+00:00")
    },
    {
        "organiser": "George-Michael Bluth",
        "category": 2,
        "description": "Description for event 'LuthorCorp for the investication'",
        "id": "816f3736-f0c6-4892-9682-f1ab2a91d5c7",
        "title": "LuthorCorp for the investication",
        "location": "Central Perk",
        "startDate": new Date("2015-01-23T09:00:00+00:00")
    },
    {
        "organiser": "The man they call Jayne",
        "category": 1,
        "description": "Description for event 'Ankh-Sto Associates'",
        "id": "5661f513-aede-4a44-9494-4de6eec80382",
        "title": "Ankh-Sto Associates",
        "location": "The Shire",
        "startDate": new Date("2015-01-21T14:00:00+00:00")
    },
    {
        "organiser": "Elvis",
        "category": 3,
        "description": "Description for event 'Little Sheet Metal Co'",
        "id": "456f358b-7882-485e-b58d-ab63867aadf3",
        "title": "Little Sheet Metal Co",
        "location": "Scotland Yard",
        "startDate": new Date("2015-01-17T15:00:00+00:00")
    },
    {
        "organiser": "The man they call Jayne",
        "category": 0,
        "description": "Description for event 'Kentucky Tennessee Clay Co'",
        "id": "39fa6941-f66b-47f4-9e28-c26325d6289c",
        "title": "Kentucky Tennessee Clay Co",
        "location": "Atlantis",
        "startDate": new Date("2015-01-16T11:00:00+00:00")
    },
    {
        "organiser": "George-Michael Bluth",
        "category": 2,
        "description": "Description for event 'Plantation Restaurant'",
        "id": "c779018c-950b-483f-8402-d9ce129e6acc",
        "title": "Plantation Restaurant",
        "location": "International Space Station",
        "startDate": "2015-01-15T09:00:00+00:00"
    },
    {
        "organiser": "",
        "category": 2,
        "description": "Description for event 'Goeman Wood Products Inc'",
        "id": "9981db20-60f4-4610-b1c6-c7b9a65720f1",
        "title": "Goeman Wood Products Inc",
        "location": "Las Cinco Muertes",
        "startDate": new Date("2015-01-10T11:00:00+00:00")
    },
    {
        "organiser": "The man they call Jayne",
        "category": 3,
        "description": "Description for event 'Insty Prints'",
        "id": "849be63d-e843-4f2b-811f-d5b5ac7c2aa9",
        "title": "Insty Prints",
        "location": "The Shire",
        "startDate": new Date("2015-01-01T09:00:00+00:00")
    },
    {
        "organiser": "",
        "category": 4,
        "description": "Description for event 'C 4 Network Inc 'Shows that pop!''",
        "id": "509632b0-b406-4337-a9ac-f502e749833e",
        "title": "C 4 Network Inc 'Shows that pop!'",
        "location": "",
        "startDate": new Date("2014-12-28T08:00:00+00:00")
    }];

    let events = {
        pageNumber: 1,
        pageSize: 10,
        totalResults: 148,
        totalPages: 15,
        items: [  
        {
            "id": "9c7d3825-c9ca-43a8-8560-be5afc833016",
            "title": "Widget Corp",
            "location": "Central Perk",
            "startDate": new Date("2015-01-28T11:00:00+00:00")
        },
        {
            "id": "774e685d-d876-4ae9-a96e-cee30ffe8ad2",
            "title": "Atc Contracting",
            "location": "The Shire",
            "startDate": new Date("2015-01-25T08:00:00+00:00")
        },
        {
            "id": "816f3736-f0c6-4892-9682-f1ab2a91d5c7",
            "title": "LuthorCorp for the investication",
            "location": "Central Perk",
            "startDate": new Date("2015-01-23T09:00:00+00:00")
        },
        {
            "id": "5661f513-aede-4a44-9494-4de6eec80382",
            "title": "Ankh-Sto Associates",
            "location": "The Shire",
            "startDate": new Date("2015-01-21T14:00:00+00:00")
        },
        {
            "id": "456f358b-7882-485e-b58d-ab63867aadf3",
            "title": "Little Sheet Metal Co",
            "location": "Scotland Yard",
            "startDate": new Date("2015-01-17T15:00:00+00:00")
        },
        {
            "id": "39fa6941-f66b-47f4-9e28-c26325d6289c",
            "title": "Kentucky Tennessee Clay Co",
            "location": "Atlantis",
            "startDate": new Date("2015-01-16T11:00:00+00:00")
        },
        {
            "id": "c779018c-950b-483f-8402-d9ce129e6acc",
            "title": "Plantation Restaurant",
            "location": "International Space Station",
            "startDate": new Date("2015-01-15T09:00:00+00:00")
        },
        {
            "id": "9981db20-60f4-4610-b1c6-c7b9a65720f1",
            "title": "Goeman Wood Products Inc",
            "location": "Las Cinco Muertes",
            "startDate": new Date("2015-01-10T11:00:00+00:00")
        },
        {
            "id": "849be63d-e843-4f2b-811f-d5b5ac7c2aa9",
            "title": "Insty Prints",
            "location": "The Shire",
            "startDate": new Date("2015-01-01T09:00:00+00:00")
        },
        {
            "id": "509632b0-b406-4337-a9ac-f502e749833e",
            "title": "C 4 Network Inc 'Shows that pop!'",
            "location": "",
            "startDate": new Date("2014-12-28T08:00:00+00:00")
        }
        ]
    };

    return {eventdetails, events};
  }
}
