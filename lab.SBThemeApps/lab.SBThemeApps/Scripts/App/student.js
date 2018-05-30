
var Student = function () {

    var _jqDataTable;
    var _formId = "#frmStudent";

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
                    StudentName: {
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
                    if ($('#btnStudentSave').length > 0) {
                        var url = "/Student/SaveAjax";
                        $.post(url, $(form).serializeArray(),
                            function (res) {
                                if (parseInt(res.MessageType) == parseInt(AppMessageType.Success)) {
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
    };

    var _actionHandler = function () {

        $('body').undelegate('#btnStudentSave', 'click').on('click', '#btnStudentSave', function (e) {
            var formId = $(this).parents('form:first');
            var url = formId.attr('action');
            // start check form valid
            if (!formId.valid || formId.valid()) {

                $.post(url, formId.serializeArray(), function (res) {

                    if (parseInt(res.MessageType) == parseInt(AppMessageType.Success)) {
                        _reloadDataTable();
                        App.modalHide();
                    }
                    App.toastrNotifier(res.CurrentMessage, res.MessageType);

                }).fail(function (xhr, strError) {
                    App.ajaxRequestErrorHandler(xhr, strError);
                });

            }// end check form valid

            return false;
        });

        $(document).on("click", ".lnkStudentDelete", function () {
            var id = $(this).data("id");
            if (id != null && id != "") {
                bootbox.confirm(AppBootboxConfirm.DeleteText, function (isConfirm) {
                    if (isConfirm) {
                        App.sendAjaxRequest('/Student/DeleteAjax', { id: id }, true, function (result) {

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

        //$('#studentDataTable thead tr#dataTableFilterRow th').each(function () {
        //    var title = $('#studentDataTable thead th').eq($(this).index()).text();
        //    $(this).html('<input type="text" onclick="dataTableSearchStopPropagation(event);" placeholder="' + title + '" />');
        //});

        _jqDataTable = $('#studentDataTable').DataTable({
            "bJQueryUI": true,
            "bAutoWidth": true,
            "sPaginationType": "full_numbers",
            "bPaginate": true,
            "iDisplayLength": parseInt(AppDefaultSetting.DataTableDisplayLength),
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
                { "sStudentName": "StudentName" },
                {
                    "sStudentId": "StudentId",
                    "bSearchable": false,
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        //console.log(data);
                        //console.log(type);
                        //console.log(row);
                        return '<a class="lnkAppModal btn btn-sm btn-info"  data-modal-icon="fa fa-tasks" data-modal-title="Student" data-id=' +
                                    data + ' href="/Student/AddOrEditAjax/' +
                                    data + '">Details</a>  ' +
                                    '<a class="lnkAppModal btn btn-sm btn-primary" data-modal-icon="fa fa-tasks" data-modal-title="Student" data-id=' +
                                    data + ' href="/Student/AddOrEditAjax/' +
                                    data + '">Edit</a>  ' +
                                    '<a class="lnkStudentDelete btn btn-danger btn-sm" data-id=' +
                                    data + ' href="javascript:;">Delete</a>';

                    }
                }
            ],
            "initComplete": function (settings, json) {
                var filterLabel = '#studentDataTable_filter label'
                //$(filterLabel).html().replace("Search:", '');
                //$(filterLabel).text().replace('"Search:"', '');
                //$('#studentDataTable_filter label input').addClass('form-control dataTable-search');
                $(filterLabel).text('');
            }
        });

        // Apply the filter
        //$("#studentDataTable thead input").on('keyup change', function () {
        //    _jqDataTable.column($(this).parent().index() + ':visible').search(this.value).draw();
        //});

        //$("#studentDataTable thead input").on('keyup', function () {
        //    _jqDataTable.column($(this).parent().index() + ':visible').search(this.value).draw();
        //});

        //$("#studentDataTableSearch").on('keyup', function () {
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