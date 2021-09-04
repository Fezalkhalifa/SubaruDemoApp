(function () {
    'use strict';

    app.controller('ProductListCtrl', ['$scope', '$filter', '$rootScope', 'NgTableParams', 'CommonService', ProductListCtrl]);

    function ProductListCtrl($scope,$filter ,$rootScope, NgTableParams, CommonService) {
        $scope.productLists = [];
        //$scope.productDetail = {};

        $scope.init = function (id) {
            if (angular.isDefined(id) && id > 0) {
                $scope.ProductList(id);
            } else {
                window.location.href = "/Product/index";
            }
        }

        $scope.ProductList = function (id) {
            CommonService.GetProductListByTypes(id).then(function (response) {
                if (response && response.data) {
                    var data = response.data;
                    if (data.MessageType == 1 && data.Result) {
                        $scope.productLists = angular.copy(data.Result);
                        $scope.tableParams = new NgTableParams({}, { dataset: $scope.productLists });
                    }
                    else {
                        alert(data.Message);
                    }
                }
            })

        }

        $scope.ShowDetail = function (id) {
            if (angular.isDefined(id) && id > 0) {
                debugger;
                $scope.productDetail = $filter('filter')($scope.productLists, function (d) { return d.Id === id; });
            }
        }
    }

})();

