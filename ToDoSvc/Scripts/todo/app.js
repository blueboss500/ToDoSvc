//declare namespace
var my = my || {};

//handler on formload
$(function () {


    my.todoVM = {

        todoItems: ko.observableArray([])
    };

    //get
    //button wire up
    $("#getToDo").click(function () {
        // clears out the existing items.
        my.todoVM.todoItems([]);

        $.get('api/todo', function (data) {
            // Update the Knockout model (and thus the UI) with the comments received back 
            // from the Web API call.
            my.todoVM.todoItems(data);
        });

    });

    //delete
    $("#itemList").on('click', "button.delete", function () {
        var id = $(this).data('comment-id');

        $.ajax({
            url: "api/todo/" + id,
            type: 'DELETE',
            cache: false,
            statusCode: {
                200: function (data) {
                    my.todoVM.todoItems.remove(
                        function (item) {
                            return item.ID === data.ID;
                        }
                    );
                }
            }
        });

        return false;
    });

    //post
    var form = $('#newToDoForm');
    form.submit(function () {
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
                    my.todoVM.todoItems.push(data);
                }
            }
        });

        $('#desc').val('');
        return false;
    });

    ko.applyBindings(my.todoVM);

});