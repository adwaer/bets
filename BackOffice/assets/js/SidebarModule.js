angular
    .module('sidebar', ['requests', 'ui.bootstrap'])
    .controller('SidebarCtrl', ['$scope', function ($scope) {
        $scope.isActive = function(hash){
            return location.hash == hash;
        };

        $scope.redirectToMain = function(){
            window.location.href = '/';
        };
    }]);