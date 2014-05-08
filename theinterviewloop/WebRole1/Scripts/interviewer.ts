/// <reference path="./typings/jquery/jquery.d.ts" />
/// <reference path="./models.ts" />

module Interviewer {

    export class InterviewerView {
        private model: Models.Interviewer;

        constructor() {
            this.enableClickHandlersForButtons();
        }

        private enableClickHandlersForButtons() {
            this.model.firstName = $("#firstName").text();
            this.model.lastName = $("#lastName").text();
            this.model.emailAddress = $("#emailAddress").text();

            $("#add_interviewers").click(() => {
                jQuery.ajax({
                    type: "ADD",
                    url: "http://localhost:49193/Contacts.svc/Add",
                    data: this.model.toJsonString(),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: (data, status, jqXhr) => {
                        $("#add_company").addClass("disabled");
                    },

                    error: (jqXhr, status) => {
                        // error handler
                    }

                });
            });
        }
    }
}