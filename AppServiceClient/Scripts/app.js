/// <reference path="lib/angular.js />

var locationApp = angular.module('locationApp', ['AdalAngular']);

locationApp.config(['$httpProvider', 'adalAuthenticationServiceProvider', function ($httpProvider, adalProvider) {
    var endpoints = {
        "https://localhost:44354": "https://itektest.onmicrosoft.com/WebTestAPI"

    };
    adalProvider.init({
        instance: 'https://login.microsoftonline.com/',
        tenant: 'itektest.onmicrosoft.com',
        clientId: '54758439-7751-418e-8273-d6813d6ec93c',
        endpoints: endpoints
    }, $httpProvider);
}]);


var locationController = locationApp.controller("locationController", [
    '$scope', '$http', 'adalAuthenticationService',
    function ($scope, $http, adalService) {
        $scope.getLocation = function () {
        $http.get("https://localhost:44354/api/location?cityName=dc").success(function (location) {
            $scope.city = location;
        });
    }

    $scope.login = function () {
        adalService.login();
    };
    $scope.logout = function () {
        adalService.logOut();
    };
}]);