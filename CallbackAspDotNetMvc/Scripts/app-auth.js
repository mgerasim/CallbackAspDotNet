var app = angular.module('myApp', ['ionic']);

    
app.run(function ($ionicPlatform, $location, $rootScope) {
    $ionicPlatform.ready(function () {
        $location.path('/tab/signup');
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
      .state('tabs.signup', {
          url: "/signup",
          views: {
              'signup-tab': {
                  templateUrl: "signup.html"
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
      .state('tabs.person', {
          url: "/person",
          views: {
              'signup-tab': {
                  templateUrl: "person.html"
              }
          }
      })
      .state('tabs.success', {
          url: "/seccess",
          views: {
              'signup-tab': {
                  templateUrl: "success.html"
              }
          }
      })
      .state('tabs.signin', {
          url: "/signin",
          views: {
              'signin-tab': {
                  templateUrl: "signin.html"
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
    $scope.signup = {
        telephone: '792410867443',
        code: '',
        person: {
            lastname: "Герасимов",
            firstname: "Михаил",
            secondname: "Николаевич"
        }

    }
    $scope.changePhone = function () {
        console.log("changePhone");
        $scope.signup.code = '';
    }

    $scope.doTelephone = function () {
        if ($scope.signup.code.length > 0) {
            return false;
        }
        var telephone = document.getElementById("telephone");
        $scope.signup.telephone = telephone.value;
        var theUrl = window.urlTelephone +
        "?telephone=" + document.getElementById("telephone").value;

        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", theUrl, false); // false for synchronous request
        xmlHttp.send(null);
        console.log(xmlHttp.responseText);
        return xmlHttp.responseText;
    }

    $scope.doCode = function () {
        
        console.log($scope);
        var telephone = document.getElementById("telephone");
        var code = document.getElementById("code");
        $scope.signup.code = code.value;
        var theUrl = window.urlCode +
        "?telephone=" + $scope.signup.telephone + 
        "&code=" + document.getElementById("code").value;

        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", theUrl, false); // false for synchronous request
        xmlHttp.send(null);
        console.log(xmlHttp.responseText);
        if (xmlHttp.responseText == "") {
            window.location = "#/tab/person";
        }
        return xmlHttp.responseText;
    }

    $scope.doPerson = function () {
        console.log("person");
        var telephone = document.getElementById("telephone");
        var theUrl = window.urlPerson +
        "?telephone=" + $scope.signup.telephone +
         "&code=" + $scope.signup.code +
        "&lastname=" + document.getElementById("lastname").value +
        "&firstname=" + document.getElementById("firstname").value +
        "&secondname=" + document.getElementById("secondname").value;

        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", theUrl, false); // false for synchronous request
        xmlHttp.send(null);
        console.log(xmlHttp.responseText);
        return xmlHttp.responseText;
    }
}]);