$(document).ready(function(){

/*     $('.add-review').click(function(){
            $.ajax({
                type:'GET',
                dataType: 'html',
                url: '/Products/AddReview',
                success: function (result) {
                    $('#output2').html(result);
                }
            });
        });*/



    $('.new-review').submit(function(event) {
        event.preventDefault();
        $.ajax ({
            url: '/Products/NewReview',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var resultMessage = 'Your review has been added.<br>Rating: ' + result.rating + '<br>By: ' + result.author + '<br>Review: ' + result.contentBody;
                $('.hide-well').show();
                $('#output').html(resultMessage);
                $('.form-control').val('');
            }
        });
    });

});
