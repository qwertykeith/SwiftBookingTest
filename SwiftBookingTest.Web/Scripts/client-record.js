function ClientRecord(model) {
	var self = this

	model = model || {}

	self.name = ko.observable('')
	self.phone = ko.observable('')
	self.address = ko.observable(model.address || '')
	self.isBooked = ko.observable(model.isBooked || '')
	self.id = ko.observable(model.id || null)
	self.isBooking = ko.observable(false)

	self.canAdd = ko.computed(function() {
		return !self.id() && self.name() && self.phone() && self.address() && !self.isBooking()
	})

	self.book = function($parent) {
		if (!self.id()) {
			alert("Cannot book this record as it hasn't been saved")
			return
		}
		self.isBooking(true)
		$
			.post('/api/BookClientRecord', {
				id: self.id()
			})
			.then(
				function(response) {
					self.isBooked(true)
					$parent.bookedResponse(ko.toJSON(response, null, 2))
				},
				function(error) {
					var errorResponse = JSON.parse(error.responseText)
					
					if (!!errorResponse.code && !!errorResponse.message) {
						alert('Could not book client record: ' + errorResponse.code + ' - ' + errorResponse.message)
						$parent.bookedResponse(ko.toJSON(errorResponse, null, 2))
					} else {
						alert('Could not book client record: ' + error.statusText + ' - ' + error.responseText)
					}
				}
			)
			.always(function() {
				self.isBooking(false)
			})
		
	}

	self.toAddModel = function() {
		return {
			name: self.name(),
			phone: self.phone(),
			address: self.address(),
			id: self.id()
		}
	}
}
