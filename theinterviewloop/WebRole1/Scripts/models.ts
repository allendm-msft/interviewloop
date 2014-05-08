/// <reference path="./typings/jquery/jquery.d.ts" />

module Models {

    export class Person {
        public id: number;
        public firstName: string;
        public lastName: string;
        public emailAddress: string;

        public toJsonString(): string {
            return JSON.stringify(this);
        }
    }

    export class Interviewer extends Person {
        public company: Company;
    };

    export class Candidate extends Person {

    }

    export class Company {
        public id: number;
        public name: string;

        public toJsonString(): string {
            return JSON.stringify(this);
        }
    };

    export class QuestionAnswer {
        public id: number;
        public question: string;
        public notes: string;
        public durationInMins: number;
        public rating: number;
    }

    export class Interview {
        public id: number;
        public interviewerId: number;
        public questionAnswerIds: number[];
        public date: Date;
        public durationInMins: number;
        public rating: number;
        public notes: string;
        public location: string;
    }
}