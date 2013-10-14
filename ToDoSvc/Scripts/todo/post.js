$(function() {
    var form = $('#newToDoForm');
    form.submit(function() {
        var form = $(this);
        var todoItem = { ID: 0, Desc: $('#desc').val() };
        var json = JSON.stringify(todoItem);


        $.ajax({
            url: 'api/todo',
            cache: false,
            type: 'POST',
            data: json,
            contentType: 'application/json; charset=utf-8',
            statusCode: {
                201 /*Created*/: function (data) {
                    viewModel.todoItems.push(data);
                }
            }
        });

        $('#desc').val('');
        
        
        return false;

    });

});