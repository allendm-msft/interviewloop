/// <reference path="./typings/jquery/jquery.d.ts" />
/// <reference path="./models.ts" />

module Company {
    
    export class CompanyView {
        private model: Models.Company;

        constructor() {
            this.model = new Models.Company();

            this.enableClickHandlersForButtons();
        }

        private enableClickHandlersForButtons() {
            this.model.name = $("#companyName").text();
            $("#add_company").click(() => {
                jQuery.ajax({
                    type: "POST",
                    url: "http://localhost:12987/api/Companies",
                    data: this.model.toJsonString(),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: (data, status, jqXhr) => {

                    },

                    error: (jqXhr, status) => {
                        // error handler
                    }

                });
                $("#add_company").addClass("disabled");
            });
            $("#interviewers").removeClass("hidden");

            $("#empDetailsModal").on("hidden.bs.modal", function () {
                $("#interviewersTableBody tr:last").append("tr").append("td").text("+/-");
            });

            //$("#empDetailsModal").on("show.bs.modal", function () {
            //    this.model.name = "nothing";
            //});
        }
    }
}

// Load the application once the DOM is ready, using `jQuery.ready`
$(document).ready(() => {
    var companyView = new Company.CompanyView();
});
