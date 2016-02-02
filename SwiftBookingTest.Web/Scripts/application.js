function Application() {
	var self = this

	self.newRecord = ko.observable(new ClientRecord())
	self.records = ko.observableArray([])
	self.isLoading = ko.observable(true)
	self.isAdding = ko.observable(false)
	self.bookedResponse = ko.observable('')
	
	$
		.get('/api/GetClientRecords')
		.then(
			function(records) {
					records.forEach(function(model) {
					self.records.push(new ClientRecord(model))
				})
			},
			function(error) {
				alert('Could not load client records: ' + error.statusText + ' - ' + error.responseText)
			}
		)
		.always(function() {
			self.isLoading(false)
		})



	self.addPerson = function() {
		if (!self.newRecord().canAdd()) {
			alert('Cannot add the new record in the current state')
			return
		}

		self.isAdding(true)
		$
			.post('/api/AddClientRecord', self.newRecord().toAddModel())
			.then(
				function(id) {
					self.newRecord().id(id)
					self.records.push(self.newRecord())
					self.newRecord(new ClientRecord())
				},
				function(error) {
					alert('Could not add client record: ' + error.statusText + ' - ' + error.responseText)
				}
			)
			.always(function() {
				self.isAdding(false)
			})
	}
}

$(function() {
	ko.applyBindings(new Application(), document.getElementById('app'))
})