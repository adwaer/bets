window.helpers = new function () {

    this.convertDateStringsToDates = function (input) {
        // Ignore things that aren't objects.
        if (typeof input !== "object") return input;

        for (var key in input) {
            if (!input.hasOwnProperty(key)) continue;

            var value = input[key];
            var match;
            // Check for string properties which look like dates.
            if (typeof value === "string" && value.length == 19 && value[4] == '-' && value[7] == '-' && value[10] == 'T') {
                value = value.substring(0, 16);
                input[key] = new Date(value);

            } else if (typeof value === "object") {
                // Recurse into object
                this.convertDateStringsToDates(value);
            }
        }
    }

};