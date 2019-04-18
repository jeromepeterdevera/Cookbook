// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const cooksUri = "https://localhost:44395/api/Cooks";
const ingredientsUri = "https://localhost:44395/api/Ingredients";
let todos = null;
let chef = null;
let recipes = null;


function getUserEmail() {
    return $('#UserEmail').val().trim();
}

function getCookId() {
    return $.ajax({
        type: "GET",
        url: cooksUri.concat('/', getUserEmail())
    });
}

function getCookData() {
    // THIS WILL GET THE RECIPES and COOK Name, Email
    let $containerSource = $("#recipes-container-template").html();
    let $containerTemplate = Handlebars.compile($containerSource);
    $('#top-left-panel-body').append($containerTemplate);

    // compile cook handlebar
    let $recipesList = $('#recipes-list');
    let $recipeItem = $("#recipes-item-template").html();
    let $recipeItemTemplate = Handlebars.compile($recipeItem);

    // compile cook handlebar
    let $cookName = $("#top-left-panel-header-template").html();
    let $cookNameTemplate = Handlebars.compile($cookName);

    // compile ingredients handlebar
    let $ingredient = $("#ingredients-item-template").html();
    let $ingredientTemplate = Handlebars.compile($ingredient);

    $.ajax({
        type: "GET",
        url: cooksUri.concat('/', getUserEmail()),
        success: function (data) {
        
            $('#top-left-panel-header').append($cookNameTemplate(data));
            
            $.each(data.recipes, function (index, recipe) {

                let inProgressRecipe = _.find(recipe.preparedRecipes, function (recipe) { return recipe.complete === false; });
                if (inProgressRecipe) {
                    recipe['haveInProgressPreparation'] = "true";
                    recipe['inProgressRecipeId'] = inProgressRecipe.preparedRecipeId;
                } else {
                    recipe['noInProgressPreparation'] = "true";
                }

                let $recipe = $recipeItemTemplate(recipe);
                $recipesList.append($recipe);

                $.each(recipe.ingredients, function (index, ingredient) {
                    let $ingredient = $ingredientTemplate(ingredient);

                    $($ingredient).appendTo("#ingredients-recipe-" + recipe.recipeId);
                });
            });
        }
    });
}

function getCook(email) {
    $.ajax({
        type: "GET",
        url: cooksUri.concat('/', email),
        success: function (data) {
            console.log(data);
        }
    });
}

function addCook() {
    const cook = {
        firstname: $("#Input_FirstName").val(),
        lastname: $("#Input_LastName").val(),
        email: $("#Input_Email").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: cooksUri,
        contentType: "application/json",
        data: JSON.stringify(cook),
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("something went wrong.");
        },
        success: function (result) {
            getCook(cook.email);
        }
    });
}

function displayActionPanel(types) {
    let actionTypes = {};
    $.each(types, function (i, txt) {
        actionTypes[txt] = "true";
    });

    let $actionPanel = $("#recipe-actions-template").html();
    let $actionPanelTemplate = Handlebars.compile($actionPanel);
    let $actions = $actionPanelTemplate(actionTypes);

    $('#top-right-panel-body').append($actions);
}

function displayAddRecipeForm() {
    let $addRecipe = $("#top-left-panel-body-template").html();
    let $addRecipeTemplate = Handlebars.compile($addRecipe);
    let $addRecipeForm = $addRecipeTemplate();

    $('#top-left-panel-body').append($addRecipeForm);
}

function displayAvailableIngredients(location) {
    let $ingredientsPanel = $("#ingredients-list-panel-template").html();
    let $ingredientsPanelTemplate = Handlebars.compile($ingredientsPanel);
    let $ingredientsPanelContainer = $ingredientsPanelTemplate();

    $(location).append($ingredientsPanelContainer);


    let $ingredientItem = $("#ingredients-item-template").html();
    let $ingredientItemTemplate = Handlebars.compile($ingredientItem);

    $.ajax({
        type: "GET",
        url: ingredientsUri,
        success: function (data) {
            $.each(data, function (i, ingredient) {
                let $ingredientItemContainer = $ingredientItemTemplate(ingredient);
                $("#ingredients-list-panel").append($ingredientItemContainer);
            });
            
        }
    });
}

function displayRecipeIngredients(location, recipeId, cookId) {
    const recipeIngredientsURI = "https://localhost:44395/api/Cooks/" + cookId + "/recipes/" + recipeId;

    let $recipeIngredientsPanel = $("#ingredients-list-panel-template").html();
    let $recipeIngredientsTemplate = Handlebars.compile($recipeIngredientsPanel);
    let $recipeIngredientsContainer = $recipeIngredientsTemplate();

    $(location).append($recipeIngredientsContainer);


    let $ingredientItem = $("#ingredients-item-template").html();
    let $ingredientItemTemplate = Handlebars.compile($ingredientItem);

    $.ajax({
        type: "GET",
        url: recipeIngredientsURI,
        success: function (data) {
            $("#recipe-name").val(data.name);
            $.each(data.ingredients, function (i, ingredient) {
                let $ingredientItemContainer = $ingredientItemTemplate(ingredient);
                $("#ingredients-list-panel").append($ingredientItemContainer);
            });

        }
    });
}

function displayPreparedIngredients(cookId, recipeId, prepareRecipeId) {
    let getPrepairedIngredientsURI = "https://localhost:44395/api/Cooks/" + cookId + "/Recipes/" + recipeId + "/PreparedRecipes/" + prepareRecipeId;
    let $preparedIngredientItem = $("#ingredients-item-template").html();
    let $preparedIngredientItemTemplate = Handlebars.compile($preparedIngredientItem);

    $.ajax({
        type: "GET",
        url: getPrepairedIngredientsURI,
        success: function (data) {
            if (data.ingredients && data.ingredients.length > 0) {
                $('#ingredient-reminder').text('');

                $.each(data.ingredients, function (i, ingredient) {

                    $("#ingredients-list-panel #ingredient-" + ingredient.ingredientId).remove();
                    let $ingredientItemContainer = $preparedIngredientItemTemplate(ingredient);
                    $("#selected-ingredient-list").append($ingredientItemContainer);
                });

                $("#selected-ingredient-list .list-group-item").addClass("selected");
            }



        }
    });
}

function displayAddIngredientForm() {
    let $addIngredient = $("#add-ingredient-template").html();
    let $addIngredientTemplate = Handlebars.compile($addIngredient);
    let $addIngredientForm = $addIngredientTemplate();

    $('#top-right-panel-body').append($addIngredientForm);
}