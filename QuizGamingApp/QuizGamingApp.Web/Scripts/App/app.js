
var appMessage = {
    Error: 'We are facing some problem while processing the current request. Please try again later.',
    NotFound: 'Requested object not found.',
    SaveSuccess: 'Save successfully.',
    UpdateSuccess: 'Update successfully.',
    DeleteSuccess: 'Delete successfully.'
};

var App = function () {
    var appAreaName = {
        Admin: 'Admin'
    };
    var loaderShow = function () {

        $.blockUI();
    };

    var loaderHide = function () {

        $.unblockUI();
    };

    var sendAjaxRequest = function (url, data, isPost, callback, isAsync, isJson, target) {
        isJson = typeof (isJson) == 'undefined' ? true : isJson;
        var contentType = (isJson) ? "application/json" : "text/plain";
        var dataType = (isJson) ? "json" : "html";
        if (!isAsync) {
            App.loaderShow();
        }

        return $.ajax({
            type: isPost ? "POST" : "GET",
            url: url,
            data: isPost ? JSON.stringify(data) : data,
            contentType: contentType,
            dataType: dataType,
            beforeSend: function (xhr) {
                App.loaderShow();
            },
            success: function (successData) {
                if (!isAsync) {
                    App.loaderHide();
                }
                return typeof (callback) == 'function' ? callback(successData) : successData;
            },
            complete: function (xhr, status) {
                App.loaderHide();
            },
            error: function (exception) {
                return false;
            },
            async: isAsync
        });
    };

    var arrayToTree = function (arr, parent) {
        //arr.sort(function (a, b) { return parseInt(b.Level) - parseInt(a.Level) });
        var out = [];
        for (var i in arr) {
            if (arr[i].ParentId == parent) {
                var data = new Object();
                data.text = arr[i].Name;
                if (arr[i].Level == 3) {
                    data.id = arr[i].Id;
                } else {
                    var children = arrayToTree(arr, arr[i].Id);
                    if (children.length) {
                        data.children = children;
                    }
                }
                out.push(data);
            }
        }
        return out;
    };

    var loadDropdown = function (targetDropdown, dataSourceUrl, filterByValue) {

        App.sendAjaxRequest(dataSourceUrl, filterByValue, true, function (options) {
            var optionHtml = '';

            if ($.isArray(options) && (options.length > 0)) {

                $(options).each(function (index, option) {
                    optionHtml += '<option value="' + option.Value + '">' + option.Text + '</option>';
                });

            }

            $('#' + targetDropdown).html(optionHtml);

        }, true);

        $('#' + targetDropdown).val(0);

    };

    var appLayoutMessageErrorById = function (eId, message) {

        var appLayoutMessage = $(document.getElementById(eId));

        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-danger alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessageInfoById = function (eId, message) {

        var appLayoutMessage = $(document.getElementById(eId));

        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-info alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessageSuccessById = function (eId, message) {

        var appLayoutMessage = $(document.getElementById(eId));
        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-success alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessageById = function (eId, messagetype, message) {

        var appLayoutMessage = $(document.getElementById(eId));
        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-' + messagetype + ' alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessage = function (messagetype, message) {

        $("#AppLayoutMessage").html("");

        var messageClass = 'alert alert-' + messagetype + ' alert-dismissable';
        var messageHtml = message;

        var html = '';
        html += '<div class="' + messageClass + '" data-autodismiss="alert">';
        html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
        html += messageHtml;
        html += '</div>';
        
        $("#AppLayoutMessage").html(html);
        $("#AppLayoutMessage").show();

        bindAutoAlertDismissable();
    };

    var toastrNotifier = function (error, errortype) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",
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

        var errorText = error;
        var errorTypeUpperCase = toUpperCase(errortype);
        var errorTypeText = (errorTypeUpperCase + " !");
        toastr[errortype](errorText, errorTypeText);

    };

    var toastrNotifierError = function (error) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",
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

        toastr['error'](error, "Error !");
    };

    var toastrNotifierInfo = function (error) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",
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

        toastr['info'](error, "Info !");
    };

    var toastrNotifierSuccess = function (message) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",
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

        toastr['success'](message, "Success !");
    };

    var toUpperCase = function (strText) {

        var _strText;
        _strText = strText.toLowerCase().replace(/\b[a-z]/g, function (letter) {
            return letter.toUpperCase();
        });

        return _strText;
    };

    var displayLength = function () {
        var _displayLength = 10;
        return _displayLength;
    };

    var bindAutoAlertDismissable = function () {
        window.setTimeout(function () {

            var autoDismissElement = $("div[data-autodismiss='alert']");
            if (autoDismissElement.length > 0) {
                $("div[data-autodismiss='alert']").fadeTo(1000, 0).slideUp(1000, function () {
                    $(this).remove();
                });
            }

        }, 5000);
    };

    var setAutoAlertDismissable = function () {
        window.setInterval(function () {

            var autoDismissElement = $("div[data-autodismiss='alert']");
            if (autoDismissElement.length > 0) {
                $("div[data-autodismiss='alert']").fadeTo(1000, 0).slideUp(1000, function () {
                    $(this).remove();
                });
            }

        }, 5000);
    };

    var actionHandler = function () {
        setAutoAlertDismissable();
    };

    var initializeApp = function () {
        actionHandler();
    };

    var getAjax = function (getUrl, param) {

        $.getJSON(getUrl, param).done(function (data) {
            return data;
        }).fail(function (jqxhr, textStatus, error) {
            var msg = textStatus + ", " + error;
            toastr['error'](msg, "Error !");
        });

    };

    var getDataTableConfiguration = function (dataTableId, iDisplayLength, sAjaxSourceUrl,columns) {
        return {
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
                var keys = Object.keys(json.data[0]);
                tableColumns = keys;
                console.log(keys);
                $.blockUI();
                var filterLabel = '#' + dataTableId + '_filter label'
                $(filterLabel).text('');
                $.unblockUI();
            },
            "drawCallback": function (settings) {
                
            },
            ajax: sAjaxSourceUrl,
            columns: generateDataTableColumns(columns)
        };
    };

    var generateDataTableColumns = function (columns) {
        var tableColumns = [];
        if (columns.length > 0) {
            for (var i = 0; i < columns.length; i++) {
                var column = {
                    name: toCamelCase(columns[i]),
                    data: toCamelCase(columns[i]),
                    title: columns[i],
                    sortable: false,
                    searchable: false
                };
                tableColumns.push(column);
            }
        }
        var actionColumn = {
            title: "Actions",
            "mRender": function (data, type, row) {

                return '<a href="javascript:;" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" class="btn btn-success lnkAppModal">Details</a>'
                    + ' <a href="javascript:;" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" style="margin-left: 5px;" class="btn btn-warning lnkAppModal">Edit</a>'
                    + ' <a href="javascript:;" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" style="margin-left: 5px;" class="btn btn-danger lnkAppModal">Delete</a>';
                
            },
            width: "20%"
        };
        tableColumns.push(actionColumn);
        return tableColumns;
    }

    var toCamelCase = function (str) {
        return str.replace(/(?:^\w|[A-Z]|\b\w)/g, function (word, index) {
            return index == 0 ? word.toLowerCase() : word.toUpperCase();
        }).replace(/\s+/g, '');
    };


    //-----------------------------------------------------
    //start Ajax Get Methods

    var ajaxJsonGet = function (getUrl) {

        $.ajax({
            url: getUrl,
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonGetWithParam = function (getUrl, paramValue) {

        $.ajax({
            url: getUrl,
            type: 'GET',
            dataType: 'json',
            data: paramValue,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    //end Ajax Get Methods
    //-----------------------------------------------------

    //-----------------------------------------------------
    //start Ajax Post Methods

    var ajaxJsonPost = function (postUrl) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonPostForDelete = function (postUrl) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
                DataTableRefreshInIndexPage();
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonPostWithParam = function (postUrl, paramValue) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            data: paramValue,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonPostForDeleteWithParam = function (postUrl, paramValue) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            data: paramValue,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
                DataTableRefreshInIndexPage(); //Have to add index page
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    //end Ajax Post Methods
    //-----------------------------------------------------

    return {
        Init: initializeApp,
        LoaderShow: loaderShow,
        LoaderHide: loaderHide,

        SendAjaxRequest: sendAjaxRequest,
        LoadDropdown: loadDropdown,

        AppLayoutMessage: appLayoutMessage,
        AppLayoutMessageById: appLayoutMessageById,
        AppLayoutMessageInfoById: appLayoutMessageInfoById,
        AppLayoutMessageErrorById: appLayoutMessageErrorById,
        AppLayoutMessageSuccessById: appLayoutMessageSuccessById,

        ToastrNotifier: toastrNotifier,
        ToastrNotifierInfo: toastrNotifierInfo,
        ToastrNotifierError: toastrNotifierError,
        ToastrNotifierSuccess:toastrNotifierSuccess,

        DisplayLength: displayLength,

        GetAjax: getAjax,
        GetDataTableConfiguration: getDataTableConfiguration,

        AjaxJsonGet: ajaxJsonGet,
        AjaxJsonGetWithParam: ajaxJsonGetWithParam,
        AjaxJsonPost: ajaxJsonPost,
        AjaxJsonPostForDelete: ajaxJsonPostForDelete,
        AjaxJsonPostWithParam: ajaxJsonPostWithParam,
        AjaxJsonPostForDeleteWithParam: ajaxJsonPostForDeleteWithParam,
        ToCamelCase: toCamelCase,
        AppAreaName: appAreaName
    };
}();

$(document).ready(function () {

    App.Init();

});