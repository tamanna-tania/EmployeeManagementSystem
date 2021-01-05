app.service('myService', function ($http) {

    this.productList = function () {
        var response = $http.get('Product/ProductList');
        return response;
    };

    this.addProduct = function (product) {
        //alert(product);
        var response = $http({
            method: 'post',
            url: 'Product/AddProduct',
            data: JSON.stringify(product)
        });
        return response;
    };

    this.updateProduct = function (product) {
        //alert(product);
        var response = $http({
            method: 'post',
            url: 'Product/UpdateProduct',
            data: JSON.stringify(product),
        });
        return response;
    };

    this.deleteProduct = function (id) {
        var response = $http({
            method: 'post',
            url: 'Product/DeleteProduct',
            params: { Id: JSON.stringify(id) }
        });
        return response;
    };

});
