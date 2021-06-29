$(function () {
    $(document).on('click', '#saveCust', function (event) {
        AddSave();
    });
    $(document).on('click', '#editCust', function (event) {
        EditSave();
    });
});

//Add New Customer
function AddSave() {
    var reqRes = true;
    $('.req').each(function () {
        if ($(this).val() == '') {
            $(this).focus();
            $(this).css("borderColor", "red");
            reqRes = false;
        } else {
            $(this).css("borderColor", "#e8eaed");
        }
    });

    if (!validateEmail($('#Email').val())) {
        $(this).focus();
        $(this).css("borderColor", "red");
        reqRes = false;
        alert("Invalid Email");
    }
    if (reqRes === false)
        return false;

    var obj = {
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Phone: $('#Phone').val(),
        Email: $('#Email').val()
    };

    $.ajax({
        url: '/Customer/add'.toLowerCase(),
        data: {
            customers: obj

        },
        cache: false,
        type: "POST",
        dataType: "JSON",
        success: function (result) {
            if (result === "Y") {                
                window.location.href = "/Customer/index";
            }
            else {

                alert('Not Save');
            }
        }
    });
}

//Edit Customer
function EditSave() {
    var reqRes = true;
    $('.req').each(function () {
        if ($(this).val() == '') {
            $(this).focus();
            $(this).css("borderColor", "red");
            reqRes = false;
        } else {
            $(this).css("borderColor", "#e8eaed");
        }
    });

    if (!validateEmail($('#Email').val())) {
        $(this).focus();
        $(this).css("borderColor", "red");
        reqRes = false;
        alert("Invalid Email");
    }
    if (reqRes === false)
        return false;

    if (reqRes === false)
        return false;

    var obj = {
        CustomerID: $('#CustomerID').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Phone: $('#Phone').val(),
        Email: $('#Email').val()
    };

    $.ajax({
        url: '/Customer/edit'.toLowerCase(),
        data: {
            customers: obj
        },
        cache: false,
        type: "POST",
        dataType: "JSON",
        success: function (result) {
            if (result === "Y") {
                window.location.href = "/Customer/index";
            }
            else {

                alert('Not Save');
            }
        }
    });
}

//Delete Custoemer
function DeleteSave(id) {

    $.ajax({
        url: '/Customer/Delete'.toLowerCase(),
        data: {
            id: id
        },
        cache: false,
        type: "POST",
        dataType: "JSON",
        success: function (result) {
            if (result === "Y") {
                window.location.href = "/Customer/index";
            }
            else {

                alert('Not Save');
            }
        }
    });
}


//Validate Email Address
function validateEmail(email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test(email);
}