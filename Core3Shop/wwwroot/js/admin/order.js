var datatable;

$(function () {
    var url = window.location.search;
    if (url.includes("approved")) {
        loadDataTable("GetAllApproved");
    }
    else if (url.includes("all")) {
        loadDataTable("GetAll");
    }
    else {
        loadDataTable("GetAllPending");
    }
});

function loadDataTable(action) {
    console.log($("#tblData"));
    datatable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/Order/" + action,
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "phone", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "itemsCount", "width": "15%" },
            { "data": "status", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Order/Details/${data}" class="btn btn-success text-white">
                                    <i class="far fa-edit"></i> Details
                                </a>
                            </div>`;
                },
                "width":"15%"
            }
        ],
        "language": {
            "emptyTable":"No records found"
        },
        "width":"100%"
    });
}
