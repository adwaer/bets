window.AuthCtrl = function ($scope, $location, authenticationService) {
    $scope.isLoading = false;

    $scope.submit = function () {
        if ($scope.loginForm.$invalid) {
            return;
        }

        $scope.Error = 0;
        $scope.isLoading = true;

        authenticationService.Login($scope.model.email, $scope.model.password, function (response) {
            authenticationService.SetCredentials($scope.model.email, $scope.model.password);
            $location.path('/');
        }, function (response) {
            $scope.Error = response.statusText;
        });

    };

    function ctor() {
        authenticationService.ClearCredentials();
    }

    ctor();
};