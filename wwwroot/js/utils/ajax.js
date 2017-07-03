(function() {
    window.application = window.application || {};
    window.application.ajax = {
        get: function(url, defaultValue) {
            return new Promise(function(resolve, reject) {
                var result = defaultValue;
                $.ajax({
                    type: 'GET',
                    url: url
                })
                .then(function(data) {
                    result = data;
                })
                .fail(function(response) {
                    toastr.error('An error ocurred', 'Oops!', {timeOut: 5000});
                })
                .always(function(data) {
                    resolve(result);
                });
            });
        },
        remove: function(url) {
            return new Promise(function(resolve, reject) {
                var result = null;
                $.ajax({
                    type: 'DELETE',
                    url: url
                })
                .then(function(data) {
                    result = data;
                })
                .fail(function(response) {
                    toastr.error('An error ocurred', 'Oops!', {timeOut: 5000});
                })
                .always(function(data) {
                    resolve(result);
                });
            });
        },
        save: function(url, entitity) {
            return new Promise(function(resolve, reject) {
                var result = null;
                var request = {
                    type: 'POST',
                    url: url,
                    contentType: 'application/json',
                    data: JSON.stringify(entitity)
                };

                if (entitity.Id !== 0) {
                    request.type = 'PUT';
                }

                $.ajax(request)
                .then(function(data) {
                    result = data;
                })
                .fail(function(response) {
                    toastr.error('An error ocurred', 'Oops!', {timeOut: 5000});
                })
                .always(function(data) {
                    resolve(result);
                });
            });
        }
    };
})();