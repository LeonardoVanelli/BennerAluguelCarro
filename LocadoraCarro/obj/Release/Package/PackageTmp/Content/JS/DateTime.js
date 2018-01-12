$(function () {


    $('#datetimepicker2').datetimepicker({
        format: 'HH:mm'
    });
    $('#datetimepicker3').datetimepicker({
        format: 'HH:mm'
    });
    $('#datetimepicker6').datetimepicker({
        format: 'DD/MM/YYYY',
        minDate: new Date($.now())
    });
    $('#datetimepicker7').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false//Important! See issue #1075
    });
    $("#datetimepicker6").on("dp.change", function (e) {
        $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
    });
    $("#datetimepicker7").on("dp.change", function (e) {
        $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
    });
});