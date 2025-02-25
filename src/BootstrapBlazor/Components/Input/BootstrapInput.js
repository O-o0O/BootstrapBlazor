﻿(function ($) {
    $.extend({
        bb_input: function (el, obj, enter, enterCallbackMethod, esc, escCallbackMethod) {
            var $el = $(el);
            $el.on('keyup', function (e) {
                if (enter && e.key === 'Enter') {
                    obj.invokeMethodAsync(enterCallbackMethod);
                }
                else if (esc && e.key === 'Escape') {
                    obj.invokeMethodAsync(escCallbackMethod, $el.val());
                }
            });
        },
        bb_input_selectAll: function (el) {
            var $el = $(el);
            $el.on('focus', function () {
                $(this).select();
            });
        }
    });
})(jQuery);
