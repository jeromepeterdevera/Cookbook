using Cookbook.WebApi.BusinessLayer.Models;
using Cookbook.WebApi.BusinessLayer.Repositories;
using DAL = Cookbook.WebApi.DataAccessLayer.Models;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using System.Collections.Generic;
using System.Linq;
using Cookbook.WebApi.BusinessLayer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.WebApi.DataAccessLayer.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookbookDbContext cookbookDbContext;

        public RecipeRepository(CookbookDbContext cookbookDbContext)
        {
            this.cookbookDbContext = cookbookDbContext;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            var recipes = this.cookbookDbContext.recipes;

            if (recipes is null || !recipes.Any())
                throw new RecordNotFoundException($"No record found.");

            var retrievedRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                var ingredients = this.cookbookDbContext.recipeIngredients.Where(ri => ri.RecipeId == recipe.RecipeId)
                    .Select(ri => new Ingredient
                    {
                        IngredientId = ri.IngredientId,
                        Name = ri.Ingredient.Name
                    });

                retrievedRecipes.Add(new Recipe
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Ingredients = ingredients.ToList()
                });
            }

            return retrievedRecipes;
        }

        public Recipe GetRecipeByName(string recipeName)
        {
            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.Name == recipeName);

            if (recipe is null)
                throw new RecordNotFoundException($"No record found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                .Where(ri => ri.RecipeId == recipe.RecipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.IngredientId,
                    Name = ri.Ingredient.Name
                });

            return new Recipe
            {
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingredients = ingredients.ToList()
            };
        }

        public Recipe GetRecipeByIdAndCookId(int recipeId, int cookId)
        {
            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.RecipeId == recipeId && r.CookId == cookId);

            if (recipe is null)
                throw new RecordNotFoundException($"No record found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                .Where(ri => ri.RecipeId == recipe.RecipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.IngredientId,
                    Name = ri.Ingredient.Name
                });

            return new Recipe
            {
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingredients = ingredients.ToList()
            };
        }

        public Recipe GetRecipeByNameAndCookId(string recipeName, int cookId)
        {
            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.Name == recipeName && r.CookId == cookId);

            if (recipe is null)
                throw new RecordNotFoundException($"No record found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                .Where(ri => ri.RecipeId == recipe.RecipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.IngredientId,
                    Name = ri.Ingredient.Name
                });

            return new Recipe
            {
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingredients = ingredients.ToList()
            };
        }

        public Recipe GetRecipeByNameAndCook(string recipeName, string email)
        {
            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.Name == recipeName && r.Cook.Email == email);

            if (recipe is null)
                throw new RecordNotFoundException($"No record found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                .Where(ri => ri.RecipeId == recipe.RecipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.IngredientId,
                    Name = ri.Ingredient.Name
                });

            return new Recipe
            {
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingredients = ingredients.ToList()
            };
        }

        public Recipe GetRecipeByIdAndCook(int recipeId, string email)
        {
            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.RecipeId == recipeId && r.Cook.Email == email);

            if (recipe is null)
                throw new RecordNotFoundException($"No record found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                .Where(ri => ri.RecipeId == recipe.RecipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.IngredientId,
                    Name = ri.Ingredient.Name
                });

            return new Recipe
            {
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingredients = ingredients.ToList()
            };
        }

        public IEnumerable<Recipe> GetRecipesByCook(string email)
        {
            var recipes = this.cookbookDbContext.recipes.Where(r => r.Cook.Email == email);

            if (recipes is null || !recipes.Any())
                throw new RecordNotFoundException($"No record found.");

            var retrievedRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                    .Where(ri => ri.RecipeId == recipe.RecipeId)
                    .Select(ri => new Ingredient
                    {
                        IngredientId = ri.IngredientId,
                        Name = ri.Ingredient.Name
                    });

                retrievedRecipes.Add(new Recipe
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Ingredients = ingredients.ToList()
                });
            }

            return retrievedRecipes;
        }

        public IEnumerable<Recipe> GetRecipesByCookId(int id)
        {
            var recipes = this.cookbookDbContext.recipes.Where(r => r.CookId == id);

            if (recipes is null || !recipes.Any())
                throw new RecordNotFoundException($"No record found.");

            var retrievedRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                    .Where(ri => ri.RecipeId == recipe.RecipeId)
                    .Select(ri => new Ingredient
                    {
                        IngredientId = ri.IngredientId,
                        Name = ri.Ingredient.Name
                    });

                retrievedRecipes.Add(new Recipe
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Ingredients = ingredients.ToList()
                });
            }

            return retrievedRecipes;
        }

        public int Insert(int cookId, Recipe recipe)
        {
            if (this.cookbookDbContext.recipes.Any(r => r.Name == recipe.Name && r.CookId == cookId))
                throw new RecordAlreadyExistException($"Record already exists.");

            DAL.Recipe newRecipe = new DAL.Recipe
            {
                Name = recipe.Name,
                Description = recipe.Description,
                CookId = cookId
            };

            this.cookbookDbContext.recipes.Add(newRecipe);

            return newRecipe.RecipeId;
        }

        public int Insert(string email, Recipe recipe)
        {
            if (this.cookbookDbContext.recipes.Any(r => r.Name == recipe.Name && r.Cook.Email == email))
                throw new RecordAlreadyExistException($"Record already exists.");

            DAL.Cook cook = this.cookbookDbContext.cooks.FirstOrDefault(c => c.Email == email);
            if (cook is null)
                throw new RecordNotFoundException("Record not found.");

            DAL.Recipe newRecipe = new DAL.Recipe
            {
                Name = recipe.Name,
                Description = recipe.Description,
                CookId = cook.CookId
            };

            this.cookbookDbContext.recipes.Add(newRecipe);

            return newRecipe.RecipeId;
        }

        public void RelateIngredientsToRecipe(IEnumerable<Ingredient> ingredients, int recipeId)
        {
            foreach (var ingredient in ingredients)
            {
                DAL.Ingredient retrievedIngredient = this.cookbookDbContext.ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
                if (retrievedIngredient is null)
                    throw new RecordNotFoundException("Record not found.");

                this.cookbookDbContext.recipeIngredients.Add(new DAL.RecipeIngredient
                {
                    IngredientId = retrievedIngredient.IngredientId,
                    RecipeId = recipeId
                });
            }
        }

        public Recipe GetRecipeById(int recipeId)
        {
            DAL.Recipe recipe = this.cookbookDbContext.recipes.Find(recipeId);

            if (recipe is null)
                throw new RecordNotFoundException($"No record found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.recipeIngredients
                .Where(ri => ri.RecipeId == recipe.RecipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.IngredientId,
                    Name = ri.Ingredient.Name
                });

            return new Recipe
            {
                RecipeId = recipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Ingredients = ingredients.ToList()
            };
        }
    }
}
