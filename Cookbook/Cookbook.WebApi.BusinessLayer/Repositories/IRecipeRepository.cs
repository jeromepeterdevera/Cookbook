using Cookbook.WebApi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.WebApi.BusinessLayer.Repositories
{
    public interface IRecipeRepository
    {
        int Insert(int cookId, Recipe recipe);

        int Insert(string email, Recipe recipe);

        void RelateIngredientsToRecipe(IEnumerable<Ingredient> ingredients, int recipeId);

        Recipe GetRecipeById(int recipeId);

        Recipe GetRecipeByNameAndCook(string recipeName, string email);

        Recipe GetRecipeByNameAndCookId(string recipeName, int cookId);

        Recipe GetRecipeByIdAndCookId(int recipeId, int cookId);

        Recipe GetRecipeByIdAndCook(int recipeId, string email);

        IEnumerable<Recipe> GetRecipesByCook(string email);

        IEnumerable<Recipe> GetRecipesByCookId(int id);

        IEnumerable<Recipe> GetAllRecipes();
    }
}
