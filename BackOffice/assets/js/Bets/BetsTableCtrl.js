window.BetsTableCtrl = function ($scope, Bet) {
    $scope.isLoading = false;

    $scope.search = function () {
        $scope.bets = undefined;
        $scope.isLoading = true;
        $scope.Error = 0;

        Bet.query()
            .$promise
            .then(function (data) {
                //decorate(data);
                $scope.bets = data;
            })
            .catch(function (result) {
                if (result.data && result.data.ModelState) {
                    for (var v in result.data.ModelState) {
                        $scope.Error += result.data.ModelState[v];
                    }
                } else {
                    $scope.Error = result.statusText || 'Невозможно сохранить, сервер вернул ошибку';
                }
            })
            .finally(function () {
                $scope.isLoading = false;
            });
    };

    function decorate(data) {
        for (var i = 0; i < data.length; i++) {
            var bet = data[i];
            bet.gameStartDate = new Date(bet.gameStartDate);
            bet.showDate = new Date(bet.showDate);

            //bet.gameStartDate = new Date(bet.gameStartDate);
        }
    }


    function ctor() {
        $scope.search();
    }

    ctor();
}