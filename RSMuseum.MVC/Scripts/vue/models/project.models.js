define(["require", "exports"], function (require, exports) {
    "use strict";
    var Guild = (function () {
        function Guild(id, name) {
            this.id = id;
            this.name = name;
        }
        return Guild;
    }());
    exports.Guild = Guild;
    var Registration = (function () {
        function Registration(volunteerId, hours, date, guildId) {
            this.volunteerId = volunteerId;
            this.hours = hours;
            this.date = date;
            this.guildId = guildId;
        }
        return Registration;
    }());
    exports.Registration = Registration;
    var Volunteer = (function () {
        function Volunteer(navn, id, laug) {
            this.navn = navn;
            this.id = id;
            this.laug = laug;
        }
        return Volunteer;
    }());
    exports.Volunteer = Volunteer;
});
//# sourceMappingURL=project.models.js.map