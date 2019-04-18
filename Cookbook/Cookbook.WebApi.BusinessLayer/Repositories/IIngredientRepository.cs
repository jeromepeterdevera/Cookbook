using Cookbook.WebApi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Repositories
{
    public interface IIngredientRepository
    {
        int Insert(Ingredient ingredient);

        void Insert(IEnumerable<Ingredient> ingredients);

        Ingredient GetIngredientByName(string ingredientName);

        IEnumerable<Ingredient> GetIngredientsByRecipeName(string recipeName);

        IEnumerable<Ingredient> GetAllIngredients();

        Ingredient GetIngredientById(int ingredientId);

        IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId);
    }
}
