var invoiceApp = angular.module('invoiceApp', []);


invoiceApp.controller("invoiceController", function($scope, $http) {
	$scope.invoice = {
		periodStart: "2014-05-01",
		periodEnd: "2014-05-31",
		hours: 0,
		invoiceNumber: 11082,
	};
	$scope.create = function() {
		console.log($scope.invoice);

		$http.post("api/Invoice", $scope.invoice)
			.success(function(data, status, headers, config) {
				console.log($scope.invoice);
			})
			.error(function(data, status, headers, config) {
				console.log("failed \r\n" + $scope.invoice);
			});
	};
});
