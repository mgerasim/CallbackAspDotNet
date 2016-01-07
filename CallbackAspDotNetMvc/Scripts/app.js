var app = angular.module('myApp', ['ionic']);

app.run(function ($ionicPlatform, $location, $rootScope) {
    $ionicPlatform.ready(function () {
        $location.path('/tab/call');
        $rootScope.$apply();
    });
});


app.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider
      .state('tabs', {
          url: "/tab",
          abstract: true,
          templateUrl: "templates/tabs.html"
      })
      .state('tabs.call', {
          url: "/call",
          views: {
              'call-tab': {
                  templateUrl: "templates/call.html"
              }
          }
      })
      .state('tabs.home', {
          url: "/home",
          views: {
              'home-tab': {
                  templateUrl: "templates/home.html"
              }
          }
      })
      .state('tabs.about', {
          url: "/about",
          views: {
              'about-tab': {
                  templateUrl: "templates/settings.html"
              }
          }
      })
      .state('tabs.contact', {
          url: "/contact",
          views: {
              'contact-tab': {
                  templateUrl: "templates/signout.html"
              }
          }
      });


    $urlRouterProvider.otherwise("/tab/home");

});

app.factory('Movies', function ($http) {
    var cachedData;

    function getData(moviename, apiKey, callback) {

        var url = 'http://api.themoviedb.org/3/',
          mode = 'search/movie?query=',
          name = '&query=' + encodeURI(moviename),
          key = '&api_key=' + apiKey;

        $http.get(url + mode + key + name).success(function (data) {

            cachedData = data.results;
            callback(data.results);
        });
    }

    return {
        list: getData,
        find: function (name, callback) {
            console.log(name);
            var movie = cachedData.filter(function (entry) {
                return entry.id == name;
            })[0];
            callback(movie);
        }
    };

});

app.controller('HomeCtrl', function ($scope, $ionicSideMenuDelegate, Movies) {

    $scope.selected = {
        movieName: 'Batman'
    }

    $scope.settings = {
        apiKey: '5fbddf6b517048e25bc3ac1bbeafb919',
        itemsPerPage: 5,
        minimumScore: 5
    }

    $scope.greaterThan = function (fieldName) {
        return function (item) {
            return item[fieldName] > $scope.settings.minimumScore;
        }
    }

    $scope.searchMovieDB = function () {

        Movies.list($scope.selected.movieName, $scope.settings.apiKey, function (movies) {
            $scope.movies = movies;
        });

    };

    $scope.doCall = function ($name, $phoneBgn, $phoneEnd) {

        return Call($name, $phoneBgn, $phoneEnd);
    };

    $scope.UpdateSchema = function () {
        var theUrl = window.urlUpdateSchema ;

        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", theUrl, false); // false for synchronous request
        xmlHttp.send(null);

        var divItem = document.createElement("div");
        divItem.setAttribute("class", "item item-button-right");
        var txt = document.createTextNode(xmlHttp.responseText);
        divItem.appendChild(txt);

        
        document.getElementById("response-updateschema").insertBefore(divItem, document.getElementById('response-updateschema').firstChild);

        return xmlHttp.responseText;
    }

    $scope.searchMovieDB();
});



function Call($name, $phoneBgn, $phoneEnd) {

    if ($name != "") {

        document.getElementById("name").value = $name;
    }

    if ($phoneBgn != "") {

        document.getElementById("phone-bgn").value = $phoneBgn;
    }

    if ($phoneEnd != "") {
        document.getElementById("phone-end").value = $phoneEnd;
    }

    var theUrl = window.urlDoCall +
        "?name=" + document.getElementById("name").value +
        "&phonebgn=" + document.getElementById("phone-bgn").value +
        "&phoneend=" + document.getElementById("phone-end").value;

    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", theUrl, false); // false for synchronous request
    xmlHttp.send(null);
    var divItem = document.createElement("div");
    divItem.setAttribute("class", "item item-button-right");
    var txt = document.createTextNode(document.getElementById("phone-bgn").value + " на " + document.getElementById("phone-end").value);
    divItem.appendChild(txt);

    var buttonElem = document.createElement("button");
    buttonElem.setAttribute("class", "button button-positive");
    //  buttonElem.setAttribute("ng-click", "doCall('33', '45')");
    buttonElem.setAttribute("onclick", "Call('" + document.getElementById("name").value + "', '" + document.getElementById("phone-bgn").value + "', '" + document.getElementById("phone-end").value + "')");

    var iconElem = document.createElement("i");
    iconElem.setAttribute("class", "icon ion-ios-telephone");

    buttonElem.appendChild(iconElem);
    divItem.appendChild(buttonElem);


    //var text = xmlHttp.responseText;

    //var p = document.createElement("p");
    //var txt = document.createTextNode(text);
    //p.appendChild(txt);
    document.getElementById("response").insertBefore(divItem, document.getElementById('response').firstChild);

    return xmlHttp.responseText;
}