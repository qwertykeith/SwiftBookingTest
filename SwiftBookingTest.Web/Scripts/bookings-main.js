
/**
 * GetSwift namespace.
 */
var GetSwift = {

	//Simple function to call the Booking Submit function.
	//Returns a JSON blob and outputs the information raw.
	//The error and success handling would need to fleshed out significantly before production use.
	submitBookingRequest: function (id) {
		$.ajax({
			url: "/Booking/Submit",
			type: "post",
			data: { "id" : id } ,
			success: function (response) {
				$("#result").append(response);
			},
			error: function (jqXHR, textStatus, errorThrown) {
				alert("An error occurred while attempting to process your request.");
				console.log(textStatus, errorThrown);
			}
		});
	}
};