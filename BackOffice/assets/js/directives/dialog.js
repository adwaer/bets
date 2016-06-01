angular
    .module('ngDialog', ['ui.bootstrap'])
    .directive('ngDialog', function ($uibModal) {
        var marker;
        return {
            link: function (scope, element, attributes) {
                element.bind('click', function () {
                    $uibModal.open({
                        animation: true,
                        templateUrl: attributes.template,
                        controller: attributes.ctrl,
                        resolve: attributes.resolve || function () {
                        }
                    });
                });
            },
            scope: true,
            restrict: 'AE'
        };

    });