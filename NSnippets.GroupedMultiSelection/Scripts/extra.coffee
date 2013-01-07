$ ->

	# TODO merge first two handlers and simplify impl.
	
	# enable "all" checkbox
	$(".dropdown-menu .all").click ->
		all = $(this)
		checkboxes = all.parents(".multi-dropdown").find("input")
		if all.attr("checked")
			checkboxes.attr("checked", "checked")
		else
			checkboxes.removeAttr("checked")

	# remove all when some of checkboxes was set to "false"
	$(".dropdown-menu input").click ->
		checkboxes = $(this).parents(".multi-dropdown").find("input")
		all = checkboxes.filter(".all")
		if checkboxes.not(".all").is(":not(:checked)")
			all.removeAttr("checked")
		else
			all.attr("checked", "checked")			

	# allow click on multiple checkboxes in single dropdown
	# update title
	$(".dropdown-menu input, .dropdown-menu label").click (e) -> 
		dropdown = $(this).parents(".multi-dropdown")
		caption = ""
		text = dropdown
			.find(":checked")
			.not(".all")
			.map(-> $(this).parent().find("label").text())
			.get()
			.join(", ")
		dropdown.find(".title").text(if text.length then text else "N/A")
		e.stopPropagation()