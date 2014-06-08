$(function () {
    app.initialize();

    // Activate Knockout
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);
    
    var _prepareSite = function()
    {

        var _call = function (method, url, data, successCallback, completeCallback, errorCallback)
        {

            if (typeof successCallback !== 'function')
            {
                successCallback = function (res) { };
            }

            if (typeof completeCallback !== 'function')
            {
                completeCallback = function (res) { };
            }
            
            if (typeof errorCallback !== 'function')
            {
                errorCallback = function(res){};
            }

            var _dataToSend = $.extend({}, data);

            $.ajax({
                method: method,
                url: url,
                contentType: "application/json; charset=utf-8",
                data: _dataToSend,
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: successCallback,
                complete: completeCallback,
                error: errorCallback
            });

        }

       
        _call('get', '/api/me', {}, function (data) {
            $('#userWelcome').html('Witaj ' + data.userName);
        });

        _call('get', '/api/Categories', {}, function (data) {
            console.log(data);
            $.each(data, function (k, v) {
                $('.catygory-list').append('<li><a href="3" id="' + v.id + '">' + v.name + '</a></li>')
            });
            
        });

        $('.desc-nav').on('click', function (e) {
            if ($(this).hasClass('desc-nav-show')) {
                $(this).removeClass('desc-nav-show').addClass('desc-nav-hide');
                $(this).parent().find('.desc').animate({
                    height: '200px'
                }, 1000);
            }
            else {
                $(this).removeClass('desc-nav-hide').addClass('desc-nav-show');
                $(this).parent().find('.desc').animate({
                    height: '0px'
                }, 1000);
            }

            return false;
        })
        
    }

    _prepareSite();
    

});
