app.service('CommonService', ['$http', '$rootScope', function ($http, $rootScope) {
    var list = {};

    list.GetProductTypes = function () {
        return $http({
            method: "GET",
            url: $rootScope.apiUrl + 'Product/GetProductTypeList',
        });
    };

    list.GetProductListByTypes = function (id) {
        return $http({
            method: "GET",
            url: $rootScope.apiUrl + 'Product/GetProductByTypeId?id=' +  id
        });
    };

    return list;
}]);