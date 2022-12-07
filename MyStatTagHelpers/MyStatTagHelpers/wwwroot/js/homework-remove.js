$(function () {
	let $buttonDelete = $(".button-remove");
	let $container = $(".container-my");

	$buttonDelete.on("click", function (e) {

		let $that = $(this);
		$.ajax({
			url: "/HomeWork/Remove",
			contentType: "application/json",
			data: JSON.stringify({
				id: $that.attr("data-id")
			}),
			type: "POST",
			success: function () {
				$container.remove(`[data-id="${$that.attr("data-id")}"]`);
				alert("Removed");
				;
			}
		});

		
	});
});