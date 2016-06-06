window.BetAddCtrl = function ($scope, $timeout, Bet, dlgScope) {
    $scope.isLoading = false;

    $scope.submit = function () {
        if ($scope.addBetForm.$invalid) {
            return;
        }

        $scope.Error = '';
        $scope.isLoading = true;

        $scope.model.$save(function () {
                $scope.$close();
            },
            function (result) {
                if (result.data && result.data.ModelState) {
                    for (var v in result.data.ModelState) {
                        $scope.Error += result.data.ModelState[v];
                    }
                } else {
                    $scope.Error = result.statusText || 'Невозможно сохранить, сервер вернул ошибку';
                }
            });
    };

    function ctor() {
        $scope.model = new Bet();

        var bet = dlgScope.$parent.bet;
        if (bet) {
            angular.extend($scope.model, bet);
        }
        else {
            $scope.model.showDate = new Date();
            $scope.model.showDate.setHours(0, 0, 0, 0);
            $scope.model.gameStartDate = $scope.model.showDate;
        }
    }

    ctor();
};