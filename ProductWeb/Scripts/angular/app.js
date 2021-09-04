var app = angular.module("SubaruApp", ['ngTable']);

angular.module("SubaruApp").run(["$rootScope", AppRun]);

function AppRun($rootScope) {
    $rootScope.apiUrl ='https://localhost:44345/api/'
}
