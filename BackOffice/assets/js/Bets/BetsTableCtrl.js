window.BetsTableCtrl = function ($scope, Bet) {
    $scope.isLoading = false;

    $scope.search = function () {
        $scope.bets = undefined;
        $scope.isLoading = true;
        $scope.Error = 0;

        Bet.query()
            .$promise
            .then(function (data) {
                $scope.bets = data;
            })
            .catch(function (result) {
                if (result.data.ModelState) {
                    for (var v in result.data.ModelState) {
                        $scope.Error += result.data.ModelState[v];
                    }
                } else {
                    $scope.Error = 'Невозможно сохранить, сервер вернул ошибку';
                }
            })
            .finally(function(){
                $scope.isLoading = false;
            });
    };

    function ctor() {
        $scope.search();
    }

    ctor();
};