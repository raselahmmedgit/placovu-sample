

var App = function () {

    //-----------------------------------------------------
    //start Ajax Get Methods

    var _ajaxJsonGet = function (getUrl) {

        $.ajax({
            url: getUrl,
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
            },
            success: function (result) {
                return result;
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                _toastrNotifier(messageText, false);
            }

        });

    }

    var _ajaxJsonGetWithParam = function (getUrl, paramValue) {

        $.ajax({
            url: getUrl,
            type: 'GET',
            dataType: 'json',
            data: JSON.stringify(paramValue),
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
            },
            success: function (result) {
                _toastrNotifierInfo(result);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                _toastrNotifier(messageText, false);
            }

        });

    }

    //end Ajax Get Methods
    //-----------------------------------------------------

    //-----------------------------------------------------
    //start Ajax Post Methods

    var _ajaxJsonPost = function (postUrl) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
            },
            success: function (result) {
                _toastrNotifierInfo(result);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                _toastrNotifier(messageText, false);
            }

        });

    }

    var _ajaxJsonPostWithParam = function (postUrl, paramValue) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(paramValue),
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
            },
            success: function (result) {
                _toastrNotifierInfo(result);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                _toastrNotifier(messageText, false);
            }

        });

    }

    //end Ajax Post Methods
    //-----------------------------------------------------

    var _currentDateTimeToString = function (currentdate) {
        var datetime = (currentdate.getMonth() + 1) + "/"
                    + currentdate.getDate() + "/"
                    + currentdate.getFullYear() + " at "
                    + currentdate.getHours() + ":"
                    + currentdate.getMinutes() + ":"
                    + currentdate.getSeconds();
        return datetime;
    };

    var _currentDateTime = function (currentdate) {
        var datetime = (currentdate.getMonth() + 1) + "/"
                    + currentdate.getDate() + "/"
                    + currentdate.getFullYear() + " "
                    + currentdate.getHours() + ":"
                    + currentdate.getMinutes() + ":"
                    + currentdate.getSeconds();
        return datetime;
    };

    var _currentDate = function (currentdate) {
        var datetime = (currentdate.getMonth() + 1) + "/"
                    + currentdate.getDate() + "/"
                    + currentdate.getFullYear();
        return datetime;
    };

    var _currentTime = function (currentdate) {
        var datetime = currentdate.getHours() + ":"
                    + currentdate.getMinutes() + ":"
                    + currentdate.getSeconds();
        return datetime;
    };

    var jqDataTable;

    var _loadDataTable = function (iDisplayLength, sAjaxSource) {

        jqDataTable = $('#jqDataTable').DataTable({
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
                "sInfo": "Showing _START_ to _END_ of _TOTAL_ records",
                "sInfoEmpty": "Showing 0 to 0 of 0 records",
                "sInfoFiltered": "(filtered from _MAX_ total records)"
            },
            "bProcessing": true,
            "bServerSide": true,
            "sAjaxSource": sAjaxSource,
            "sServerMethod": "GET",
            "aoColumns": [
                //{ "sName": "WorkFlowCategoryName" },
                //{ "sName": "ProcedureName" },
                { "sName": "WorkFlowName" },
                { "sName": "StartDateTime" },
                { "sName": "EndDateTime" },
                { "sName": "IsActive" },
                {
                    "sName": "WorkFlowProcedureId",
                    "bSearchable": false,
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        
                        if (row[9] == 'True') {
                            return '<a disabled class="lnkWorkFlowAction btn btn-primary" data-workflowpatientprofileid="' + row[10] + '" data-workflowid="' + row[4] + '" data-procedureid="' + row[5] + '" data-workflowprocedureid="' + row[6] + '" data-workflowname="' + row[0] + '" data-startdatetime="' + row[1] + '" data-enddatetime="' + row[2] + '" data-hasstart="' + row[8] + '" data-hasend="' + row[9] + '" href="/Home/PostWorkFlowAjax")">' + row[7] + '</a>';
                        }
                        else {
                            return '<a class="lnkWorkFlowAction btn btn-primary" data-workflowpatientprofileid="' + row[10] + '" data-workflowid="' + row[4] + '" data-procedureid="' + row[5] + '" data-workflowprocedureid="' + row[6] + '" data-workflowname="' + row[0] + '" data-startdatetime="' + row[1] + '" data-enddatetime="' + row[2] + '" data-hasstart="' + row[8] + '" data-hasend="' + row[9] + '" href="/Home/PostWorkFlowAjax")">' + row[7] + '</a>';
                        }


                    }
                }
            ]
        });

    };

    var _actionHandler = function () {

        $(document).on("click", ".lnkWorkFlowAction", function () {
            var href = $(this).attr('href');

            //var workflowname = $(this).data("workflowname");
            //$('#WorkFlowName').html(workflowname);
            //$('#WorkFlowTimer').html(currentTime);
            //$('#divWorkFlowName').show();
            //$('#divWorkFlowTimer').show();

            var currentdatatime = new Date();
            var currentTime = _currentTime(currentdatatime);

            var workflowpatientprofileid = $(this).data("workflowpatientprofileid");
            var workflowprocedureid = $(this).data("workflowprocedureid");
            var workflowid = $(this).data("workflowid");
            var procedureid = $(this).data("procedureid");
            var hasstart = $(this).data("hasstart");
            var hasend = $(this).data("hasend");

            var model = {};
            model.WorkFlowPatientProfileId = workflowpatientprofileid;
            model.WorkFlowProcedureId = workflowprocedureid;
            model.WorkFlowId = workflowid;
            model.ProcedureId = procedureid;
            model.HasStart = hasstart;
            model.HasEnd = hasend;
            model.CurrentDataTime = currentdatatime;

            //_ajaxJsonPost(href);
            _ajaxJsonPostWithParam(href, { model: model });

            $(this).text('');
            $(this).text('End');

            jqDataTable.ajax.reload();
            //jqDataTable.search().draw();
            //jqDataTable.draw();
            //jqDataTable.reload();
            //$('#jqDataTable').data.reload();

            location.reload();

            return false;
        });
        
    };

    var _toastrNotifier = function (msg, isSuccess) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        if (isSuccess) {
            //toastr['success'](msg, "Success !");
            toastr['success'](msg);
        } else {
            //toastr['error'](msg, "Error !");
            toastr['error'](msg);
        }
    };

    var _toastrNotifierInfo = function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        //toastr['info'](msg, "Info !");
        toastr["info"](msg);
    };

    var _toastrNotifierSuccess = function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        //toastr['success'](msg, "Success !");
        toastr["success"](msg);
    };

    var _toastrNotifierError = function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        //toastr['error'](msg, "Error !");
        toastr["error"](msg);
    };

    var _toastrNotifierWarning = function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        //toastr['warning'](msg, "Warning !");
        toastr["warning"](msg);
    };


    var _initializeForm = function () {
    };

    var initializeApp = function () {
        _initializeForm();
        _actionHandler();
    };

    return {
        init: initializeApp,
        ajaxJsonGet: _ajaxJsonGet,
        ajaxJsonGetWithParam: _ajaxJsonGetWithParam,
        ajaxJsonPost: _ajaxJsonPost,
        ajaxJsonPostWithParam: _ajaxJsonPostWithParam,
        toastrNotifier: _toastrNotifier,
        toastrNotifierInfo: _toastrNotifierInfo,
        toastrNotifierSuccess: _toastrNotifierSuccess,
        toastrNotifierWarning: _toastrNotifierWarning,
        toastrNotifierError: _toastrNotifierError,
        loadDataTable: _loadDataTable
    };
}();