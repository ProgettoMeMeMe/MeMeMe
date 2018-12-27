$(document).ready(function () {
    $('#Famiglia').change(function () {
        famiglia();
    });
    famiglia();
})


function famiglia() {
    if($('#Famiglia').val()==0){
        $('#Parentela').val(0);
        $('#Parentela').attr('disabled', 'disabled');
    }else{
        $('#Parentela').removeAttr('disabled');
        $('#Parentela').val(1);
        $("#Parentela option[value=" + 0 + "]").attr('disabled', 'disabled');
    }
}


function enableDisable(ar, enable) {
    $.each(ar, function (index, ctr) {
        if (enable) {
            //alert('abilita');
            switch ($("#" + ctr).attr('type')) {
                case 'radio':
                    $("input[name=" + ctr + "]").each(function () {
                        $(this).removeAttr('disabled');
                    });
                    break;
                case 'checkbox':
                    $("input[name=" + ctr + "]").each(function () {
                        $(this).removeAttr('disabled');
                    });
                    break;
                case 'text':
                    $("#" + ctr).removeAttr('disabled');
                    break;
            }
        }
        else {
            //alert('disabilita');
            switch ($("#" + ctr).attr('type')) {
                case 'radio':
                    $("input[name=" + ctr + "]").each(function () {
                        $(this).attr('checked', false);
                        $(this).attr('disabled', true);
                    });
                    break;
                case 'checkbox':
                    $("input[name=" + ctr + "]").each(function () {
                        $(this).attr('checked', false);
                        $(this).attr('disabled', true);
                    });
                    break;
                case 'text':
                    $("#" + ctr).val('');
                    $("#" + ctr).attr('disabled', 'disabled');
                    break;
            }
        }
    });
}