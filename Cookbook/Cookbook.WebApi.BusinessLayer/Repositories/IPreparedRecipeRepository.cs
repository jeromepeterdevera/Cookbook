using Cookbook.WebApi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Repositories
{
    public interface IPreparedRecipeRepository
    {
        int Insert(int cookId, int recipeId, PreparedRecipe preparedRecipe);

        int Insert(int cookId, string recipeName, PreparedRecipe preparedRecipe);

        int Insert(string email, int recipeId, PreparedRecipe preparedRecipe);

        int Insert(string email, string recipeName, PreparedRecipe preparedRecipe);

        IEnumerable<PreparedRecipe> GetPreparedRecipes(int recipeId);

        IEnumerable<PreparedRecipe> GetPreparedRecipes(int cookId, string recipeName);

        IEnumerable<PreparedRecipe> GetPreparedRecipes(string email, int recipeId);

        IEnumerable<PreparedRecipe> GetPreparedRecipes(string email, string recipeName);

        PreparedRecipe GetPreparedRecipe(int preparedRecipeId);

        void AddIngredient(int cookId, int recipeId, int preparedRecipeId, string ingredientName);

        PreparedRecipe GetInProgressRecipe(int recipeId);

        PreparedRecipe GetInProgressRecipe(string email, string recipeName);

        void AddIngredient(int preparedRecipeId, string ingredientName);

        void RemoveIngredient(int preparedRecipeId, string ingredientName);

        PreparedRecipe FinishRecipePreparation(int preparedRecipeId);

        IEnumerable<PreparedRecipe> GetPreparedRecipes(int cookId, int recipeId);

        PreparedRecipe FinishRecipePreparation(int cookId, int recipeId, PreparedRecipe preparedRecipeToComplete);

        void RemoveIngredient(int cookId, int recipeId, int preparedRecipeId, string ingredientName);

        PreparedRecipe GetPreparedRecipe(int cookId, int recipeId, int preparedRecipeId);

        PreparedRecipe GetInProgressRecipe(int cookId, int recipeId);
    }
}
