$(function () {
    initValidation();
});

function initValidation() {
    $("#Insurers_Form").validate({
        rules: {
            "Name": {
                required: true,
                remote: {
                    url: apppath + "/Insurers/CheckName",
                    type: "POST",
                    data: {
                        Name: function () {
                            return $("#Name").val();
                        },
                        Id: function () {
                            var id = $("#Id").val();
                            return ((id || '') == '') ? 0 : id;
                        },
                        __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val()

                    },
                    async: true,
                    cache: false,
                    dataType: 'json'
                }
            },
            "Desc": {
                required: true
            },
            "IsActive": {
                required: true
            },
            InternalCode: {
                required: true,
                remote: {
                    url: apppath + "/Insurers/CheckInternalCode",
                    type: "POST",
                    data: {
                        InternalCode: function () {
                            return $("#InternalCode").val();
                        },
                        Id: function () {
                            var id = $("#Id").val();
                            return ((id || '') == '') ? 0 : id;
                        },
                        __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val()

                    },
                    async: true,
                    cache: false,
                    dataType: 'json'
                }
            }

        },
        messages: {
            "Name": {
                required: "Please enter name.",
                remote: "Name already used."
            },
            "Desc": {
                required: "Please enter description."
            },           
            "IsActive": {
                required: "Please select status."
            },
            InternalCode: {
                required: "Please enter internal code.",
                remote: "Internal code already used."
            }
        },
        submitHandler: function (form) {
            // do other things for a valid form
            form.submit();
        }
    });
}