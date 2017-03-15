angular.module('starter.controllers', ['ngCordova'])

.controller('AppCtrl', function($scope, $ionicModal, $timeout) {

  // With the new view caching in Ionic, Controllers are only called
  // when they are recreated or on app start, instead of every page change.
  // To listen for when this page is active (for example, to refresh data),
  // listen for the $ionicView.enter event:
  //$scope.$on('$ionicView.enter', function(e) {
  //});

  // Form data for the login modal
  $scope.loginData = {};

  // Create the login modal that we will use later
  $ionicModal.fromTemplateUrl('templates/login.html', {
    scope: $scope
  }).then(function(modal) {
    $scope.modal = modal;
  });

  // Triggered in the login modal to close it
  $scope.closeLogin = function() {
    $scope.modal.hide();
  };

  // Open the login modal
  $scope.login = function() {
    $scope.modal.show();
  };

  // Perform the login action when the user submits the login form
  $scope.doLogin = function() {
    console.log('Doing login', $scope.loginData);

    // Simulate a login delay. Remove this and replace with your login
    // code if using a login system
    $timeout(function() {
      $scope.closeLogin();
    }, 1000);
  };
})

.controller('HomeCtrl', function ($scope, $http) {
    // Fetch les derniers posts d'un lineup de icimusique
    $http
        .get('http://services.radio-canada.ca/neuro/v1/future/lineups/1000197')
        .then(function (response) {
            // Make sure that the call didn't fail
            if (response.status == 200) {
                var articles = [];

                for (var i = 0, len = response.data.pagedList.items.length; i < len; i++) {
                    var item = response.data.pagedList.items[i];

                    var article = {
                        id: item.id,
                        title: item.title,
                        picUrl: item.summaryMultimediaItem.concreteImages[0].mediaLink.href
                    }

                    articles.push(article);
                    console.dir(item.summaryMultimediaItem.concreteImages[0].mediaLink.href);
                }
                $scope.articles = articles;
            }
        });
})

.controller('ArticleCtrl', function ($scope, $stateParams) {
    $scope.articleId = $stateParams.articleId;
})

.controller('WebRadiosCtrl', function ($scope, $stateParams, $http, $cordovaMedia) {
    // Fetch les derniers posts d'un lineup de icimusique
    $http
        .get('http://services.radio-canada.ca/neuro/v1/lineups/91356')
        .then(function (response) {
            // On s'assure que l'appel fonctionne
            if (response.status == 200) {
                $scope.webradios = response.data.contentItemSummaries.items;

                console.log($scope.webradios);
            }
        });

    $scope.playWebRadio = function (webRadioId) {
        // A implementer un player
    }
});



