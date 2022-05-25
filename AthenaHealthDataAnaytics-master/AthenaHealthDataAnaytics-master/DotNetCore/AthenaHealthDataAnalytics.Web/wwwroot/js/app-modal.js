//-----------------------------------------------------
//start AppModal

var AppModal = function () {

    //-----------------------------------------------------
    //start Common
    var commonModalBegin = function () {

        App.LoaderShow();

    }

    var commonModalComplete = function (dataTableId) {
        reloadDataTablesById(dataTableId);

        App.LoaderHide();
    }

    var commonModalSuccessForReplaceMode = function () {

        var appCommonModalMessageValue = $("#appCommonModalMessage").html().trim();

        var appCommonModalMessageValueList = appCommonModalMessageValue.split("_");

        var statusValue = appCommonModalMessageValueList[0];
        var errorType = appCommonModalMessageValueList[1];
        var errorMessage = appCommonModalMessageValueList[2];

        if (statusValue == "True") {

            //close bootstrap modal
            closeCommonModal();

            App.ToastrNotifier(errorMessage, errorType);

        }
        else {

            var errorClass = 'alert alert-' + errorType;

            $("#appCommonModalMessage").html("");
            $('#appCommonModalMessage').removeClass();
            $('#appCommonModalMessage').addClass(errorClass);
            $("#appCommonModalMessage").html(errorMessage);
            $("#appCommonModalMessage").show();

            //bootstrapper ui progress close
            CloseAppProgress();

        }
        //check status

    }

    var commonModalSuccess = function (response) {

        if (response != undefined || response != null) {

            if (response.success == true) {

                //close bootstrap modal
                closeCommonModal();

                App.ToastrNotifier(response.error, response.errortype);

            }
            else {

                var errorClass = 'alert alert-' + response.errortype;
                var errorMessage = response.error;

                $("#appCommonModalMessage").html("");
                $('#appCommonModalMessage').removeClass();
                $('#appCommonModalMessage').addClass(errorClass);
                $("#appCommonModalMessage").html(errorMessage);
                $("#appCommonModalMessage").show();

                //bootstrapper ui progress close
                CloseAppProgress();
            }

        }
        //check null
    }

    var commonModalFailureForReplaceMode = function () {

        var appCommonModalMessageValue = $("#appCommonModalMessage").html().trim();

        var appCommonModalMessageValueList = appCommonModalMessageValue.split("_");

        var statusValue = appCommonModalMessageValueList[0];
        var errorType = appCommonModalMessageValueList[1];
        var errorMessage = appCommonModalMessageValueList[2];

        if (statusValue == "True") {

            //close bootstrap modal
            closeCommonModal();

            App.ToastrNotifier(errorMessage, errorType);

        }
        else {

            var errorClass = 'alert alert-' + errorType;

            $("#appCommonModalMessage").html("");
            $('#appCommonModalMessage').removeClass();
            $('#appCommonModalMessage').addClass(errorClass);
            $("#appCommonModalMessage").html(errorMessage);
            $("#appCommonModalMessage").show();

            //bootstrapper ui progress close
            CloseAppProgress();

        }
        //check status

    }

    var commonModalFailure = function (response) {

        if (response != undefined || response != null) {

            if (response.success == true) {

                //close bootstrap modal
                closeCommonModal();

                App.ToastrNotifier(response.error, response.errortype);

            }
            else {

                var errorClass = 'alert alert-' + response.errortype;
                var errorMessage = response.error;

                $("#appCommonModalMessage").html("");
                $('#appCommonModalMessage').removeClass();
                $('#appCommonModalMessage').addClass(errorClass);
                $("#appCommonModalMessage").html(errorMessage);
                $("#appCommonModalMessage").show();

                //bootstrapper ui progress close
                CloseAppProgress();
            }

        }
        //check null
    }

    // private function
    var commonModalFormValidation = function (fromId) {

        //validation
        var $form = $("#" + fromId);
        // Unbind existing validation
        $form.unbind();
        $form.data("validator", null);
        // Check document for changes
        $.validator.unobtrusive.parse(document);
        // Re add validation with changes
        $form.validate($form.data("unobtrusiveValidation").options);

    }

    var loadAddOrEditCommonModal = function (viewUrl, modalTitle, modalForm) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            commonModalFormValidation(modalForm);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var loadDetailsCommonModal = function (viewUrl, modalTitle) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var loadCommonModal = function (viewUrl, modalTitle, modalForm) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            commonModalFormValidation(modalForm);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var loadCommonModalWithoutForm = function (viewUrl, modalTitle) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var titleCommonModal = function (title) {

        //title bootstrap modal
        $('#appCommonModal').find("#appCommonModalTitle").html('');
        $('#appCommonModal').find("#appCommonModalTitle").html(title);
    }

    var contentCommonModal = function (content) {

        //content bootstrap modal
        $('#appCommonModal').find("#appCommonModalBody").html('');
        $('#appCommonModal').find("#appCommonModalBody").html(content);

    }

    var openCommonModal = function () {

        //open bootstrap modal
        $('#appCommonModal').modal('show');

    }

    var closeCommonModal = function () {

        //open bootstrap modal
        $('#appCommonModal').modal('hide');

    }
    // private function

    //end Common
    //-----------------------------------------------------


    //-----------------------------------------------------
    //start Delete
    // private function
    var loadDeleteModal = function (viewUrl, modalTitle) {

        titleDeleteModal(modalTitle);

        //hidden field value
        $("#hdDeleteId").val("");
        $("#hdDeletePostUrl").val("");
        $("#hdDeleteId").val(viewUrl);
        $("#hdDeletePostUrl").val(viewUrl);

        //bootstrap modal open
        openDeleteModal();

    };

    var titleDeleteModal = function (title) {

        //title bootstrap modal
        $('#appDeleteModal').find("#appDeleteModalTitle").html('');
        $('#appDeleteModal').find("#appDeleteModalTitle").html(title);
    }

    var contentDeleteModal = function (content) {

        //content bootstrap modal
        $('#appDeleteModal').find("#appDeleteModalBody").html('');
        $('#appDeleteModal').find("#appDeleteModalBody").html(content);

    }
    // private function

    var openDeleteModal = function () {

        //open bootstrap modal
        $('#appDeleteModal').modal('show');

    }

    var closeDeleteModal = function () {

        //open bootstrap modal
        $('#appDeleteModal').modal('hide');

    }

    var yesDelete = function () {

        var hdDeleteIdValue = $("#hdDeleteId").val().trim();
        var hdDeletePostUrlValue = $("#hdDeletePostUrl").val().trim();

        App.SendAjaxRequest(hdDeletePostUrlValue, null, true, function (response) {

            console.log(response);

            //close bootstrap modal
            closeDeleteModal();

            if (response != undefined || response != null) {

                App.ToastrNotifier(response.error, response.errortype);

            }
            

        }, true);

        return null;

    }

    var noDelete = function () {

        $("#hdDeleteId").val("");
        $("#hdDeletePostUrl").val("");

        //close bootstrap modal
        closeDeleteModal();

    }

    //end Delete
    //-----------------------------------------------------


    //-----------------------------------------------------
    //start Message

    // private function
    //Common Message Modal with messageType, messageText
    var loadMessageModal = function (messageType, messageText) {

        var modalTitle = messageType;

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Common Message Modal with messageType, messageText for ajax success
    var loadMessageModalForAjaxSuccess = function (messageType, messageText) {

        var modalTitle = messageType;

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Info Message Modal
    var loadInfoMessageModalWithText = function (messageText) {

        var modalTitle = "Info";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Warn Message Modal
    var loadWarnMessageModalWithText = function (messageText) {

        var modalTitle = "Warn";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message open
        OpenAppMessage();

    };

    //Success Message Modal
    var loadSuccessMessageModalWithText = function (messageText) {

        var modalTitle = "Success";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Error Message Modal
    var loadErrorMessageModalWithText = function (messageText) {

        var modalTitle = "Error";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    var getMessageModalContent = function (messageType, messageText) {

        var content = "<div id='messageModalPage' class='messageModalPage'><div class='row'><div style='margin-bottom: 10px !important;' class='alert alert-" + messageType + "'>" + messageText + "</div> </div></div></div>";

        return content;

    }

    var titleMessageModal = function (title) {

        var upperTitle = title.toLowerCase().replace(/\b[a-z]/g, function (letter) {
            return letter.toUpperCase();
        });

        //title bootstrap modal
        $('#appMessageModal').find("#appMessageModalTitle").html('');
        $('#appMessageModal').find("#appMessageModalTitle").html(upperTitle);
    }

    var contentMessageModal = function (content) {

        //content bootstrap modal
        $('#appMessageModal').find("#appMessageModalBody").html('');
        $('#appMessageModal').find("#appMessageModalBody").html(content);

    }

    // private function

    var openMessageModal = function () {

        //open bootstrap modal
        $('#appMessageModal').modal('show');

    }

    var closeMessageModal = function () {

        //open bootstrap modal
        $('#appMessageModal').modal('hide');

    }

    var okMessage = function () {

        //close bootstrap modal
        closeMessageModal();

    }

    //end Message
    //-----------------------------------------------------


    //-----------------------------------------------------
    //start Reload Data Tables Funtion
    var reloadDataTables = function () {
        //Get Data Tables
        var dataTableObj = $('#dataTables').DataTable();
        dataTableObj.ajax.reload();
    }

    var reloadDataTablesById = function (dataTableId) {
        var _id = "#" + dataTableId;
        //Get Data Tables
        var dataTableObj = $(_id).DataTable();
        dataTableObj.ajax.reload();
    }
    //end Reload Data Tables Funtion
    //-----------------------------------------------------


    //-----------------------------------------------------
    //add Common
    var addCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');
        var modalForm = "appCommonModalForm";

        loadCommonModal(viewUrl, modalTitle, modalForm);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //detail Common
    var detailsCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');

        loadCommonModalWithoutForm(viewUrl, modalTitle);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //edit Common
    var editCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');
        var modalForm = "appCommonModalForm";

        loadCommonModal(viewUrl, modalTitle, modalForm);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //delete Common
    var deleteCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');

        loadDeleteModal(viewUrl, modalTitle);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //start Common, Delete, Message Funtion
    var createAppCommonModal = function () {
        if ($('#appCommonModal').length == 0) {
            $(document.body).append('<div class="modal fade text-left" id="appCommonModal" tabindex="-1" role="dialog" aria-labelledby="appCommonModalTitle" aria-hidden="true" > <div class="modal-dialog"> <div class="modal-content"> <div class="modal-header"> <label class="modal-title text-text-bold-600" id="appCommonModalTitle"></label> <button type="button" class="close" data-dismiss="modal" aria-label="Close"> <span aria-hidden="true">&times;</span> </button> </div> <div class="modal-body" id="appCommonModalBody"> </div> </div> </div></div>');
        } else {
            $('#appCommonModal').find("#appCommonModalTitle").html('');
            $('#appCommonModal').find("#appCommonModalBody").html('');
            //$('#appCommonModal').find("#appCommonModalFooter").html('');
        }
    }

    var createAppDeleteModal = function () {
        if ($('#appDeleteModal').length == 0) {
            $(document.body).append('<div class="modal fade text-left" id="appDeleteModal" tabindex="-1" role="dialog" aria-labelledby="appDeleteModalTitle" aria-hidden="true"> <div class="modal-dialog"> <div class="modal-content"> <div class="modal-header"> <label class="modal-title text-text-bold-600" id="appDeleteModalTitle"></label> <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div> <div class="modal-body" id="appDeleteModalBody"> <div id="deleteModalPage" class="deleteModalPage"> <div class="row"> <input type="hidden" name="hdDeleteId" id="hdDeleteId" value="" /> <input type="hidden" name="hdDeletePostUrl" id="hdDeletePostUrl" value="" /> </div> <div class="row"> <div class="col-md-12"> <div class="alert alert-warning"><strong>Do you want to delete this?</strong></div> </div> </div> </div> <div class="modal-footer" id="appDeleteModalFooter"> <div class="row"> <button type="button" class="btn btn-success" id="btnYesDelete" name="btnYesDelete" onclick="AppModal.YesDelete()" style="width: 60px;">Yes</button> <button type="button" class="btn btn-warning" id="btnNoDelete" name="btnNoDelete" onclick="AppModal.NoDelete()" style="width: 60px; margin-left: 5px;">No</button> </div> </div> </div> </div> </div> </div>');
        } else {
            $('#appDeleteModal').find("#appDeleteModalTitle").html('');
            $('#appDeleteModal').find("#appDeleteModalBody").html('');
        }
    }

    var createAppMessageModal = function () {
        if ($('#appMessageModal').length == 0) {
            $(document.body).append('<div class="modal fade text-left" id="appMessageModal" tabindex="-1" role="dialog" aria-labelledby="appMessageModalTitle" aria-hidden="true"> <div class="modal-dialog"> <div class="modal-content"> <div class="modal-header"> <label class="modal-title text-text-bold-600" id="appMessageModalTitle"></label> <button type="button" class="close" data-dismiss="modal" aria-label="Close"> <span aria-hidden="true">&times;</span> </button> </div> <div class="modal-body" id="appMessageModalBody"></div> <div class="modal-footer" id="appMessageModalFooter"> <div class="row"> <button type="button" class="btn btn-primary" data-dismiss="modal" style="width: 60px;">Ok</button> </div> </div> </div> </div> </div>');
        } else {
            $('#appMessageModal').find("#appMessageModalTitle").html('');
            $('#appMessageModal').find("#appMessageModalBody").html('');
            //$('#appMessageModal').find("#appMessageModalFooter").html('');
        }
    }

    //end Common, Delete, Message Funtion
    //-----------------------------------------------------


    var initializeAppModal = function () {

        createAppCommonModal();
        createAppDeleteModal();
        createAppMessageModal();

    };

    return {
        Init: initializeAppModal,

        AddCommon: addCommon,
        DetailsCommon: detailsCommon,
        EditCommon: editCommon,
        DeleteCommon: deleteCommon,

        ReloadDataTables: reloadDataTables,
        ReloadDataTablesById: reloadDataTablesById,

        CloseCommonModal: closeCommonModal,

        CommonModalBegin: commonModalBegin,
        CommonModalComplete: commonModalComplete,
        CommonModalSuccessForReplaceMode: commonModalSuccessForReplaceMode,
        CommonModalSuccess: commonModalSuccess,
        CommonModalFailureForReplaceMode: commonModalFailureForReplaceMode,
        CommonModalFailure: commonModalFailure,

        YesDelete: yesDelete,
        NoDelete: noDelete,

        OpenMessageModal: openMessageModal,
        CloseMessageModal: closeMessageModal,
        OkMessage: okMessage
    };
}();

//end AppModal
//-----------------------------------------------------


$(document).ready(function () {

    AppModal.Init();

});