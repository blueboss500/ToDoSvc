$(function () {
    //button wire up
    $("#getToDo").click(function () {
        // clears out the existing items.
        viewModel.todoItems([]);

        $.get('api/todo', function (data) {
            // Update the Knockout model (and thus the UI) with the comments received back 
            // from the Web API call.
            viewModel.todoItems(data);
        });

    });
});