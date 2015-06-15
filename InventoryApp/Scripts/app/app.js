//home-index.js
(function () {
    'use strict';

    angular
        .module('app', ['ngRoute'])
        .config(function ($routeProvider, $locationProvider) {
            $routeProvider.when('/', {
                controller: 'InventoryItemsController',
                controllerAs: 'vm',
                templateUrl: './Scripts/app/Templates/inventoryItemsView.html'
            });
            $routeProvider.otherwise({ redirectTo: '/' });
            $locationProvider.html5Mode(true);
        })
        .factory('dataService', dataService)
        .controller('InventoryItemsController', InventoryItemsController);

    dataService.$inject = ['$http', '$q'];

    function dataService($http, $q) {

        var _isInit = false;

        var service = {
            getSingleItem: getSingleItem,
            getItems: getItems,
            getCategories: getCategories,
            getLocations: getLocations,
            getInventoryItems: getInventoryItems,
            getSingleInventoryItem: getSingleInventoryItem,
            getTrackingsForInventoryItem: getTrackingsForInventoryItem,
            saveInventoryItem: saveInventoryItem,
            isReady: _isReady,
        };
        return service;

        function _isReady() {
            return _isInit;
        }

        function getInventoryItems() {
            return $http.get('/api/v1/inventoryitems')
                .then(getInventoryItemsComplete)
                .catch(getInventoryItemsFailed);

            function getInventoryItemsComplete(result) {
                return result.data;

            }
            function getInventoryItemsFailed() {
            }
        }
        function getLocations() {

            return $http.get('/api/v1/locations')
                .then(getLocationsComplete)
                .catch(getLocationsFailed);

            function getLocationsComplete(result) {
                return result.data;
            }
            function getLocationsFailed() {

            }
        }
        function getCategories() {
            return $http.get('/api/v1/categories')
                .then(getCategoriesComplete)
                .catch(getCategoriesFailed);
            function getCategoriesComplete(result) {
                return result.data;
            }
            function getCategoriesFailed() {

            }
        }
        function getItems(categoryId) {
            return $http.get('/api/v1/categories/' + categoryId + '/items')
                .then(getItemsComplete)
                .catch(getItemsFailed);
            function getItemsComplete(result) {
                return result.data;
            }
            function getItemsFailed() {

            }
        }
        function getSingleItem(id) {

            return $http.get('/api/v1/items/' + id)
            .then(getSingleItemComplete)
            .catch(getSingleItemFailed);

            function getSingleItemComplete(result) {
                return result.data;
            }
            function getSingleItemFailed() {

            }
        }
        function getSingleInventoryItem(id) {
            return $http.get('/api/v1/inventoryitems/' + id)
            .then(getSingleInventoryItemComplete)
            .catch(getSingleInventoryItemFailed);

            function getSingleInventoryItemComplete(result) {
                return result.data;
            }
            function getSingleInventoryItemFailed() {

            }
        }
        function saveInventoryItem(item) {

            return $http.put('/api/v1/inventoryitems/' + item.id, item)
                .then(function (result) {
                    return result.data;
                },
                    function () {

                    });
        }
        function getTrackingsForInventoryItem(id) {
            return $http.get('/api/v1/tracking/inventoryItem/' + id)
            .then(getTrackingsComplete)
            .catch(getTrackingsFailed);

            function getTrackingsComplete(result) {
                return result.data;
            }
            function getTrackingsFailed() {

            }
        }
    }

    InventoryItemsController.$inject = ['$scope', '$http', '$filter', 'dataService'];

    function InventoryItemsController($scope, $http, $filter, dataService) {
        var vm = this;
        vm.categories = [];
        vm.inventoryItem = {};
        vm.inventoryItems = [];
        vm.items = [];
        vm.locations = [];
        vm.trackings = [];

        vm.saveInventoryItem = saveInventoryItem;
        vm.updateItems = updateItems;
        vm.updateInventoryItem = updateInventoryItem;
        vm.viewInventoryItem = viewInventoryItem;
        vm.viewTracking = viewTracking;

        activate();

        function activate() {
            getInventoryItems();
            getCategories();
            getLocations();
        }

        function getCategories() {
            dataService.getCategories()
                .then(function (data) {
                    vm.categories = data;
                });
        }
        function getLocations() {
            dataService.getLocations()
                .then(function (data) {
                    vm.locations = data;
                });
        }
        function getInventoryItems() {
            dataService.getInventoryItems()
                .then(function (data) {
                    vm.inventoryItems = data;
                });
        }
        function getTrackingsForInventoryItem(id) {
            dataService.getTrackingsForInventoryItem(id)
                .then(function (data) {
                    vm.trackings = data;
                });
        }
        function getItems(id) {
            dataService.getItems(id)
                .then(function (data) {
                    vm.items = data;
                    var selectedItemIndex = getSelectedItemIndex(vm.inventoryItem.itemId);
                    vm.selectedItem = vm.items[selectedItemIndex];
                });
        }
        function getSingleInventoryItem(id) {
            var dataFormatString = "MM/dd/yyyy @ h:mma";
            dataService.getSingleInventoryItem(id)
                .then(function (data) {
                
                    vm.inventoryItem = data;
                    //vm.inventoryItem.dateAdded = $filter('date')(vm.inventoryItem.dateAdded, dataFormatString);
                    //vm.inventoryItem.dateModified = $filter('date')(vm.inventoryItem.dateModified, dataFormatString);

                    dataService.getSingleItem(data.itemId)
                        .then(function (result) {

                            var selectedCategoryIndex = getSelectedCategoryIndex(result.categoryId);
                            vm.selectedCategory = vm.categories[selectedCategoryIndex];

                            var selectedLocationIndex = getSelectedLocationIndex(vm.inventoryItem.locationId);
                            vm.selectedLocation = vm.locations[selectedLocationIndex];

                            getItems(result.categoryId);
                            getTrackingsForInventoryItem(result.id);
                        });
                });
        }
        function getSelectedCategoryIndex(id) {
            var found = null;
            $.each(vm.categories, function (i, category) {
                if (category.id == id) {
                    found = i;
                }
            });
            return found;
        }
        function getSelectedLocationIndex(id) {
            var found = null;
            $.each(vm.locations, function (i, location) {
                if (location.id == id) {
                    found = i;
                }
            });
            return found;
        }
        function getSelectedItemIndex(id) {
            var found = null;
            $.each(vm.items, function (i, item) {
                if (item.id == id) {
                    found = i;
                }
            });
            return found;
        }
        function viewInventoryItem(inventoryItemId) {
            vm.trackings = [];
            
            getSingleInventoryItem(inventoryItemId);
        }
        function viewTracking() {
            getTrackingsForInventoryItem(vm.inventoryItem.id);
        }
        function saveInventoryItem() {
            dataService.saveInventoryItem(vm.inventoryItem)
                .then(function () {
                    getInventoryItems();
                }),
            function () {
                alert('Could not save the item');
            };
        }
        function updateItems() {
            getItems(vm.selectedCategory.id);
        }
        function updateInventoryItem() {

            var inventoryItem = vm.inventoryItem;
            inventoryItem.itemId = vm.selectedItem.id;
            inventoryItem.locationId = vm.selectedLocation.id;
        }
    }

})();