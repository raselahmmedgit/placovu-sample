var AppDefaultSetting = function () {
    return {
        DataTableDisplayLength: 5
    };
}();

var AppMessageType = function () {
    return {
        None: 1,
        Success: 2,
        Error: 3,
        Information: 4,
        Warning: 5,
        LoginRequired: 6
    };
}();

var AppMessage = function () {
    return {
        ErrorMessage: "Oops! Exception in application.",
        NotFoundMessage: "Requested object could not found.",
        SaveSuccessMessage: "Data has been saved successfully.",
        SaveInformationMessage: "Data has not been saved.",
        UpdateSuccessMessage: "Data has been updated successfully.",
        UpdateInformationMessage: "Data has not been updated.",
        DeleteSuccessMessage: "Data has been deleted successfully.",
        DeleteInformationMessage: "Data has not been deleted.",

        ErrorCommon: "Oops! Exception in application.",
        Error401: "Oops! Exception in application.",
        Error403: "Oops! Exception in application.",
        Error404: "Oops! Exception in application.",
        Error405: "Oops! Exception in application.",
        Error406: "Oops! Exception in application.",
        Error408: "Oops! Exception in application.",
        Error412: "Oops! Exception in application.",
        Error500: "Oops! Exception in application.",
        Error501: "Oops! Exception in application.",
        Error502: "Oops! Exception in application."
    };
}();

var AppBootboxConfirm = function () {
    return {
        SelectText: "Do you want to select this item?",
        SelectAllText: "Do you want to select all item?",
        DeleteText: "Do you want to delete this ?",
        RemoveText: "Do you want to remove this ?" 
    };
}();

var App = function () {

    var preloaderShow = function () {
        $.blockUI();
    };

    var preloaderHide = function () {
        $.unblockUI();
    };

    var modalOnBegin = function () {
        $.blockUI();
    };

    var modalOnSuccess = function () {
        $.unblockUI();
    };

    var modalOnComplete = function () {
        $.unblockUI();
    };

    var modalHandler = function () {
        $('body').undelegate('.lnkAppModal', 'click').on('click', '.lnkAppModal', function (event) {

            event.preventDefault();
            var url = $(this).attr('href');
            var title = $(this).data('modal-title');
            var icon = $(this).data('modal-icon');
            var modalSize = '';
            var modalDialogSize = '';
            var isPost = false;
            if ($(this).data('ispost') == true) {
                isPost = true;
            }
            if ($(this).hasClass('modal-small')) {
                modalSize = 'bs-modal-sm';
                modalDialogSize = 'modal-sm';
            } else if ($(this).hasClass('modal-basic')) {
                modalSize = '';
                modalDialogSize = '';
            } else if ($(this).hasClass('modal-large')) {
                modalSize = 'bs-modal-lg';
                modalDialogSize = 'modal-lg';
            } else if ($(this).hasClass('modal-full')) {
                modalSize = '';
                modalDialogSize = 'modal-full';
            }

            $('body').find('#appModal').each(function () {
                var modal = $(this);
                (modalSize.length > 0) ? modal.addClass(modalSize) : '';
                (modalDialogSize.length > 0) ? modal.find('#appModalDialog').addClass(modalDialogSize) : '';
                modal.find('#appModalDialogTitle').html('<i class="' + icon + '"></i> ' + title);
                App.sendAjaxRequest(url, {}, isPost, function (result) {
                    modal.find('#appModalDialogContainer').html(result);
                    modal.modal('show');
                }, true, false);
            });
        });

    };

    var deleteHandler = function () {

        $('body').undelegate('.lnkAppDelete', 'click').on('click', '.lnkAppDelete', function (event) {

            event.preventDefault();
            var url = $(this).attr('href');
            var gridId = $(this).data('gridid');

            App.sendAjaxRequest(url, {}, true, function (result) {
                console.log(result);
            }, true, false);

        });

        return false;
    };

    var modalShow = function () {

        $('body').find('#appModal').each(function () {
            var modal = $(this);
            modal.modal('show');
        });
    };

    var modalHide = function () {

        $('body').find('#appModal').each(function () {
            var modal = $(this);
            modal.modal('hide');
        });
    };

    var sendAjaxRequest = function (url, data, isPost, callback, isAsync, isJson, target) {
        isJson = typeof (isJson) == 'undefined' ? true : isJson;
        var contentType = (isJson) ? "application/json" : "text/plain";
        var dataType = (isJson) ? "json" : "html";
        if (!isAsync) {
            App.preloaderShow();
        }

        return $.ajax({
            type: isPost ? "POST" : "GET",
            url: url,
            data: isPost ? JSON.stringify(data) : data,
            contentType: contentType,
            dataType: dataType,
            beforeSend: function (xhr) {
                App.preloaderShow();
            },
            success: function (successData) {
                if (!isAsync) {
                    App.preloaderHide();
                }
                return typeof (callback) == 'function' ? callback(successData) : successData;
            },
            complete: function (xhr, status) {
                App.preloaderHide();
            },
            error: function (xhr, strError) {
                sendAjaxRequestError(xhr, strError);
                return false;
            },
            async: isAsync
        });
    };

    var sendAjaxRequestError = function (xhr, strError) {
        //var respText = xhr.responseText;
        //var messageText = respText;
        var statusCode = xhr.status;
        switch (statusCode) {
            case 401:
                sendAjaxRequestErrorBootbox(AppMessage.Error401);
                break;

            case 403:
                sendAjaxRequestErrorBootbox(AppMessage.Error403);
                break;

            case 404:
                sendAjaxRequestErrorBootbox(AppMessage.Error404);
                break;

            case 405:
                sendAjaxRequestErrorBootbox(AppMessage.Error405);
                break;

            case 406:
                sendAjaxRequestErrorBootbox(AppMessage.Error406);
                break;

            case 408:
                sendAjaxRequestErrorBootbox(AppMessage.Error408);
                break;

            case 412:
                sendAjaxRequestErrorBootbox(AppMessage.Error412);
                break;

            case 500:
                sendAjaxRequestErrorBootbox(AppMessage.Error500);
                break;

            case 501:
                sendAjaxRequestErrorBootbox(AppMessage.Error501);
                break;

            case 502:
                sendAjaxRequestErrorBootbox(AppMessage.Error502);
                break;

            default:
                sendAjaxRequestErrorBootbox(AppMessage.ErrorCommon);
                break;
        }
    };

    var sendAjaxRequestErrorBootbox = function (msg){
        bootbox.alert(msg);
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

    var toastrNotifier = function (msg, type) {
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
        }
        if (parseInt(type) == parseInt(AppMessageType.Success)) {
            toastr['success'](msg, "Success !");
        }
        if (parseInt(type) == parseInt(AppMessageType.Error)) {
            toastr['error'](msg, "Error !");
        }
        if (parseInt(type) == parseInt(AppMessageType.Information)) {
            toastr['info'](msg, "Information !");
        }
        if (parseInt(type) == parseInt(AppMessageType.Warning)) {
            toastr['warning'](msg, "Warning !");
        }
        else {
            toastr['info'](msg, "Information !");
        }
    };

    var toastrNotifierInfo = function (msg) {
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

        toastr['info'](msg, "Information !");
    };

    var displayLength = function () {
        var _displayLength = AppDefaultSetting.DataTableDisplayLength;
        return _displayLength;
    };

    var actionHandler = function () {

        modalHandler();
        deleteHandler();

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

    return {
        init: initializeApp,
        modalShow: modalShow,
        modalHide: modalHide,
        modalOnBegin: modalOnBegin,
        modalOnSuccess: modalOnSuccess,
        modalOnComplete: modalOnComplete,
        preloaderShow: preloaderShow,
        preloaderHide: preloaderHide,
        sendAjaxRequest: sendAjaxRequest,
        loadDropdown: loadDropdown,
        toastrNotifier: toastrNotifier,
        toastrNotifierInfo: toastrNotifierInfo,
        displayLength: displayLength,
        getAjax: getAjax
    };
}();
