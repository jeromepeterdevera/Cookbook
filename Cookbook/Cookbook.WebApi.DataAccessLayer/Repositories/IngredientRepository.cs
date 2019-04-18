using Cookbook.WebApi.BusinessLayer.Models;
using Cookbook.WebApi.BusinessLayer.Repositories;
using DAL = Cookbook.WebApi.DataAccessLayer.Models;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.WebApi.BusinessLayer.Exceptions;

namespace Cookbook.WebApi.DataAccessLayer.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly CookbookDbContext cookbookDbContext;

        public IngredientRepository(CookbookDbContext cookbookDbContext)
        {
            this.cookbookDbContext = cookbookDbContext;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            var ingredients = this.cookbookDbContext.ingredients;

            if (ingredients is null || !ingredients.Any())
                throw new RecordNotFoundException("No record found.");

            var retrieveIngredients = new List<Ingredient>();
            foreach (var ingredient in ingredients)
            {
                retrieveIngredients.Add(new Ingredient
                {
                    IngredientId = ingredient.IngredientId,
                    Name = ingredient.Name
                });
            }
            return retrieveIngredients;
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            DAL.Ingredient ingredient = this.cookbookDbContext.ingredients
                .FirstOrDefault(i => i.IngredientId == ingredientId);

            if (ingredient is null)
                throw new RecordNotFoundException($"No record found.");

            return new Ingredient
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name
            };
        }

        public Ingredient GetIngredientByName(string ingredientName)
        {
            DAL.Ingredient ingredient = this.cookbookDbContext.ingredients
                .FirstOrDefault(i => i.Name == ingredientName);

            if (ingredient is null)
                throw new RecordNotFoundException($"No record found.");

            return new Ingredient
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name
            };
        }

        public IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            var ingredients = this.cookbookDbContext.recipeIngredients.Where(ri => ri.RecipeId == recipeId)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.Ingredient.IngredientId,
                    Name = ri.Ingredient.Name
                });
            if (ingredients is null || !ingredients.Any())
                throw new RecordNotFoundException($"No record found.");

            return ingredients;
        }

        public IEnumerable<Ingredient> GetIngredientsByRecipeName(string recipeName)
        {
            var ingredients = this.cookbookDbContext.recipeIngredients.Where(ri => ri.Recipe.Name == recipeName)
                .Select(ri => new Ingredient
                {
                    IngredientId = ri.Ingredient.IngredientId,
                    Name = ri.Ingredient.Name
                });
            if (ingredients is null || !ingredients.Any())
                throw new RecordNotFoundException($"No record found.");

            return ingredients;
        }

        public int Insert(Ingredient ingredient)
        {
            if (this.cookbookDbContext.ingredients.Any(i => i.Name == ingredient.Name))
                throw new RecordAlreadyExistException("Record already exist.");

            DAL.Ingredient newIngredient = new DAL.Ingredient
            {
                Name = ingredient.Name
            };

            this.cookbookDbContext.ingredients.Add(newIngredient);

            return newIngredient.IngredientId;
        }

        public void Insert(IEnumerable<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                this.Insert(ingredient);
            }
        }
    }
}
