$(document).ready(function () {
    const createRecipeURI = "https://localhost:44395/api/Cooks/" + getUserEmail() + "/Recipes";

    displayAddRecipeForm();
    displayAvailableIngredients('#top-right-panel-body');

    $("#cookbook-container").on('click', '.list-group-item', function (ev) {
        let $el = $(ev.currentTarget);

        if ($el.hasClass("add-ingredient")) {
            window.location = "/ingredient";
            return false;
        }

        if (!$el.hasClass('selected')) {
            $('#ingredient-reminder').text('');
            $el.addClass('selected');
            $el.appendTo('#selected-ingredient-list');
        } else {
            $el.removeClass('selected');
            $el.prependTo('#ingredients-list-panel');

            
            if ($('#selected-ingredient-list .list-group-item').length < 1) $('#ingredient-reminder').text('Select from the available ingredients.');
        }
    });

    $("#cookbook-container").on('click', '#backRecipe', function (ev) {
        window.location = "/recipe";
    });

    $("#cookbook-container").on('click', '#addRecipe', function (ev) {
        let ingredientIds = _.map($("#selected-ingredient-list .list-group-item"), function (obj) { return { ingredientId: $(obj).data("ingredient-id"), name: $(obj).text().trim() }; });
        let payload = {
            name: $("#recipe-name").val().trim(),
            description: $("#recipe-description").val().trim(),
            ingredients: ingredientIds
        };


        $.ajax({
            type: "POST",
            url: createRecipeURI,
            contentType: "application/json",
            data: JSON.stringify(payload),
            success: function (data) {
                window.location = "/recipe";
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
            }
        });
    });

});