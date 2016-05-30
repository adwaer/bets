angular
    .module('bets', ['requests', 'ui.bootstrap'])
    .config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/betstable', {
                    templateUrl: '/bets_table.html',
                    controller: window.BetsTableCtrl,
                    reloadOnSearch: false
                })
        }
    ]);