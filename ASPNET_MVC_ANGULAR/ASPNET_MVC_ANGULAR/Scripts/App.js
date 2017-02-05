var app = angular.module("restaurantesApp", []);


app.controller("restauranteCtrl", function ($scope, $http) {

    $http({
        method: 'GET',
        url: '/Restaurante/GetRestaurantes/'
    }).then(function (success) {
        $scope.restaurantes = success.data;
    }, function (error) {
        console.log(error);
    });

    //Incluir
    $scope.AddRestaurante = function (restaurante) {
        $http({
            method: 'POST',
            url: '/Restaurante/CriarRestaurante/',
            data: { novoRestaurante: restaurante }
        }).then(function (success) {
            window.location.href = '/Restaurante';
        }, function (error) {
            console.log(error);
        });
    }

    $scope.NomeRestaurante = function (restaurante) {
        $http({
            method: 'POST',
            url: '/Restaurante/GetRestaurantePorNome/',
            data: { nome: restaurante.Nome }
        }).then(function (success) {
            $scope.restaurantes = success.data;
            
        }, function (error) {
            console.log(error);
        });
    }

    $scope.DeletaRestaurante = function (restaurante) {

        if (confirm("Deseja exluir restaurante: " + restaurante.Nome) == true)
            $http({
                method: 'POST',
                url: '/Restaurante/ExcluirRestaurante/',
                data: { restaurante: restaurante }
            }).then(function (success) {
                window.location.href = '/Restaurante';
            }, function (error) {
                console.log(error);
            });
    }


});

app.controller("restauranteEditarCtrl", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/Restaurante/GetRestaurante?id=' + getUrlParameter('id')
    }).then(function (success) {
        $scope.restaurante = success.data;
    }, function (error) {
        console.log(error);
    });


    $scope.EditaRestaurante = function (restaurante) {
        $http({
            method: 'POST',
            url: '/Restaurante/EditarRestaurante/',
            data: { restaurante: restaurante }
        }).then(function (success) {
            window.location.href = '/Restaurante';
        }, function (error) {
            console.log(error);
        });
    }


});

app.controller("pratoCtrl", function ($scope, $http) {

    $http({
        method: 'GET',
        url: '/Prato/GetPratos/'
    }).then(function (success) {
        $scope.pratos = success.data;
    }, function (error) {
        console.log(error);
    });

    $scope.ListaRestaurantes = [];

    $http({
        method: 'GET',
        url: '/Restaurante/GetRestaurantes/'
    }).then(function (success) {
        $scope.ListaRestaurantes = success.data;
    }, function (error) {
        console.log(error);
    });

    //Incluir
    $scope.AddPrato = function (prato) {
        $http({
            method: 'POST',
            url: '/Prato/CriarPrato/',
            data: { novoPrato: prato }
        }).then(function (success) {
            window.location.href = '/Prato';
        }, function (error) {
            console.log(error);
        });
    }

    $scope.DeletaPrato = function (prato) {

        if (confirm("Deseja exluir prato: " + prato.Nome) == true)
            $http({
                method: 'POST',
                url: '/Prato/ExcluirPrato/',
                data: { prato: prato }
            }).then(function (success) {
                window.location.href = '/Prato';
            }, function (error) {
                console.log(error);
            });
    }

});

app.controller("pratoEditarCtrl", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/Prato/GetPrato?id=' + getUrlParameter('id')
    }).then(function (success) {
        $scope.prato = success.data;
    }, function (error) {
        console.log(error);
    });

    $scope.ListaRestaurantes = [];

    $http({
        method: 'GET',
        url: '/Restaurante/GetRestaurantes/'
    }).then(function (success) {
        $scope.ListaRestaurantes = success.data;
    }, function (error) {
        console.log(error);
    });

    $scope.EditaPrato = function (prato) {
        $http({
            method: 'POST',
            url: '/Prato/EditarPrato/',
            data: { prato: prato }
        }).then(function (success) {
            window.location.href = '/Prato';
        }, function (error) {
            console.log(error);
        });
    }
});


function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;

    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }

    return res;
}