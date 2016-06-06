var app = angular.module('app',
    ['ngResource',
        'ngRoute',
        'ui.bootstrap',
        'requests',
        'bets',
        'sidebar',
        'ngDialog',
        'authentication',
        'ngCookies',
        'LocalStorageModule'
    ])
    .config(['$routeProvider',
        function($routeProvider) {
            $routeProvider
            .when('/login', {
                templateUrl: '/login.html',
                controller: window.AuthCtrl,
                reloadOnSearch: false
            })
            .otherwise({
                redirectTo: '/betstable'
            });
        }])
    .config(["$httpProvider", function ($httpProvider) {
        $httpProvider.defaults.transformResponse.push(function(responseData){
            helpers.convertDateStringsToDates(responseData);
            return responseData;
        });
    }])
    .run(['$rootScope', '$location', 'authenticationService', function ($rootScope, $location, authenticationService) {
        $rootScope.$on('$routeChangeStart', function (event) {

            if (!authenticationService.IsAuthentificated()) {
                $location.path('/login');
            }
        });
    }]);
//.config([
//    '$httpProvider', function ($httpProvider) {
//         $httpProvider.defaults.useXDomain = true;
//           delete $httpProvider.defaults.headers.common['X-Requested-With'];
//      }
//]);

angular.element(document).ready(function () {
    angular.bootstrap(document, ['app']);
});