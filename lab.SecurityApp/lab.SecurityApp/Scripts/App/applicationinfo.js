
var ApplicationInfo = function () {

    var _jqDataTable;
    var _formId = "#frmApplicationInfo";

    var _formReset = function () {
        $(':input', _formId)
          .removeAttr('checked')
          .removeAttr('selected')
          .not(':button, :submit, :reset, :hidden, :radio, :checkbox')
          .val('');
    };

    var _actionHandler = function () {

        $(document).on("click", ".lnkApplicationInfoDelete", function () {
            var id = $(this).data("id");
            if (id != null && id != "") {
                bootbox.confirm(AppBootboxConfirm.DeleteText, function (isConfirm) {
                    if (isConfirm) {
                        App.sendAjaxRequest('/ApplicationInfo/DeleteAjax', { id: id }, true, function (result) {

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

        //$('#applicationInfoDataTable thead tr#dataTableFilterRow th').each(function () {
        //    var title = $('#applicationInfoDataTable thead th').eq($(this).index()).text();
        //    $(this).html('<input type="text" onclick="dataTableSearchStopPropagation(event);" placeholder="' + title + '" />');
        //});

        _jqDataTable = $('#applicationInfoDataTable').DataTable({
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
                { "sName": "Name" },
                { "sKey": "Key" },
                { "sValue": "Value" },
                {
                    "sName": "ApplicationInfoId",
                    "bSearchable": false,
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        //console.log(data);
                        //console.log(type);
                        //console.log(row);
                        return '<a class="lnkAppModal btn btn-info btn-sm" data-id=' +
                                    data + ' href="/ApplicationInfo/AddOrEditAjax/' +
                                    data + '">Details</a>  ' +
                                    '<a class="lnkAppModal btn btn-primary btn-sm" data-id=' +
                                    data + ' href="/ApplicationInfo/AddOrEditAjax/' +
                                    data + '">Edit</a>  ' +
                                    '<a class="lnkApplicationInfoDelete btn btn-danger btn-sm" data-id=' +
                                    data + ' href="javascript:;">Delete</a>';

                    }
                }
            ],
            "initComplete": function (settings, json) {
                var filterLabel = '#applicationInfoDataTable_filter label'
                //$(filterLabel).html().replace("Search:", '');
                //$(filterLabel).text().replace('"Search:"', '');
                //$('#applicationInfoDataTable_filter label input').addClass('form-control dataTable-search');
                $(filterLabel).text('');
            }
        });

        // Apply the filter
        //$("#applicationInfoDataTable thead input").on('keyup change', function () {
        //    _jqDataTable.column($(this).parent().index() + ':visible').search(this.value).draw();
        //});

        //$("#applicationInfoDataTable thead input").on('keyup', function () {
        //    _jqDataTable.column($(this).parent().index() + ':visible').search(this.value).draw();
        //});

        //$("#applicationInfoDataTableSearch").on('keyup', function () {
        //    _jqDataTable.search(this.value).draw();
        //});
    };

    var _reloadDataTable = function () {
        _jqDataTable.draw();
    };

    var _initialize = function () {
        _actionHandler();
    };

    return {
        init: _initialize,
        loadDataTable: _loadDataTable,
        reloadDataTable: _reloadDataTable
    };

}();