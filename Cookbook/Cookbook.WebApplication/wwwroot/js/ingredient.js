$(document).ready(function () {
    const createIngredientURI = "https://localhost:44395/api/Ingredients/AddMultiple";

    displayAvailableIngredients("#top-left-panel-body");
    displayActionPanel(["back", "add"]);
    displayAddIngredientForm();

    $('#add-ingredient-link').show();
    $('#ingredient-add-form').hide();

    $("#cookbook-container").on('click', '#cancelIngredient', function (ev) {
        $('#add-ingredient-link').show();
        $('#ingredient-add-form').hide();
    });

    $("#cookbook-container").on('click', '#add-ingredient-link', function (ev) {
        event.preventDefault();
        $('#add-ingredient-link').hide();
        $('#ingredient-add-form').show();
    });

    $("#cookbook-container").on('click', '.add-more-ingredient', function (ev) {
        event.preventDefault();

        $('#add-ingredient-name-template .ingredient-name').clone().appendTo(".ingredient-main-container");
    });

    $("#cookbook-container").on('click', '#addIngredient', function (ev) {
        let ingredients = _.map($(".ingredient-main-container .ingredient-name"), function (obj) { return { name: $(obj).val().trim() }; });

        $.ajax({
            type: "POST",
            url: createIngredientURI,
            contentType: "application/json",
            data: JSON.stringify(ingredients),
            success: function (data) {
                window.location = "/ingredient";
            },
            error: function (jqXHR, textStatus, errorThrown) {
                let errors = _.map(jqXHR.responseJSON.errors, function (val) { return "<p class'error-msg'> * " + val.join(", ") + "</p>"; });
                let errorMessage = "<p class='error-msg-title'>Following errors occured:</p>" + errors.join("");
                displayErrorMessage(errorMessage);
            }
        });
    });

});