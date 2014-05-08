//// from backbone.js
//declare module Backbone {
//    export class Model {
//        constructor(attr?, opts?);
//        get(name: string): any;
//        set(name: string, val: any): void;
//        set(obj: any): void;
//        save(attr?, opts?): void;
//        destroy(): void;
//        bind(ev: string, f: Function, ctx?: any): void;
//        toJSON(): any;
//    }
//    export class Collection<T> {
//        constructor(models?, opts?);
//        bind(ev: string, f: Function, ctx?: any): void;
//        length: number;
//        create(attrs, opts?): any;
//        each(f: (elem: T) => void): void;
//        fetch(opts?: any): void;
//        last(): T;
//        last(n: number): T[];
//        filter(f: (elem: T) => boolean): T[];
//        without(...values: T[]): T[];
//    }
//    export class View {
//        constructor(options?);
//        $(selector: string): JQuery;
//        el: HTMLElement;
//        $el: JQuery;
//        model: Model;
//        remove(): void;
//        delegateEvents: any;
//        make(tagName: string, attrs?, opts?): View;
//        setElement(element: HTMLElement, delegate?: boolean): void;
//        setElement(element: JQuery, delegate?: boolean): void;
//        tagName: string;
//        events: any;

//        static extend: any;
//    }
//}

//// jquery
//interface JQuery {
//    fadeIn(): JQuery;
//    fadeOut(): JQuery;
//    focus(): JQuery;
//    html(): string;
//    html(val: string): JQuery;
//    show(): JQuery;
//    addClass(className: string): JQuery;
//    removeClass(className: string): JQuery;
//    append(el: HTMLElement): JQuery;
//    val(): string;
//    val(value: string): JQuery;
//    attr(attrName: string): string;
//}
////declare var $: {
////    (el: HTMLElement): JQuery;
////    (selector: string): JQuery;
////    (readyCallback: () => void): JQuery;
////};
//declare var $;
//declare var _: {
//    each<T, U>(arr: T[], f: (elem: T) => U): U[];
//    delay(f: Function, wait: number, ...arguments: any[]): number;
//    template(template: string): (model: any) => string;
//    bindAll(object: any, ...methodNames: string[]): void;
//};

/// <reference path=".\typings\jquery\jquery.d.ts" />

// model
// single q&a
class QuestionAnswer {
    private timeTakenInSeconds: number;
    private question: string;
    private comments: string;
    private questionNumber: number;

    constructor(index: number) {
        this.questionNumber = index;
    }

    public getQuestion(): string { return this.question; }
    public getComment(): string { return this.comments; }
    public setQuestion(question: string): void { this.question = question; }
    public setComment(comments: string): void { this.comments = comments; }
    public getQuestionNumber(): number { return this.questionNumber; }
}

// single interview
class Interview {
    private questionAnswers: QuestionAnswer[] = [];
    private candidate: string;
    private interviewer: string;
    private timeTaken: number;
    private generalComments: string;
    private location: string;
    private startTime: number;

    constructor() {
        this.questionAnswers.push(new QuestionAnswer(0));

        this.startTime = new Date().getTime();
        this.startTimer();
    }

    private startTimer(): void {
        this.updateTimer();

        setInterval(() => {
            this.updateTimer();
        }, 1000);
    }

    private updateTimer(): void {
        var that = this;
        var elapsed = new Date().getTime() - this.startTime;

        var s = that.checkTime(Math.floor(elapsed / 1000) % 60);
        var m = that.checkTime(Math.floor(elapsed / 60000) % 60);
        var h = that.checkTime(Math.floor(elapsed / 3600000));

        document.getElementById('timertxt').innerHTML = h + ":" + m + ":" + s;
    }

    private checkTime(i: number): string {
        var ii: string = i.toString();
        if (i < 10) {
            ii = "0" + i;
        }
        return ii;
    }

    public generateQuestionAnswerSummary(): string {
        var content: string = "",
            numQuestions = this.questionAnswers.length;

        content = "Candidate Name: " + this.candidate;

        for (var i = 1; i <= numQuestions; i++) {
            content += "Question" + i + ": " + this.questionAnswers[i].getQuestion();
            content += "%0D%0ANotes: " + this.questionAnswers[i].getComment();
            content += "%0D%0A";
            content += "%0D%0A";
        }
        content += "Final Notes: " + this.generalComments;
        content += "%0D%0A";
        content += "%0D%0A";
        content += "Total Time: " + this.timeTaken;

        return "mailto:?to=" + this.interviewer + "&subject=" + this.location + "&body=" + content;
    }

    public getNextQuestionAnswer(): QuestionAnswer {
        var count: number = this.questionAnswers.length;
        var qna: QuestionAnswer = new QuestionAnswer(count);
        this.questionAnswers.push(qna);
        return qna;
    }

    public getTotalQuestions(): number {
        return this.questionAnswers.length;
    }
}

class QuestionAnswerView {
    private qna: QuestionAnswer;

    constructor(qna: QuestionAnswer) {
        this.qna = qna;
    }
}

class InterviewView {
    private model: Interview;
    private $tablist: any;

    constructor() {
        this.model = new Interview();

        this.$tablist = $("#tabbable");
        this.$tablist.tabs();

        this.enableClickHandlersForButtons();
    }

    private enableClickHandlersForButtons() {
        $("#add_tab").click(() => {
            this.addQuestionAnswer();
        });

        $("#doneButton").click(() => {
            this.closeInterview();
        });

        $("#submit_feedback").click(() => {
            this.closeInterview();
        });
    }

    public addQuestionAnswer() {
        var qna: QuestionAnswer = this.model.getNextQuestionAnswer();
        var qnaCount: number = qna.getQuestionNumber();

        this.addQuestionTab(qnaCount);
        this.addQuestionAnswerDiv(qnaCount);

        this.$tablist.tabs("option", "active", qnaCount);
    }

    // the tabs
    private addQuestionTab(count: number): void {
        $("#myTabList li:first").clone(true).appendTo("#myTabList").removeClass("active");
        $("#myTabList li:last a:first").attr("href", "#tab" + count).text("Question " + ++count);
        this.$tablist.tabs("refresh");
    }

    // content per tab
    private addQuestionAnswerDiv(count: number) {
        $("#myTabContent div:first").clone(true).appendTo("#myTabContent").removeClass("active");
        $("#myTabContent div:last").attr("id", "tab" + count);
        //$("#myTabContent div:last textarea:first").attr("id", "question-" + count).val(null);
        //$("#myTabContent div:last textarea:last").attr("id", "answer-" + count).val(null);
    }

    public submitFeedback(event: MouseEvent) {
    }


    public closeInterview() {
        var email: string;

        email = this.model.generateQuestionAnswerSummary();

        // should open up local email client
        window.open(email);
    }
}


// Load the application once the DOM is ready, using `jQuery.ready`:
$(() => {
    var interviewView: InterviewView = new InterviewView();
});
