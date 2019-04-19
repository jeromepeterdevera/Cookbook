using Cookbook.WebApi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Interactors
{
    public interface IRecipeInteractor
    {
        int CreateNewRecipe(int cookId, Recipe recipe);

        int CreateNewRecipe(string email, Recipe recipe);

        int PrepareRecipe(int cookId, int recipeId, PreparedRecipe preparedRecipe);

        int PrepareRecipe(string email, int recipeId, PreparedRecipe preparedRecipe);

        int PrepareRecipe(int cookId, string recipeName, PreparedRecipe preparedRecipe);

        int PrepareRecipe(string email, string recipeName, PreparedRecipe preparedRecipe);

        void AddIngredientToPreparedRecipe(int preparedRecipeId, Ingredient ingredient);

        void RemoveIngredientFromPreparedRecipe(int preparedRecipeId, Ingredient ingredient);

        PreparedRecipe FinishRecipePreparation(int preparedRecipeId);

        Recipe GetRecipe(int cookId, string recipeName);

        Recipe GetRecipe(int recipeId);

        Recipe GetRecipe(string email, string recipeName);

        PreparedRecipe GetPreparedRecipe(int preparedRecipeId);

        PreparedRecipe GetPreparedRecipe(int cookId, int recipeId, int preparedRecipeId);

        PreparedRecipe GetInProgressPreparedRecipe(int recipeId);

        PreparedRecipe GetInProgressPreparedRecipe(string email, string recipeName);

        IEnumerable<Recipe> GetAllRecipes();

        IEnumerable<PreparedRecipe> GetPreparedRecipesByCookIdAndRecipeId(int cookId, int recipeId);

        Recipe GetRecipe(string email, int recipeId);

        Recipe GetRecipe(int id, int recipeId);

        void RemoveIngredientFromPreparedRecipe(int id, int recipeId, int preparedRecipeId, Ingredient ingredient);

        void AddIngredientToPreparedRecipe(int id, int recipeId, int preparedRecipeId, Ingredient ingredient);

        PreparedRecipe FinishRecipePreparation(int id, int recipeId, PreparedRecipe preparedRecipeToComplete);

        PreparedRecipe GetInProgressPreparedRecipe(int cookId, int recipeId);

        IEnumerable<PreparedRecipe> GetPreparedRecipesByCookAndRecipeId(string email, int recipeId);
    }
}
