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
                        resolve: {
                            dlgScope: function(){
                                return scope;
                            }
                        }
                    });
                });
            },
            scope: true,
            restrict: 'AE',
            require: '?ngModel'
        };

    });