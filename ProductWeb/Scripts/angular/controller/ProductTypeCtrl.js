(function () {
    'use strict';

    app.controller('ProductTypeCtrl', ['$scope', '$rootScope','NgTableParams', 'CommonService', ProductTypeCtrl]);

    function ProductTypeCtrl($scope, $rootScope, NgTableParams, CommonService) {
        $scope.productTypeLists = [];

        $scope.init = function () {
            debugger;
            $scope.ProductTypeList();
        }

        $scope.ProductTypeList = function () {
            debugger;
            CommonService.GetProductTypes().then(function (response) {
                if (response && response.data) {
                    var data = response.data;
                    if (data.MessageType == 1 && data.Result) {
                        $scope.productTypeLists = angular.copy(data.Result);
                        $scope.tableParams = new NgTableParams({}, { dataset: $scope.productTypeLists });
                    }
                    else {
                        alert(data.Message);
                    }
                }
            })

        }
        $scope.ShowChild = function (id) {
            if (angular.isDefined(id)) {
                window.location.href = "/Product/ProductList?Id=" + id;
            }
        }
    }

})();

