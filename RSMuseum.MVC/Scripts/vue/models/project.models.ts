export class Guild {
    constructor(
        public id: number,
        public name: string) { }
}

export class Registration {
    constructor(
        public volunteerId: number,
        public hours: number,
        public date: string,
        public guildId: number) { }
}

export class Volunteer {
    constructor(
        public navn: string,
        public id: number,
        public laug: string) { }
}