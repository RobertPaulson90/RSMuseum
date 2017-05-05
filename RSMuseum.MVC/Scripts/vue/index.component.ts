import * as Vue from 'vue'

import { Guild, Registration } from "./models/project.models";
import * as $ from "jquery";

////const v = new Vue({
//    el: '#app-index',
//    data: {
//        VolunteerId: number,
//    }
//    Hours: number;
//    Date: string;
//    selectedGuild: string;
//    GuildId: number;
//    Json: '2321321213';
//    Message: string;
//    show: false;
//    guildList: Guild[];

//    mounted() {
//        this.getGuilds();
//    };

//    getGuilds() {
//        $.get('/api/GetGuilds',
//            () => {
//                for (let item of this.guildList) {
//                    this.guildList.push(new Guild(item.id, item.name));
//                }
//            });
//    };

//    submitRegistration() {
//        this.getGuildId();
//        var tempDato = $("#datetimepicker").val();
//        this.Date = tempDato; // Kan ikke lide den måde vi får dato værdi på
//        var _registration = new Registration(this.VolunteerId, this.Hours, this.Date, this.GuildId);

//        $.ajax({
//            type: 'POST',
//            url: '/api/AddRegistration',
//            data: JSON.stringify(_registration),
//            success: function () {
//                this.Message = "Din registrering er behandlet, tak for dit arbejde!"
//                this.show = true;
//                setTimeout(function () { this.show = false }, 5000);
//            },
//            error: function () {
//                this.Message = "Hov, noget gik galt"
//                this.show = true
//                setTimeout(function () { this.show = false }, 5000);
//            },
//            contentType: "application/json",
//            dataType: 'json'
//        });
//    };

//    getGuildId() {
//        for (let item of this.guildList) {
//            if (item.name === this.selectedGuild) {
//                this.GuildId = item.id;
//            }
//        }
//    }
//})

export default class IndexComponent extends Vue {
    el: '#app-index';
    VolunteerId: number;
    Hours: number;
    Date: string;
    selectedGuild: string;
    GuildId: number;
    Json: '2321321213';
    Message: string;
    show: false;
    guildList: Guild[];

    mounted() {
        this.getGuilds();
    };

    getGuilds() {
        $.get('/api/GetGuilds',
            () => {
                for (let item of this.guildList) {
                    this.guildList.push(new Guild(item.id, item.name));
                }
            });
    };

    submitRegistration() {
        this.getGuildId();
        var tempDato = $("#datetimepicker").val();
        this.Date = tempDato; // Kan ikke lide den måde vi får dato værdi på
        var _registration = new Registration(this.VolunteerId, this.Hours, this.Date, this.GuildId);

        $.ajax({
            type: 'POST',
            url: '/api/AddRegistration',
            data: JSON.stringify(_registration),
            success: function () {
                this.Message = "Din registrering er behandlet, tak for dit arbejde!"
                this.show = true;
                setTimeout(function () { this.show = false }, 5000);
            },
            error: function () {
                this.Message = "Hov, noget gik galt"
                this.show = true
                setTimeout(function () { this.show = false }, 5000);
            },
            contentType: "application/json",
            dataType: 'json'
        });
    };

    getGuildId() {
        for (let item of this.guildList) {
            if (item.name === this.selectedGuild) {
                this.GuildId = item.id;
            }
        }
    }
}