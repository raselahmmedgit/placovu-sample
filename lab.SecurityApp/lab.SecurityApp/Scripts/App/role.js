
var Role = function () {

    var _jqDataTable;
    var _formId = "#frmRole";
    var _formDivId = "#divRoleForm";

    var _validateForm = function () {
        if ($().validate) {
            var form = $(_formId);
            var error = $('.alert-danger', form);
            var success = $('.alert-success', form);

            form.validate({
                doNotHideMessage: true,
                errorElement: 'span',
                errorClass: 'help-block help-block-error',
                focusInvalid: false,

                rules: {
                    RoleName: {
                        required: true,
                        maxlength: 150
                    },
                },
                errorPlacement: function (error, element) {
                    var errorContainer = element.parents('div.form-group div.col-md-9');
                    errorContainer.append(error);
                },
                messages: {
                    RoleName: {
                        required: "Name is required."
                    },
                },
                invalidHandler: function (event, validator) {
                    success.hide();
                    error.show();
                },
                highlight: function (element) {
                    $(element)
                        .closest('.form-group').addClass('has-error');
                },
                unhighlight: function (element) {
                    $(element)
                        .closest('.form-group').removeClass('has-error');
                },
                success: function (label) {
                    label.closest('.form-group').removeClass('has-error');
                },
                submitHandler: function (form) {
                    if ($('#btnRoleSave').length > 0) {
                        var url = "/Role/SaveAjax";
                        $.post(url, $(form).serializeArray(),
                            function (res) {
                                if (parseInt(res.MessageType) == parseInt(appMessageType.Success)) {
                                    _formReset();
                                    _reloadDataTable();
                                }
                                App.toastrNotifier(res.CurrentMessage, res.MessageType);
                            });
                    } else {
                        form.submit(function (e) { });
                    }

                }
            });
        }
    };

    var _formReset = function () {
        $(':input', _formId)
          .removeAttr('checked')
          .removeAttr('selected')
          .not(':button, :submit, :reset, :hidden, :radio, :checkbox')
          .val('');

        $("#btnRoleSave").show();
    };

    var _formHide = function () {
        $(_formDivId).hide();
    };

    var _formShow = function () {
        $(_formDivId).show();
    };

    var _actionHandler = function () {

        $(document).on("click", "#btnRoleAdd", function () {
            _formReset();
            _formShow();
        });

        $(document).on("click", "#btnRoleCancel", function () {
            _formReset();
            _formHide();
        });

        $(document).on("click", ".lnkRoleEdit", function () {
            _formReset();
            _formShow();
            var id = $(this).data("id");
            if (id != null && id != "") {
                App.sendAjaxRequest('/Role/GetByIdAjax', { id: id }, true, function (result) {
                    if (result != null) {
                        $("#RoleId").val(result.RoleId);
                        $("#RoleName").val(result.RoleName);
                    }
                }, true, true, null);
            } else {
                _formHide();
            }
        });

        $(document).on("click", ".lnkRoleDetail", function () {
            _formReset();
            _formShow();
            var id = $(this).data("id");
            if (id != null && id != "") {
                App.sendAjaxRequest('/Role/GetByIdAjax', { id: id }, true, function (result) {
                    if (result != null) {
                        $("#btnRoleSave").hide();
                        $("#RoleId").val(result.RoleId);
                        $("#RoleName").val(result.RoleName);
                    }
                }, true, true, null);
            } else {
                _formHide();
            }
        });

        $(document).on("click", ".lnkRoleDelete", function () {
            var id = $(this).data("id");
            if (id != null && id != "") {
                bootbox.confirm(appBootboxConfirm.DeleteText, function (isConfirm) {
                    if (isConfirm) {
                        App.sendAjaxRequest('/Role/DeleteAjax', { id: id }, true, function (result) {

                            if (result.IsSuccess) {
                                App.toastrNotifier(result.SuccessMessage, true);
                            } else {
                                App.toastrNotifier(result.ErrorMessage, false);
                            }

                        }, true, true, null);
                    }
                });
            }
        });

    };

    var _loadDataTable = function (sAjaxSource) {

        //$('#roleDataTable thead tr#dataTableFilterRow th').each(function () {
        //    var title = $('#roleDataTable thead th').eq($(this).index()).text();
        //    $(this).html('<input type="text" onclick="dataTableSearchStopPropagation(event);" placeholder="' + title + '" />');
        //});

        _jqDataTable = $('#roleDataTable').DataTable({
            "bJQueryUI": true,
            "bAutoWidth": true,
            "sPaginationType": "full_numbers",
            "bPaginate": true,
            "iDisplayLength": parseInt(appDefaultSetting.DataTableDisplayLength),
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
                { "sRoleName": "RoleName" }
                ,{
                    "sRoleName": "RoleId",
                    "bSearchable": false,
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        //console.log(data);
                        //console.log(type);
                        //console.log(row);
                        return '<a class="lnkRoleDetail btn btn-info btn-sm" data-id=' +
                                    data + ' href="javascript:;">Details</a>  ' +
                                    '<a class="lnkRoleEdit btn btn-primary btn-sm" data-id=' +
                                    data + ' href="javascript:;">Edit</a>  ' +
                                    '<a class="lnkRoleDelete btn btn-danger btn-sm" data-id=' +
                                    data + ' href="javascript:;">Delete</a>';

                    }
                }
            ],
            "initComplete": function (settings, json) {
                var filterLabel = '#roleDataTable_filter label'
                //$(filterLabel).html().replace("Search:", '');
                //$(filterLabel).text().replace('"Search:"', '');
                //$('#roleDataTable_filter label input').addClass('form-control dataTable-search');
                $(filterLabel).text('');
            }
        });

        // Apply the filter
        //$("#roleDataTable thead input").on('keyup change', function () {
        //    _jqDataTable.column($(this).parent().index() + ':visible').search(this.value).draw();
        //});

        //$("#roleDataTable thead input").on('keyup', function () {
        //    _jqDataTable.column($(this).parent().index() + ':visible').search(this.value).draw();
        //});

        //$("#roleDataTableSearch").on('keyup', function () {
        //    _jqDataTable.search(this.value).draw();
        //});
    };

    var _reloadDataTable = function () {
        _jqDataTable.draw();
    };
    
    var _initialize = function () {
        _validateForm();
        _actionHandler();
    };

    return {
        init: _initialize,
        loadDataTable: _loadDataTable,
        reloadDataTable: _reloadDataTable
    };

}();