var app = angular.module('myApp', ['ionic']); 

    
app.run(function ($ionicPlatform, $location, $rootScope) {
    $ionicPlatform.ready(function () {
        $location.path('/tab/users');
        $rootScope.$apply();
    });
});

app.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider
      .state('tabs', {
          url: "/tab",
          abstract: true,
          templateUrl: "tabs.html"
      })
      .state('tabs.users', {
          url: "/users",
          views: {
              'users-tab': {
                  templateUrl: "users.html"
              }
          }
      })
      .state('tabs.code', {
          url: "/code",
          views: {
              'signup-tab': {
                  templateUrl: "code.html"
              }
          }
      })
      .state('tabs.about', {
          url: "/about",
          views: {
              'about-tab': {
                  templateUrl: "about.html"
              }
          }
      })
      .state('tabs.contact', {
          url: "/contact",
          views: {
              'contact-tab': {
                  templateUrl: "contact.html"
              }
          }
      });


    $urlRouterProvider.otherwise("/tab/signup");

})

app.controller('HomeTabCtrl', ['$scope', function ($scope) {
    
}]);