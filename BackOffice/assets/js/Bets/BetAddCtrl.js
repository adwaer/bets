window.BetAddCtrl = function ($scope, resourceFactory) {
    $scope.isLoading = false;

    $scope.search = function() {
        $scope.bets = undefined;
        $scope.isLoading = true;
        $scope.Error = 0;

        $scope.BetsApi.query()
            .$promise
            .then(function (data) {
                $scope.bets = data;
            })
            .catch(function(){
                $scope.Error = 'Произошла ошибка, возможно вы ввели некорректные данные';
            })
            .finally(function(){
                $scope.isLoading = false;
            });
    };

    function ctor() {

    }
    ctor();
};