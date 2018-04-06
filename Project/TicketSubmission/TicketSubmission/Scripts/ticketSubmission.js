$(document).ready(function () {
    var PriId = 0;
    var ticketPriority = null;
    var validFlag = false;
    $.ajax({
        type: "get",
        url: "http://localhost:58119/api/TicketPriority",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: {},
        success: function (result) {
            $.each(result, function (i) {
                $('#priority').append($('<option></option>').val(result[i].PriorityId).html(result[i].PriorityType));
                ticketPriority = result;
            });
        },
        failure: function () {
            alert("Error");
        }
    });

    Date.prototype.addHours = function (h) {
        this.setHours(this.getHours() + h);
        return this;
    }

    $("#Save").click(function () {
        if (validateForm()) {
            var ticket = new Object();
            ticket.FirstName = $('#fName').val();
            ticket.LastName = $('#lName').val();
            ticket.EmailAddress = $('#emAddress').val();
            ticket.PriorityId = PriId;
            ticket.TicketSubject = $('#subject').val();
            ticket.TicketDescription = $('#description').val();
            $.ajax({
                url: 'http://localhost:58119/api/TicketJournal/PostTicket',
                type: 'POST',
                dataType: 'json',
                data: ticket,
                success: function (data, textStatus, xhr) {
                    confirm(data);
                    $('#CustomerForm')[0].reset();
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log('Error in Operation');
                }
            });
        }        
    });

    $("#priority").on('change', function () {
        PriId = $(this).find('option:selected').index();
    });

    $("#Reset").click(function () {
        $('#CustomerForm')[0].reset();
        $('#fNameValidationMessage').hide();
        $('#lNameValidationMessage').hide();
        $('#emailAddressValidationMessage').hide();
        $('#subjectValidationMessage').hide();
        $('#descriptionValidationMessage').hide();
    });

    function validateForm() {
        validFlag = true;
        if ($('#fName').val() == "") {
            $('#fNameValidationMessage').show();
            validFlag = false;
        }
        else {
            $('#fNameValidationMessage').hide();
        }
        if ($('#lName').val() == "") {
            $('#lNameValidationMessage').show();
            validFlag = false;
        } else {
            $('#lNameValidationMessage').hide();
        }
        if ($('#emAddress').val() == "") {
            $('#emailAddressValidationMessage').show();
            validFlag = false;
        }
        else {
            var mailformat = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            if (!(mailformat.test($('#emAddress').val()))) {
                $('#emailAddressValidationMessage').show();
                validFlag = false;
            } else {
                $('#emailAddressValidationMessage').hide();
            }            
        }
        if ($('#subject').val() == "") {
            $('#subjectValidationMessage').show();
            validFlag = false;
        } else {
            $('#subjectValidationMessage').hide();
        }
        if ($('#description').val() == "") {
            $('#descriptionValidationMessage').show();
            validFlag = false;
        } else {
            $('#descriptionValidationMessage').hide();
        }
        if (validFlag) {
            return true;
        }
        else {
            return false;
        }
    }

});