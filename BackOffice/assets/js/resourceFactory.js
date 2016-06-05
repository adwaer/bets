angular
    .module('requests', [])
    .factory('resourceFactory', function ($resource, $q, $http) {

        var config = undefined;
        $http.get('settings.json')
            .then(function (result) {
                config = result.data.host;
            });

        return {
            serviceHost: function (){
                return config;
            },
            getFor: function (uri) {
                return $resource(this.serviceHost() + uri + ':id');
            }
        };
    });