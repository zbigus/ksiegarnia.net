﻿function HomeViewModel(app, dataModel) {
    var self = this;

    self.myName = ko.observable("");

    //Sammy(function () {
    //    this.get('#home', function () {
    //        // Make a call to the protected Web API by passing in a Bearer Authorization Header
    //        $.ajax({
    //            method: 'get',
    //            url: app.dataModel.userInfoUrl,
    //            contentType: "application/json; charset=utf-8",
    //            headers: {
    //                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
    //            },
    //            //Tak się to robi Joł
    //            success: function (data) {
    //                self.myName(data.userName);
    //            }
    //        });
    //    });
    //    this.get('/', function () { this.app.runRoute('get', '#home') });
    //});

    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
