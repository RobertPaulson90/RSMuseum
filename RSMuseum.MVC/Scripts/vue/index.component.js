"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var Vue = require("vue");
var project_models_1 = require("./models/project.models");
var $ = require("jquery");
var IndexComponent = (function (_super) {
    __extends(IndexComponent, _super);
    function IndexComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    IndexComponent.prototype.mounted = function () {
        this.getGuilds();
    };
    ;
    IndexComponent.prototype.getGuilds = function () {
        var _this = this;
        $.get('/api/GetGuilds', function () {
            for (var _i = 0, _a = _this.guildList; _i < _a.length; _i++) {
                var item = _a[_i];
                _this.guildList.push(new project_models_1.Guild(item.id, item.name));
            }
        });
    };
    ;
    IndexComponent.prototype.submitRegistration = function () {
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
    };
    ;
    IndexComponent.prototype.getGuildId = function () {
        for (var _i = 0, _a = this.guildList; _i < _a.length; _i++) {
            var item = _a[_i];
            if (item.name === this.selectedGuild) {
                this.GuildId = item.id;
            }
        }
    };
    return IndexComponent;
}(Vue));
exports.default = IndexComponent;
//# sourceMappingURL=index.component.js.map