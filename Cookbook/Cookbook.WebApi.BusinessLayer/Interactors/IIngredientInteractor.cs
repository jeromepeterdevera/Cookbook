using Cookbook.WebApi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Interactors
{
    public interface IIngredientInteractor
    {
        void AddIngredient(Ingredient ingredient);

        void AddIngredients(IEnumerable<Ingredient> ingredients);

        Ingredient GetIngredient(string ingredientName);

        Ingredient GetIngredient(int ingredientId);

        IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId);

        IEnumerable<Ingredient> GetIngredientsByRecipe(string recipeName);

        IEnumerable<Ingredient> GetAllIngredients();
    }
}
