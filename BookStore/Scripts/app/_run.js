$(function () {
    app.initialize();
    console.log('b');
    // Activate Knockout
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);

    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    isNumber = function(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    readImage = function(input, func) {
        if (input.files && input.files[0]) {
            var FR = new FileReader();
            FR.onload = func;
            FR.readAsDataURL(input.files[0]);
        }
    }

    l = function () {
        return {
            showPleaseWait: function () {
                $('#pleaseWaitDialog').modal('show');
            },
            hidePleaseWait: function () {
                $('#pleaseWaitDialog').modal('hide');
            },

        };
    };

    

    var _bindOnclick = function () {
        $('.desc-nav').off('click').on('click', function (e) {
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

        $('.buy').off('click').on('click', function () {
            bootbox.alert('Twoja zamówienie jest przekazane do zrealizowania');
            return false;
        })
    };

    var _bindCategoriesClick = function ()
    {
        $('.catygory-list-js a').on('click', function () {
            bootbox.alert('Wczytywanie');
            $('#productsrow').html('');
            
            $('.catygory-list-js a').removeClass('active');
            $(this).addClass('active');
            

            if ($(this).attr('id') == '-1')
            {
                _call('get', '/api/Books/top', {}, function (data) {
                    $.each(data, function (k, v) {
                        if (v.id && v.attachment && v.attachment.content && v.description) {
                            html = '<div class="product menu-category">';
                            html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                            html += '<div class="product-image">';
                            html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                            html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                            html += '<div class="desc">' + v.description + '</div>';
                            html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                            html += '</div>';

                            $('#productsrow').append(html);
                        }
                    });
                    bootbox.hideAll();
                    _bindOnclick();
                });
            }
            else
            {
                _call('get', '/api/Books/category/' + $(this).attr('id'), {}, function (data) {
                    console.log(data);
                    $.each(data, function (k, v) {
                        if (v.id && v.attachment && v.attachment.content && v.description) {
                            html = '<div class="product menu-category">';
                            html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                            html += '<div class="product-image">';
                            html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                            html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                            html += '<div class="desc">' + v.description + '</div>';
                            html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                            html += '</div>';

                            $('#productsrow').append(html);
                        }
                    });
                    bootbox.hideAll();
                    _bindOnclick();
                });
            }
            return false;
        });
    }

    _call = function (method, url, data, successCallback, completeCallback, errorCallback) {

        if (typeof successCallback !== 'function') {
            successCallback = function (res) { };
        }

        if (typeof completeCallback !== 'function') {
            completeCallback = function (res) { };
        }

        if (typeof errorCallback !== 'function') {
            errorCallback = function (res) { };
        }

        var _dataToSend = JSON.stringify(data);

        $.ajax({
            method: method,
            url: url,
            contentType: "application/json",
            data: _dataToSend,
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            success: successCallback,
            complete: completeCallback,
            error: errorCallback
        });
    };

    var _prepareSite = function()
    {
        _call('get', 'api/Orders/user', {}, function (data) {
            var status;
            var html;

            $.each(data, function (k, v) {
                if (v.id && v.status && v.statusName && v.bookTitle) {
                    if (v.status == 0) {
                        status = '<span class="realization-success">' + v.statusName + '</span>';
                    }
                    else if (v.status == 1)
                    {
                        status = '<td><span class="realization-in-progress">W TRAKCIE REALIZACJI</span></td>';
                    }
                    else if (v.status == 2) {
                        status = '<td><span class="realization-success">' + v.statusName + '</span></td>';
                    }
                    else if (v.status == 3) {
                        status = '<td><span class="realization-in-failure">' + v.statusName + '</span></td>';
                    }

                    html = '<tr><td>' + v.id + '</td><td>' + v.bookTitle + '</td>' + status + '</tr>';

                    $('#realisation-grid').append(html);
                }
            });
        });
       
        _call('get', '/api/me', {}, function (data) {
            $('#userWelcome').html('Witaj ' + data.userName);
            $('#user-grid .user-email').html(data.email);
            $('#user-grid .user-firstName').html(data.firstName);
            $('#user-grid .user-lastName').html(data.lastName);
            $('#user-grid .user-address').html(data.address);
        });

        _call('get', '/api/Books/bestsellers', {}, function (data) {
            var _isFirst = true;
            $.each(data, function (k, v) {
                if (v.id && v.attachment.content && v.description) {
                    if (_isFirst) {
                        html = '<div class="item active">';
                        _isFirst = false;
                    }
                    else {
                        html = '<div class="item">';
                    }
                    html += '<div class="row row-carousel">';
                    html += '<div class="col-md-6">';
                    html += '<img style="max-width:200px" class="img-responsive img-feature" src="data:image/gif;base64,' + v.attachment.content + '" alt="">';
                    html += '</div>';
                    html += '<div class="col-md-6">';
                    html += '<div class="call-to-action">';
                    html += '<h2>' + v.title + '</h2>';
                    html += '<p>';
                    html += v.description;
                    html += '</p>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    $('#top-carousel').append(html);
                }
            });
        });

        _call('get', '/api/Categories', {}, function (data) {
            $.each(data, function (k, v) {
                if (v.id && v.name) {
                    $('.catygory-list-js').append('<li><a href="3" id="' + v.id + '"><i style="margin-right:10px" class="glyphicon glyphicon-ok"></i>' + v.name + '</a></li>')
                }
            });
            $('.catygory-list-js').append('<li><a href="#" id="-1"><i style="margin-right:10px" class="glyphicon glyphicon-ok"></i>Wszystkie</a></li>')
            _bindCategoriesClick();
        });

        _call('get', '/api/Books/top', {}, function (data) {
            $.each(data, function (k, v) {
                if (v.id && v.attachment && v.attachment.content && v.description) {
                    html = '<div class="product menu-category">';
                    html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                    html += '<div class="product-image">';
                    html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                    html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                    html += '<div class="desc">' + v.description + '</div>';
                    html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                    html += '</div>';

                    $('#productsrow').append(html);
                }
            });

            _bindOnclick();
        });
    }

    _prepareSite();
    

    var _setupBasicEvents = function () {
        $('#admin-add-book').on('click', function () {
            $('#adminModal').modal('show')
            _call('get', '/api/Categories', {}, function (data) {
                $.each(data, function (k, v) {
                    if (v.id && v.name) {
                        $('#categorySelect').append('<option id="' + v.id + '">' + v.name + '</option>')
                    }
                });
            });

            _data = {};

            $("#fileSelect").off('change').on('change', function () {
                readImage(this, function (e) {
                    _base = e.target.result.replace('data:image/jpeg;base64,', '');
                    _data.attachments = [{ "name": "photo", "content": _base }]
                });
            });

            $("#categorySelect").off('change').on('change', function () {
                _data.categories = [{ "id": $('option:selected', this).attr('id'), "name": $(this).val() }]
            });
            
            $('#adminModal .new-book').off('click').on('click', function () {
                $('.validate').remove();
                _canSend = true;
                $.each($('.validateble'), function (k, v) {
                    _v = $(v)
                    if (_v.hasClass('number')) {
                        if (!isNumber(_v.val())) {
                            _canSend = false;
                            _v.after('<span class="validate" style="color:red">Wartość  liczbowa jest wymagana</span>');
                        }
                    }

                    if (_v.hasClass('text')) {
                        if (_v.val().length < 5 || _v.val().length > 200) {
                            _canSend = false;
                            _v.after('<span class="validate" style="color:red">Treść musi mieć więcej niz 5 znaków i mniej niz 250</span>');
                        }
                    }

                    if (_v.hasClass('isbn')) {
                        if (_v.val().length != 13) {
                            _canSend = false;
                            _v.after('<span class="validate" style="color:red">Isbn musi zawierać dokładnie 13 cyfr</span>');
                        }

                        if (!isNumber(_v.val())) {
                            _canSend = false;
                            _v.after('<br><span class="validate" style="color:red">Wartość  liczbowa jest wymagana</span>');
                        }
                    }
                })

                if (!_data.attachments)
                {
                    $("#fileSelect").after('<span class="validate" style="color:red">Musisz wybrać obrazek</span>');
                }

                if (!_data.categories) {
                    $("#categorySelect").after('<span class="validate" style="color:red">Musisz wybrać kategorię</span>');
                }

                if (_canSend)
                {
                    $.extend(_data, $('#adminModal form#basic').serializeObject());
                    _call('post', '/api/Books', _data, function (data) {
                        
                        location.reload();
                        _data = {};
                    }, function () { location.reload(); });
                    
                }

                
            })

           
            return false;
        })

        $('#search-by-string').on('click', function () {
            if ($("#search-string").val().trim().length > 0) {
                _call('get', '/api/Books/search/' + $("#search-string").val(), {}, function (data) {
                    $('#productsrow').html('');
                    $.each(data, function (k, v) {
                        if (v.id && v.attachment && v.attachment.content && v.description) {
                            html = '<div class="product menu-category">';
                            html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                            html += '<div class="product-image">';
                            html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                            html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                            html += '<div class="desc">' + v.description + '</div>';
                            html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                            html += '</div>';

                            $('#productsrow').append(html);
                            _bindOnclick();
                        }
                    });
                });
            }
            else
            {
                _call('get', '/api/Books/top', {}, function (data) {
                    $.each(data, function (k, v) {
                        if (v.id && v.attachment && v.attachment.content && v.description) {
                            html = '<div class="product menu-category">';
                            html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                            html += '<div class="product-image">';
                            html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                            html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                            html += '<div class="desc">' + v.description + '</div>';
                            html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                            html += '</div>';

                            $('#productsrow').append(html);
                            _bindOnclick();
                        }
                    });
                });
            }
        });

        $('#search-by-string-top').on('click', function () {
            if ($("#search-string-top").val().trim().length > 0) {
                _call('get', '/api/Books/search/' + $("#search-string-top").val(), {}, function (data) {
                    console.log(data);
                    $('#productsrow').html('');
                    $.each(data, function (k, v) {
                        if (v.id && v.attachment && v.attachment.content && v.description) {
                            html = '<div class="product menu-category">';
                            html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                            html += '<div class="product-image">';
                            html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                            html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                            html += '<div class="desc">' + v.description + '</div>';
                            html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                            html += '</div>';

                            $('#productsrow').append(html);
                            _bindOnclick();
                        }
                    });
                });
            }
            else {
                _call('get', '/api/Books/top', {}, function (data) {
                    $.each(data, function (k, v) {
                        if (v.id && v.attachment && v.attachment.content && v.description) {
                            html = '<div class="product menu-category">';
                            html += '<div class="menu-category-name list-group-item active">' + v.author + ' \\ ' + v.title + '</div>';
                            html += '<div class="product-image">';
                            html += '<img class="product-image menu-item list-group-item" src="data:image/gif;base64,' + v.attachment.content + '">';
                            html += '</div> <a href="#" id="' + v.id + '" class="menu-item list-group-item buy">Kup<span class="badge">' + v.price + 'zł</span></a>';
                            html += '<div class="desc">' + v.description + '</div>';
                            html += '<a href="#" class="menu-item list-group-item desc-nav desc-nav-show">Dowiedz się więcej<span class="badge"><i class="glyphicon glyphicon-circle-arrow-down"></i></span></a>';
                            html += '</div>';

                            $('#productsrow').append(html);
                            _bindOnclick();
                        }
                    });
                });
            }
        });
    }

    _setupBasicEvents();

});
