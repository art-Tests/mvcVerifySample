$.validator.addMethod("banword", function (value, element, param) {
	if (value == false) {
	    return true;
	}
	var username = value.split("@")[0];
	var ary = param.split(",");

	for (var i = 0 ; i < ary.length; i++) {
	    if (username.indexOf(ary[i]) != -1) {
	        return false;
	    }
	}
	return true;
});
$.validator.unobtrusive.adapters.addSingleVal("banword", "input");
