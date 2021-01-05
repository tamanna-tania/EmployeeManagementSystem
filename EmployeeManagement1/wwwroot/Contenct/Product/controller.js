app.controller('myController', function ($scope, myService) {
    ProductList();
  

    $scope.newProduct = {};
    $scope.clickedProduct = {};
    $scope.message = "";

    function ProductList() {
        myService.productList().then(function (result) {
            $scope.Products = result.data;
            console.log(result.data);
        });
    };

    $scope.addProduct = function () {
        myService.addProduct($scope.newProduct)
            .then(function (result) {
                    $scope.newProduct = {};
                $scope.message = "Data saved successfully";
                ProductList()
                  
        });

        
   
    };

    $scope.selectedProduct = function (product) {
        $scope.clickedProduct = product;
    };

    $scope.updateProduct = function () {


        myService.updateProduct($scope.clickedProduct).then(function (result) {
            $scope.message = "Data Update successfully";
            $scope.Products = result;
            ProductList();
        }, function (result) {
            alert(result);
        });
      
    };

    $scope.deleteProduct = function () {
        myService.deleteProduct($scope.clickedProduct.Id).then(function (result) {
            $scope.message = "Data Delete successfully";
            ProductList();
        }, function (result) {
            alert(result);
        });

    };

    $scope.clearInfo = function () {
        $scope.message = "";
    };

});

