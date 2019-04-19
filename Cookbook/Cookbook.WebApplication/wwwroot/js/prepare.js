function createPrepareRecipeRecord(cookId, recipeId) {
    let createPrepareRecipeURI = "https://localhost:44395/api/Cooks/"+cookId+"/Recipes/"+recipeId+"/PreparedRecipes";
    let payload = {
        complete: false
    };


    return $.ajax({
        type: "POST",
        url: createPrepareRecipeURI,
        contentType: "application/json",
        data: JSON.stringify(payload)
    });
}

function addIngredient(ingredientName, cookId, recipeId, preparedRecipeId) {
    let payload = {
        name: ingredientName
    };


    $.ajax({
        type: "POST",
        url: "https://localhost:44395/api/Cooks/" + cookId + "/Recipes/" + recipeId + "/PreparedRecipes/" + preparedRecipeId + "/Ingredients",
        contentType: "application/json",
        data: JSON.stringify(payload),
        success: function (data) {
            console.log('Success', data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            displayErrorMessage(textStatus);
        }
    });
}

function removeIngredient(ingredientName, cookId, recipeId, preparedRecipeId) {
    let payload = {
        name: ingredientName
    };


    $.ajax({
        type: "DELETE",
        url: "https://localhost:44395/api/Cooks/" + cookId + "/Recipes/" + recipeId + "/PreparedRecipes/" + preparedRecipeId + "/Ingredients",
        contentType: "application/json",
        data: JSON.stringify(payload),
        success: function (data) {
            console.log('Success', data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            displayErrorMessage(textStatus);
        }
    });
}

$(document).ready(function () {
    let preparedRecipeId, cookId, recipeId;

    getCookId().then(function (data) {
        cookId = data.cookId;
        const prepareRecipeId = findGetParameter('prepareRecipeId');
        recipeId = findGetParameter('recipeId');

        if (!prepareRecipeId) {
            createPrepareRecipeRecord(cookId, recipeId).then(function (data) {
                preparedRecipeId = data.preparedRecipeId;

                displayAddRecipeForm();
                displayRecipeIngredients('#top-right-panel-body', recipeId, cookId);
            });
        }

        if (prepareRecipeId) {
            preparedRecipeId = prepareRecipeId;

            displayAddRecipeForm();
            displayRecipeIngredients('#top-right-panel-body', recipeId, cookId);
            displayPreparedIngredients(cookId, recipeId, prepareRecipeId);
        }
    });


    $("#cookbook-container").on('click', '.list-group-item', function (ev) {
        let $el = $(ev.currentTarget);

        if (!$el.hasClass('selected')) {
            $('#ingredient-reminder').text('');
            $el.addClass('selected');
            $el.appendTo('#selected-ingredient-list');

            addIngredient($el.text(), cookId, recipeId, preparedRecipeId);
        } else {
            $el.removeClass('selected');
            $el.prependTo('#ingredients-list-panel');

            
            if ($('#selected-ingredient-list .list-group-item').length < 1) $('#ingredient-reminder').text('Select from the recipe ingredients.');

            removeIngredient($el.text(), cookId, recipeId, preparedRecipeId);
        }
    });

    $("#cookbook-container").on('click', '#backRecipe', function (ev) {
        window.location = "/recipe";
    });

    $("#cookbook-container").on('click', '#setToDonePrepareRecipe', function (ev) {
        let payload = {
            alias: $("#recipe-name").val().trim(),
            preparedrecipeid: preparedRecipeId
        };


        $.ajax({
            type: "PUT",
            url: "https://localhost:44395/api/Cooks/" + cookId + "/Recipes/" + recipeId + "/PreparedRecipes/" + preparedRecipeId,
            contentType: "application/json",
            data: JSON.stringify(payload),
            success: function (data) {
                window.location = "/recipe";
            },
            error: function (jqXHR, textStatus, errorThrown) {
                let error = "<p class'error-msg'> * " + jqXHR.responseText + "</p>";
                let errorMessage = "<p class='error-msg-title'>Following errors occured:</p>" + error;
                displayErrorMessage(errorMessage);
            }
        });
    });

});