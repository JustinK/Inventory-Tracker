//home-index.js
var module = angular.module('app', ['ngRoute']);

module.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        controller: 'inventoryItemsController',
        templateUrl: '/templates/inventoryItemsView.html'
    });
    $routeProvider.when('/newmessage', {
        controller: 'newTopicController',
        templateUrl: '/templates/newTopicView.html'
    });
    $routeProvider.when('/message/:id', {
        controller: 'singleTopicController',
        templateUrl: '/templates/singleTopicView.html'
    });
    $routeProvider.otherwise({ redirectTo: '/' });
    $locationProvider.html5Mode(true);
});
module.factory('dataService', function ($http, $q) {
    var _inventoryItems = [];
    var _locations = [];
    var _inventoryItem = {};
    var _isInit = false;
    var _isReady = function () {
        return _isInit;
    };
    var _getInventoryItems = function () {
        var deferred = $q.defer();
        $http.get('/api/v1/inventoryitems').then(function (result) {
            angular.copy(result.data, _inventoryItems);
            //_isInit = true;
            deferred.resolve();
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };
    var _getLocations = function () {
        var deferred = $q.defer();
        $http.get('/api/v1/locations').then(function (result) {
            angular.copy(result.data, _locations);
            //_isInit = true;
            deferred.resolve();
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };
    var _getSingleInventoryItem = function (id) {
        var deferred = $q.defer();
        $http.get('/api/v1/inventoryitems/'+id).then(function (result) {
            angular.copy(result.data, _inventoryItem);
            _isInit = true;
            deferred.resolve(_inventoryItem);
        }, function () {
            deferred.reject();
        });
        return deferred.promise;
    };
    var _saveInventoryItem = function (item) {
        
        var deferred = $q.defer();
        $http.put('/api/v1/inventoryitems/' + item.id, item)
            .then(function (result) {
                deferred.resolve(result.data);
            },
            function () {
                deferred.reject();
            });
        return deferred.promise;
    };
    var _addTopic = function (newTopic) {
        var deferred = $q.defer();
        $http.post('/api/v1/topics', newTopic)
            .then(function (result) {
                var newlyCreatedTopic = result.data;
                _topics.splice(0, 0, newlyCreatedTopic);
                deferred.resolve(newlyCreatedTopic);
            },
                function () {
                    deferred.reject();
                });
        return deferred.promise;
    };

    function _findTopic(id) {
        var found = null;
        $.each(_topics, function (i, item) {
            if (item.id == id) {
                found = item;
                return false;
            }
        });
        return found;
    }

    var _getTopicById = function (id) {
        var deferred = $q.defer();

        if (_isReady) {
            var topic = _findTopic(id);
            if (topic) {
                deferred.resolve(topic);
            } else {
                deferred.reject();
            }
        } else {
            _getTopics().then(
                function () {
                    var topic = _findTopic(id);
                    if (topic) {
                        deferred.resolve(topic);
                    } else {
                        deferred.reject();
                    }
                },
                function () {
                    deferred.reject();
                });
        }

        return deferred.promise;
    };
    var _saveReply = function (topic, newReply) {
        var deferred = $q.defer();

        $http.post('/api/v1/topics/' + topic.id + '/replies', newReply)
            .then(function (result) {
                if (topic.replies == null) topic.replies = [];
                topic.replies.push(result.data);
                deferred.resolve(result.data);
            },
                function () {
                    deferred.reject();
                });

        return deferred.promise;
    };
    return {
        inventoryItems: _inventoryItems,
        inventoryItem: _inventoryItem,
        locations: _locations,
        getLocations: _getLocations,
        getInventoryItems: _getInventoryItems,
        getSingleInventoryItem: _getSingleInventoryItem,
        saveInventoryItem: _saveInventoryItem,
        addTopic: _addTopic,
        isReady: _isReady,
        getTopicById: _getTopicById,
        saveReply: _saveReply
    };

});
var inventoryItemsController = function ($scope, $http, dataService) {

    $scope.data = dataService;
    dataService.getLocations()
        .then(function () {
        
        },
        function () {
            alert('could not load inventory item');
        }).then(function () {

        });
    //$scope.inventoryItem = {};
    $scope.isBusy = false;
    var getInventoryItems = function () {
        $scope.isBusy = true;
        dataService.getInventoryItems()
            .then(function () {

            },
            function () {
                alert('could not load inventory items');
            }).then(function () {
                $scope.isBusy = false;
            });
    };

    if (dataService.isReady() == false) {
        getInventoryItems();
    }
    $scope.viewInventoryItem = function(inventoryItemId) {
        dataService.getSingleInventoryItem(inventoryItemId)
            .then(function (inventoryItem) {
                //$scope.inventoryItem = inventoryItem;
            },
            function () {
                alert('could not load inventory item');
            }).then(function () {
                   
            });;
    };
    $scope.saveInventoryItem = function () {
        
        dataService.saveInventoryItem($scope.data.inventoryItem)
            .then(function () {
                getInventoryItems();
            }),
        function () {
            alert('Could not save the new reply');
        };
    };
    
};
inventoryItemsController.$inject = ['$scope', '$http', 'dataService'];


function newTopicController($scope, $window, dataService) {
    $scope.newTopic = {};
    $scope.save = function () {
        dataService.addTopic($scope.newTopic).then(
            function () {
                $window.location = '#/';
            },
            function () {
                alert('could not save for some reason');
            });
    };
}

function singleTopicController($scope, $routeParams, $window, dataService) {
    $scope.topic = null;
    $scope.newReply = {};
    dataService.getTopicById($routeParams.id)
        .then(function (topic) {
            $scope.topic = topic;
        },
        function () {
            $window.location = '#/';
        });
    $scope.addReply = function () {
        dataService.saveReply($scope.topic, $scope.newReply)
                .then(function () {
                    $scope.newReply.body = '';
                }),
            function () {
                alert('Could not save the new reply');
            };
    };
}