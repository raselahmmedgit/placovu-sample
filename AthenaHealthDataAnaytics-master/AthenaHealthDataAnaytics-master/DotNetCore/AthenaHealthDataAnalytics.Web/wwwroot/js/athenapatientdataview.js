
var athenaPatientDataViewObjData;

//HtmlTable
function generateDataTablesFromJson(dataTableId, iDisplayLength) {

    $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

    $('#' + dataTableId).DataTable({
        "bJQueryUI": true,
        "bAutoWidth": true,
        "sPaginationType": "full_numbers",
        "bPaginate": true,
        "iDisplayLength": iDisplayLength,
        "bSort": false,
        "bFilter": false,
        "bSortClasses": false,
        "lengthChange": false,
        "oLanguage": {
            "sLengthMenu": "Display _MENU_ records per page",
            "sZeroRecords": "Data not found.",
            "sInfo": "Page _START_ to _END_ (about _TOTAL_ results)",
            "sInfoEmpty": "Page 0 to 0 (about 0 results)",
            "sInfoFiltered": ""
        }
    });

};

function createHtmlTableFromJson(tableContainerId, iDisplayLength, data, labelIndex) {
    var nextIndex = parseInt(labelIndex) + 1;
    console.log("labelIndex " + labelIndex + " , nextIndex" + nextIndex);
    var jsonData = [];
    if (!Array.isArray(data)) {
        jsonData.push(data);
    }
    else {
        jsonData = data;
    }

    // EXTRACT VALUE FOR HTML HEADER.
    var col = [];
    for (var i = 0; i < jsonData.length; i++) {
        for (var key in jsonData[i]) {
            if (col.indexOf(key) === -1) {
                col.push(key);
            }
        }
    }

    var tableId = 'tableAthenaPatientDataViewDetail_' + labelIndex;
    var table = '<table id="' + tableId + '" class="table table-condenced table-striped table-bordered dt-responsive nowrap" style="width:100%" >';

    // Create an <thead> element and add it to the table:
    table += '<thead>';

    table += '<tr>';

    for (var i = 0; i < col.length; i++) {
        var colHeadTitle = col[i];
        table += ('<th>' + colHeadTitle + '</th>');
    }

    table += '</tr>';

    table += '</thead>';
    // Create an <thead> element and add it to the table:

    // Create an <tbody> element and add it to the table:
    table += '<tbody>';

    // ADD Json DATA TO THE TABLE AS ROWS.
    for (var i = 0; i < jsonData.length; i++) {

        table += '<tr>';

        for (var j = 0; j < col.length; j++) {
            var colHeadTitle = col[j];
            var tabCellVal = jsonData[i][col[j]];
            if (tabCellVal !== undefined) {
                if (Array.isArray(tabCellVal)) {
                    //array
                    var tabCellValJson = JSON.stringify(tabCellVal);
                    var tabCellValHTML = "<button class='btn btn-secondary btnAthenaPatientDataViewDetailHtmlTable' data-bgheader='bg-secondary' data-labelindex=" + nextIndex + " data-modaltitle='" + colHeadTitle + "' data-jsonrowindex='" + i + "' data-jsoncolcellindex='" + j + "' data-jsondata='" + tabCellValJson + "'> Show </button>";
                    table += ('<td>' + tabCellValHTML + '</td>');
                }
                else if (tabCellVal !== null && typeof (tabCellVal) === 'object') {
                    //object
                    var tabCellValJson = JSON.stringify(tabCellVal);
                    var tabCellValHTML = "<button class='btn btn-secondary btnAthenaPatientDataViewDetailHtmlTable' data-bgheader='bg-secondary hello' data-labelindex=" + nextIndex + " data-modaltitle='" + colHeadTitle + "' data-jsonrowindex='" + i + "' data-jsoncolcellindex='" + j + "' data-jsondata='" + tabCellValJson + "'> Show </button>";
                    table += ('<td>' + tabCellValHTML + '</td>');
                }
                else {
                    //property
                    table += ('<td>' + tabCellVal + '</td>');
                }
            }
            else {
                //undefined
                table += ('<td> </td>');
            }
        }//col for

        table += '</tr>';

    }//jsonData.length for

    table += '</tbody>';
    // Create an <tbody> element and add it to the table:

    table += '</table>';
    var initIndex = parseInt(labelIndex);
    for (var i = initIndex; i < 10; i++) {
        $('#athenaPatientDetailCard_' + i).remove();
        $('#athenaPatientDetailCardBody_' + i).remove();
    }


    tableContainerId = tableContainerId + '_' + labelIndex;
    var htmlDetail = '<div class="card" id="athenaPatientDetailCard_' + labelIndex + '">'
        + '<div id="AthenaPatientDataViewDetailBgHeader_' + labelIndex + '" class="card-header">'
        + '<h5 id="AthenaPatientDataViewDetailTitle_' + labelIndex + '"></h5>'
        + '</div>'
        + '<div class="card-body scroll-x-y" id="athenaPatientDetailCardBody_' + labelIndex + '">'
        + '    <div id="' + tableContainerId + '"></div>'
        + '</div>'
        + '</div>'

    $("#AthenaPatientDataViewDetail").append(htmlDetail);
    $('#' + tableContainerId).html('');
    $('#' + tableContainerId).append(table);
    $("#AthenaPatientDataViewDetailContainer").show();
    // FINALLY ADD THE NEWLY GENERATE DATATABLE WITH Json DATA TO A CONTAINER.
    generateDataTablesFromJson(tableId, iDisplayLength);

};

function loadHtmlTable(dataUrl, bgHeader, title) {

    $.ajax({
        url: dataUrl,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
        },
        success: function (data) {
            var jsonData = JSON.parse(data);
            createHtmlTableFromJson('AthenaPatientDataViewDetailTableContainer', App.DisplayLength(), (jsonData), 1);
            showAthenaPatientDataViewDetailContainer(bgHeader, title, 1);
            App.LoaderHide();
        },
        error: function (objAjaxRequest, strError) {
            //var respText = objAjaxRequest.responseText;
            //var messageText = respText;
            //App.ToastrNotifierError(messageText);
            App.ToastrNotifierError(appMessage.Error);
            App.LoaderHide();
        }

    });

}

function loadDetailHtmlTable(data, bgHeader, title, labelIndex) {

    var jsonData = JSON.parse(data);

    if (jsonData !== undefined && jsonData !== null && jsonData.length !== 0) {

        hideAthenaPatientDataViewDetailContainer();

        createHtmlTableFromJson('AthenaPatientDataViewDetailTableContainer', App.DisplayLength(), (jsonData), labelIndex);

        showAthenaPatientDataViewDetailContainer(bgHeader, title, labelIndex);
    }
}
//HtmlTable

//JsonViewer
function loadDetailJsonViewerByJson(jsonViewerId, jsonData) {

    var options = {
        collapsed: false,
        rootCollapsable: true,
        withQuotes: false,
        withLinks: true
    };
    $('#' + jsonViewerId).jsonViewer(jsonData, options);

};

function loadJsonViewer(dataUrl, bgHeader, modalTitle) {

    $.ajax({
        url: dataUrl,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
        },
        success: function (data) {
            var jsonData = JSON.parse(data);
            loadDetailJsonViewerByJson('jsonViewerAthenaPatientDataViewDetail', (jsonData));
            showAthenaPatientDataViewDetailContainer(bgHeader, modalTitle, 1);
            App.LoaderHide();
        },
        error: function (objAjaxRequest, strError) {
            //var respText = objAjaxRequest.responseText;
            //var messageText = respText;
            //App.ToastrNotifierError(messageText);
            App.ToastrNotifierError(appMessage.Error);
            App.LoaderHide();
        }

    });

}

function loadModalJsonViewer(dataUrl, bgHeader, modalTitle) {

    $.ajax({
        url: dataUrl,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
        },
        success: function (data) {
            var jsonData = JSON.parse(data);
            loadDetailJsonViewerByJson('jsonViewerAthenaPatientDataViewDetailModal', (jsonData));
            showAthenaPatientDataViewDetailModal(bgHeader, modalTitle);
            App.LoaderHide();
        },
        error: function (objAjaxRequest, strError) {
            //var respText = objAjaxRequest.responseText;
            //var messageText = respText;
            //App.ToastrNotifierError(messageText);
            App.ToastrNotifierError(appMessage.Error);
            App.LoaderHide();
        }

    });

}
//JsonViewer

//Show Hide Modal
function loadAthenaPatientDataViewDetailModal($btn) {
    var dataUrl = $btn.attr("data-url");
    var bgHeader = $btn.attr("data-bgheader");
    var modalTitle = $btn.attr("data-modaltitle");
    //loadHtmlTable(dataUrl, bgHeader, modalTitle); //show table
    loadModalJsonViewer(dataUrl, bgHeader, modalTitle);
};

function showAthenaPatientDataViewDetailModal(bgHeader, modalTitle) {
    $('#AthenaPatientDataViewDetailModalBgHeader').addClass('modal-header');
    $('#AthenaPatientDataViewDetailModalBgHeader').addClass(bgHeader);
    $('#AthenaPatientDataViewDetailModalTitle').html(modalTitle);
    $('#AthenaPatientDataViewDetailModal').modal('show');
};

function hideAthenaPatientDataViewDetailModal() {
    $('#AthenaPatientDataViewDetailModalBgHeader').removeClass();
    $('#AthenaPatientDataViewDetailModalTitle').html('');
    $('#AthenaPatientDataViewDetailModal').modal('hide');
};

//Show Hide Modal

//Show Hide Container
function loadAthenaPatientDataViewDetailContainer($btn) {
    var dataUrl = $btn.attr("data-url");
    var bgHeader = $btn.attr("data-bgheader");
    var modalTitle = $btn.attr("data-modaltitle");
    loadHtmlTable(dataUrl, bgHeader, modalTitle); //show table
    //loadJsonViewer(dataUrl, bgHeader, modalTitle);
};

function showAthenaPatientDataViewDetailContainer(bgHeader, title, labelIndex) {
    $('#AthenaPatientDataViewDetailBgHeader_' + labelIndex).addClass('card-header');
    $('#AthenaPatientDataViewDetailBgHeader_' + labelIndex).addClass(bgHeader);
    $('#AthenaPatientDataViewDetailTitle_' + labelIndex).html(title);
    $('#AthenaPatientDataViewDetailContainer_' + labelIndex).show();
};

function hideAthenaPatientDataViewDetailContainer() {
    $('#AthenaPatientDataViewDetailBgHeader').removeClass();
    $('#AthenaPatientDataViewDetailTitle').html('');
    $('#AthenaPatientDataViewDetailContainer').hide();
};

//Show Hide Container

var AthenaPatientDataView = function () {

    //public function
    var initEvent = function (dataTableId) {

        //for display more collapse data from ViewDetail
        var viewDetailId = '#' + dataTableId + ' tbody td button.btnAthenaPatientDataViewDetail';
        $('body').on('click', viewDetailId, function (e) {
            App.LoaderShow();

            var $this = $(this);
            if ($this.attr('class').match('btnAthenaPatientDataViewDetail')) {
                if ($this.text() == 'Show') {
                    //todo code
                    //loadAthenaPatientDataViewDetailModal($this);
                    loadAthenaPatientDataViewDetailContainer($this);
                } else {
                }
            }
        });

        //for display more collapse data from Html Table
        var tableAthenaPatientDataViewDetailBtnId = 'button.btnAthenaPatientDataViewDetailHtmlTable';
        $('body').on('click', tableAthenaPatientDataViewDetailBtnId, function (e) {
            //App.LoaderShow();

            var $this = $(this);
            var jsonData = $this.attr("data-jsondata");
            var bgHeader = $this.attr("data-bgheader");
            var modalTitle = $this.attr("data-modaltitle");
            var labelIndex = $this.attr("data-labelindex");
            if (jsonData == null || jsonData == '[]' || jsonData == '{}') {
                $("#NoRecordModal").modal("show");
            }
            else {
                loadDetailHtmlTable(jsonData, bgHeader, modalTitle, labelIndex); //show table

            }

            //App.LoaderHide();
        });

    };

    var loadDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        athenaPatientDataViewObjData = $('#' + dataTableId).DataTable({
            "bJQueryUI": true,
            "bAutoWidth": true,
            "sPaginationType": "full_numbers",
            "bPaginate": true,
            "iDisplayLength": iDisplayLength,
            "bSort": false,
            "bFilter": true,
            "bSortClasses": false,
            "lengthChange": false,
            "oLanguage": {
                "sLengthMenu": "Display _MENU_ records per page",
                "sZeroRecords": "Data not found.",
                "sInfo": "Page _START_ to _END_ (about _TOTAL_ results)",
                "sInfoEmpty": "Page 0 to 0 (about 0 results)",
                "sInfoFiltered": ""
            },
            "bProcessing": true,
            "bServerSide": true,
            "initComplete": function (settings, json) {
                $.blockUI();
                var filterLabel = '#' + dataTableId + '_filter label'
                $(filterLabel).text('');
                $.unblockUI();
            },
            "drawCallback": function (settings) {
            },

            ajax: sAjaxSourceUrl,
            columns: [
                {
                    name: 'ViewDetail',
                    data: 'patientId',
                    title: "Patient Id",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<span>' + row.patientId + '</span>';
                    },
                    width: "10%"
                },
                {
                    name: 'ViewDetail',
                    data: 'patientId',
                    title: "Department Id",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<span>' + row.departmentId + '</span>';
                    },
                    width: "10%"
                },
                {
                    name: 'ViewDetail',
                    data: 'patientId',
                    title: "View Detail",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<button data-modaltitle="View Detail" data-url="' + baseUrl+'/AthenaPatientDataView/ViewPatientDetail?patientId=' + row.patientId + '" data-id="' + row.id + '" data-patientid="' + row.patientId + '" data-departmentid="' + row.departmentId + '" title="View Detail" data-bgheader="bg-info" class="btn btn-info btnAthenaPatientDataViewDetail">Show</button>';
                    },
                    width: "15%"
                },
                {
                    name: 'ViewEncounter',
                    data: 'patientId',
                    title: "View Encounter",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<button data-modaltitle="View Encounter" data-url="' + baseUrl +'/AthenaPatientDataView/ViewPatientEncounter?patientId=' + row.patientId + '" data-id="' + row.id + '" data-patientid="' + row.patientId + '" data-departmentid="' + row.departmentId + '" title="View Encounter" data-bgheader="bg-info" class="btn btn-info btnAthenaPatientDataViewDetail">Show</button>';
                    },
                    width: "15%"
                },
                {
                    name: 'ViewHistorical',
                    data: 'patientId',
                    title: "View Historical",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<button data-modaltitle="View Historical" data-url="' + baseUrl +'/AthenaPatientDataView/ViewPatientHistorical?patientId=' + row.patientId + '" data-id="' + row.id + '" data-patientid="' + row.patientId + '" data-departmentid="' + row.departmentId + '" title="View Historical" data-bgheader="bg-info" class="btn btn-info btnAthenaPatientDataViewDetail">Show</button>';
                    },
                    width: "15%"
                },
                {
                    name: 'ViewDocument',
                    data: 'patientId',
                    title: "View Document",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<button data-modaltitle="View Document" data-url="' + baseUrl +'/AthenaPatientDataView/ViewPatientDocument?patientId=' + row.patientId + '" data-id="' + row.id + '" data-patientid="' + row.patientId + '" data-departmentid="' + row.departmentId + '" title="View Document" data-bgheader="bg-info" class="btn btn-info btnAthenaPatientDataViewDetail">Show</button>';
                    },
                    width: "15%"
                },
                {
                    name: 'ViewFinancial',
                    data: 'patientId',
                    title: "View Financial",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {
                        return '<button data-modaltitle="View Financial" data-url="' + baseUrl +'/AthenaPatientDataView/ViewPatientFinancial?patientId=' + row.patientId + '" data-id="' + row.id + '" data-patientid="' + row.patientId + '" data-departmentid="' + row.departmentId + '" title="View Financial" data-bgheader="bg-info" class="btn btn-info btnAthenaPatientDataViewDetail">Show</button>';
                    },
                    width: "20%"
                }
            ]

        });

    };

    return {
        InitEvent: initEvent,
        LoadDataTables: loadDataTables
    };
}();