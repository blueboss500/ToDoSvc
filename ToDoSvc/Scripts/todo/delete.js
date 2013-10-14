$(function () {
    $("#itemList").on('click', "button.delete", function () {
        var id = $(this).data('comment-id');

        $.ajax({
            url: "api/todo/" + id,
            type: 'DELETE',
            cache: false,
            statusCode: {
                200: function (data) {
                    viewModel.todoItems.remove(
                        function (item) {
                            return item.ID === data.ID;
                        }
                    );
                }
            }
        });

        return false;
    });


});