$(document).ready(function () {
    getPreparedRecipes(getUserEmail(), findGetParameter('recipeId'), findGetParameter('recipeName'));
    displayActionPanel(["back"]);
});