$ClientProfile = {
    bindClientProfileEvents: function () {
        $(".btn-client-delete").on('click', function () {
            var selectedClientId = $(this).attr('data-client-id');
            $ClientProfile.deleteClientProfile(selectedClientId);
        });
    },
    deleteClientProfile: function (clientId) {
        var data = {
            Id: clientId
        };
        var answer = confirm("Are you sure to delete this Client?");
        if (answer) {
            App.LoaderShow();
            $.ajax({
                url: "/ClientProfile/Delete",
                type: 'POST',
                data: data,
                dataType: "html",
                beforeSend: function () {
                    //OpenAppProgressModal();
                },
                success: function (result) {
                    App.LoaderHide();
                    $("#clientListReplaceDiv").html(result);
                    App.ToastrNotifierSuccess("Client Removed Successfully!");
                },
                error: function (error) {
                    App.LoaderHide();
                    console.log(error);
                }

            });
        }
    }
}