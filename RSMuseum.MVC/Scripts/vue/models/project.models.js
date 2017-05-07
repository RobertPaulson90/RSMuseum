"use strict";
class Guild {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}
exports.Guild = Guild;
class Registration {
    constructor(volunteerId, hours, date, guildId) {
        this.volunteerId = volunteerId;
        this.hours = hours;
        this.date = date;
        this.guildId = guildId;
    }
}
exports.Registration = Registration;
class Volunteer {
    constructor(navn, id, laug) {
        this.navn = navn;
        this.id = id;
        this.laug = laug;
    }
}
exports.Volunteer = Volunteer;
//# sourceMappingURL=project.models.js.map