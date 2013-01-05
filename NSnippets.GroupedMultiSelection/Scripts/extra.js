(function() {

  $(function() {
    return $(".dropdown-menu input, .dropdown-menu label").click(function(e) {
      var caption, dropdown, text;
      dropdown = $(this).parents(".multi-dropdown");
      caption = "";
      text = dropdown.find(":checked").map(function() {
        return $(this).parent().find("label").text();
      }).get().join(", ");
      dropdown.find(".title").text(text.length ? text : "N/A");
      return e.stopPropagation();
    });
  });

}).call(this);
