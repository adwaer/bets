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
    ])
    .factory('Bet',
        function ($resource, resourceFactory, authenticationService) {
            return $resource(resourceFactory.serviceHost() + 'api/bets:id', {},
                {
                    query: {
                        method: 'GET',
                        headers: {
                            'Authorization': 'Basic ' + authenticationService.GetCredentials()
                        },
                        isArray: true
                    }
                });
        })
    .controller('BetAddCtrl', BetAddCtrl);