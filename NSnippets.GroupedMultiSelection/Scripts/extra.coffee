$ ->

	# allow click on multiple checkboxes in single dropdown
	$(".dropdown-menu input, .dropdown-menu label").click (e) -> 
		dropdown = $(this).parents(".multi-dropdown")
		caption = ""
		text = dropdown
			.find(":checked")
			.map(-> $(this).parent().find("label").text())
			.get()
			.join(", ")
		dropdown.find(".title").text(if text.length then text else "N/A")
		e.stopPropagation()