(function() {

  $(function() {
    $(".dropdown-menu .all").click(function() {
      var all, checkboxes;
      all = $(this);
      checkboxes = all.parents(".multi-dropdown").find("input");
      if (all.attr("checked")) {
        return checkboxes.attr("checked", "checked");
      } else {
        return checkboxes.removeAttr("checked");
      }
    });
    $(".dropdown-menu input").click(function() {
      var all, checkboxes;
      checkboxes = $(this).parents(".multi-dropdown").find("input");
      all = checkboxes.filter(".all");
      if (checkboxes.not(".all").is(":not(:checked)")) {
        return all.removeAttr("checked");
      } else {
        return all.attr("checked", "checked");
      }
    });
    return $(".dropdown-menu input, .dropdown-menu label").click(function(e) {
      var caption, dropdown, text;
      dropdown = $(this).parents(".multi-dropdown");
      caption = "";
      text = dropdown.find(":checked").not(".all").map(function() {
        return $(this).parent().find("label").text();
      }).get().join(", ");
      dropdown.find(".title").text(text.length ? text : "N/A");
      return e.stopPropagation();
    });
  });

}).call(this);
