"use strict";
const Vue = require("vue");
const project_models_1 = require("./models/project.models");
const $ = require("jquery");
class IndexComponent extends Vue {
    mounted() {
        this.getGuilds();
    }
    ;
    getGuilds() {
        $.get('/api/GetGuilds', () => {
            for (let item of this.guildList) {
                this.guildList.push(new project_models_1.Guild(item.id, item.name));
            }
        });
    }
    ;
    submitRegistration() {
        this.getGuildId();
        var tempDato = $("#datetimepicker").val();
        this.Date = tempDato; // Kan ikke lide den måde vi får dato værdi på
        var _registration = new project_models_1.Registration(this.VolunteerId, this.Hours, this.Date, this.GuildId);
        $.ajax({
            type: 'POST',
            url: '/api/AddRegistration',
            data: JSON.stringify(_registration),
            success: function () {
                this.Message = "Din registrering er behandlet, tak for dit arbejde!";
                this.show = true;
                setTimeout(function () { this.show = false; }, 5000);
            },
            error: function () {
                this.Message = "Hov, noget gik galt";
                this.show = true;
                setTimeout(function () { this.show = false; }, 5000);
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
    ;
    getGuildId() {
        for (let item of this.guildList) {
            if (item.name === this.selectedGuild) {
                this.GuildId = item.id;
            }
        }
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = IndexComponent;
//# sourceMappingURL=index.component.js.map