(function () {
    'use strict';

    Object.defineProperty(Array.prototype, 'Count', {
        get: function () { return this.length; }
    });

    if (Array.prototype.addRange) return;

    Array.prototype.addRange = function (target) {
        this.push.apply(this, target);
    };

})();