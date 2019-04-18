using Cookbook.WebApi.BusinessLayer.Exceptions;
using Cookbook.WebApi.BusinessLayer.Models;
using Cookbook.WebApi.BusinessLayer.Repositories;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using DAL = Cookbook.WebApi.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Repositories
{
    public class PreparedRecipeRepository : IPreparedRecipeRepository
    {
        private readonly CookbookDbContext cookbookDbContext;

        public PreparedRecipeRepository(CookbookDbContext cookbookDbContext)
        {
            this.cookbookDbContext = cookbookDbContext;
        }

        public PreparedRecipe GetInProgressRecipe(string email, string recipeName)
        {
            PreparedRecipe preparedRecipe = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.Recipe.Name == recipeName &&
                pr.Cook.Email == email &&
                !pr.Complete)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                }).FirstOrDefault();

            if (preparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                pri => pri.PreparedRecipe.Recipe.Name == recipeName &&
                pri.PreparedRecipe.Cook.Email == email &&
                !pri.PreparedRecipe.Complete)
                .Select(pri => new Ingredient
                {
                    IngredientId = pri.IngredientId,
                    Name = pri.Ingredient.Name
                }).ToList();

            if (ingredients.Any())
                preparedRecipe.Ingredients = ingredients;

            return preparedRecipe;
        }

        public PreparedRecipe GetPreparedRecipe(int preparedRecipeId)
        {
            PreparedRecipe preparedRecipe = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.PreparedRecipeId == preparedRecipeId &&
                !pr.Complete)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                }).FirstOrDefault();

            if (preparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                pri => pri.PreparedRecipeId == preparedRecipeId)
                .Select(pri => new Ingredient
                {
                    IngredientId = pri.IngredientId,
                    Name = pri.Ingredient.Name
                }).ToList();

            if (ingredients.Any())
                preparedRecipe.Ingredients = ingredients;

            return preparedRecipe;
        }

        public PreparedRecipe GetInProgressRecipe(int recipeId)
        {
            PreparedRecipe preparedRecipe = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.RecipeId == recipeId &&
                !pr.Complete)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                }).FirstOrDefault();

            if (preparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                pri => pri.PreparedRecipe.RecipeId == recipeId &&
                !pri.PreparedRecipe.Complete)
                .Select(pri => new Ingredient
                {
                    IngredientId = pri.IngredientId,
                    Name = pri.Ingredient.Name
                }).ToList();

            if (ingredients.Any())
                preparedRecipe.Ingredients = ingredients;

            return preparedRecipe;
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipes(int recipeId)
        {
            IEnumerable<PreparedRecipe> preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.RecipeId == recipeId)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                });

            if (preparedRecipes is null || !preparedRecipes.Any())
                throw new RecordNotFoundException("Record not found.");

            List<PreparedRecipe> preparedRecipeList = new List<PreparedRecipe>();
            foreach (var preparedRecipe in preparedRecipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                    pri => pri.PreparedRecipe.RecipeId == recipeId)
                    .Select(pri => new Ingredient
                    {
                        IngredientId = pri.IngredientId,
                        Name = pri.Ingredient.Name
                    }).ToList();

                if (ingredients.Any())
                    preparedRecipe.Ingredients = ingredients;

                preparedRecipeList.Add(preparedRecipe);
            }

            return preparedRecipeList;
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipes(int cookId, int recipeId)
        {
            IEnumerable<PreparedRecipe> preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.RecipeId == recipeId &&
                pr.CookId == cookId)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                });

            if (preparedRecipes is null || !preparedRecipes.Any())
                throw new RecordNotFoundException("Record not found.");

            List<PreparedRecipe> preparedRecipeList = new List<PreparedRecipe>();
            foreach (var preparedRecipe in preparedRecipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                    pri => pri.PreparedRecipe.RecipeId == recipeId &&
                    pri.PreparedRecipe.CookId == cookId)
                    .Select(pri => new Ingredient
                    {
                        IngredientId = pri.IngredientId,
                        Name = pri.Ingredient.Name
                    }).ToList();

                if (ingredients.Any())
                    preparedRecipe.Ingredients = ingredients;

                preparedRecipeList.Add(preparedRecipe);
            }

            return preparedRecipeList;
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipes(int cookId, string recipeName)
        {
            IEnumerable<PreparedRecipe> preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.Recipe.Name == recipeName &&
                pr.CookId == cookId)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                });

            if (preparedRecipes is null || !preparedRecipes.Any())
                throw new RecordNotFoundException("Record not found.");

            foreach (var preparedRecipe in preparedRecipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                    pri => pri.PreparedRecipe.Recipe.Name == recipeName &&
                    pri.PreparedRecipe.CookId == cookId)
                    .Select(pri => new Ingredient
                    {
                        IngredientId = pri.IngredientId,
                        Name = pri.Ingredient.Name
                    }).ToList();

                if (ingredients.Any())
                    preparedRecipe.Ingredients = ingredients;
            }

            return preparedRecipes;
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipes(string email, int recipeId)
        {
            IEnumerable<PreparedRecipe> preparedRecipes = this.cookbookDbContext.preparedRecipeIngredients.Where(
                pri => pri.PreparedRecipe.RecipeId == recipeId &&
                pri.PreparedRecipe.Cook.Email == email)
                .Select(pri => new PreparedRecipe
                {
                    PreparedRecipeId = pri.PreparedRecipeId,
                    Alias = pri.PreparedRecipe.Alias,
                    Complete = pri.PreparedRecipe.Complete,
                    PreparedWhen = pri.PreparedRecipe.PreparedWhen
                });

            if (preparedRecipes is null || !preparedRecipes.Any())
                throw new RecordNotFoundException("Record not found.");
            List<PreparedRecipe> preparedRecipeList = new List<PreparedRecipe>();
            foreach (var preparedRecipe in preparedRecipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                    pri => pri.PreparedRecipe.RecipeId == recipeId &&
                    pri.PreparedRecipe.Cook.Email == email)
                    .Select(pri => new Ingredient
                    {
                        IngredientId = pri.IngredientId,
                        Name = pri.Ingredient.Name
                    }).ToList();

                if (ingredients.Any())
                    preparedRecipe.Ingredients = ingredients;

                preparedRecipeList.Add(preparedRecipe);
            }

            return preparedRecipeList;
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipes(string email, string recipeName)
        {
            IEnumerable<PreparedRecipe> preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.Recipe.Name == recipeName &&
                pr.Cook.Email == email)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                });

            if (preparedRecipes is null || !preparedRecipes.Any())
                throw new RecordNotFoundException("Record not found.");

            List<PreparedRecipe> preparedRecipeList = new List<PreparedRecipe>();
            foreach (var preparedRecipe in preparedRecipes)
            {
                IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                    pri => pri.PreparedRecipe.Recipe.Name == recipeName &&
                    pri.PreparedRecipe.Cook.Email == email)
                    .Select(pri => new Ingredient
                    {
                        IngredientId = pri.IngredientId,
                        Name = pri.Ingredient.Name
                    }).ToList();

                if (ingredients.Any())
                    preparedRecipe.Ingredients = ingredients;

                preparedRecipeList.Add(preparedRecipe);
            }

            return preparedRecipeList;
        }

        public int Insert(int cookId, int recipeId, PreparedRecipe preparedRecipe)
        {
            if (this.cookbookDbContext.preparedRecipes.Any(pr => pr.CookId == cookId && pr.RecipeId == recipeId && pr.Alias == preparedRecipe.Alias && !pr.Complete))
                throw new RecordAlreadyExistException("Record alread exist.");

            DAL.Cook cook = this.cookbookDbContext.cooks.FirstOrDefault(c => c.CookId == cookId);

            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.RecipeId == recipeId);

            if (cook is null || recipe is null)
                throw new RecordNotFoundException("Record not found.");

            DAL.PreparedRecipe newPreparedRecipe = new DAL.PreparedRecipe
            {
                Alias = preparedRecipe.Alias,
                CookId = cookId,
                RecipeId = recipeId,
                Complete = false,
                PreparedWhen = DateTime.Now,
            };

            this.cookbookDbContext.preparedRecipes.Add(newPreparedRecipe);
            this.cookbookDbContext.SaveChanges();
            return newPreparedRecipe.PreparedRecipeId;
        }

        public int Insert(int cookId, string recipeName, PreparedRecipe preparedRecipe)
        {
            if (this.cookbookDbContext.preparedRecipes.Any(pr => pr.CookId == cookId && pr.Recipe.Name == recipeName && pr.Alias == preparedRecipe.Alias && !pr.Complete))
                throw new RecordAlreadyExistException("Record alread exist.");

            DAL.Cook cook = this.cookbookDbContext.cooks.FirstOrDefault(c => c.CookId == cookId);

            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.Name == recipeName);

            if (cook is null || recipe is null)
                throw new RecordNotFoundException("Record not found.");

            DAL.PreparedRecipe newPreparedRecipe = new DAL.PreparedRecipe
            {
                Alias = preparedRecipe.Alias,
                CookId = cookId,
                RecipeId = recipe.RecipeId,
                Complete = false,
                PreparedWhen = DateTime.Now,
            };

            this.cookbookDbContext.preparedRecipes.Add(newPreparedRecipe);
            this.cookbookDbContext.SaveChanges();

            return newPreparedRecipe.PreparedRecipeId;
        }

        public int Insert(string email, int recipeId, PreparedRecipe preparedRecipe)
        {
            if (this.cookbookDbContext.preparedRecipes.Any(pr => pr.Cook.Email == email && pr.RecipeId == recipeId && pr.Alias == preparedRecipe.Alias && !pr.Complete))
                throw new RecordAlreadyExistException("Record alread exist.");

            DAL.Cook cook = this.cookbookDbContext.cooks.FirstOrDefault(c => c.Email == email);

            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.RecipeId == recipeId);

            if (cook is null || recipe is null)
                throw new RecordNotFoundException("Record not found.");

            DAL.PreparedRecipe newPreparedRecipe = new DAL.PreparedRecipe
            {
                Alias = preparedRecipe.Alias,
                CookId = cook.CookId,
                RecipeId = recipeId,
                Complete = false,
                PreparedWhen = DateTime.Now,
            };

            this.cookbookDbContext.preparedRecipes.Add(newPreparedRecipe);
            this.cookbookDbContext.SaveChanges();

            return newPreparedRecipe.PreparedRecipeId;
        }

        public int Insert(string email, string recipeName, PreparedRecipe preparedRecipe)
        {
            if (this.cookbookDbContext.preparedRecipes.Any(pr => pr.Cook.Email == email && pr.Recipe.Name == recipeName && pr.Alias == preparedRecipe.Alias && !pr.Complete))
                throw new RecordAlreadyExistException("Record alread exist.");

            DAL.Cook cook = this.cookbookDbContext.cooks.FirstOrDefault(c => c.Email == email);

            DAL.Recipe recipe = this.cookbookDbContext.recipes.FirstOrDefault(r => r.Name == recipeName);

            if (cook is null || recipe is null)
                throw new RecordNotFoundException("Record not found.");

            DAL.PreparedRecipe newPreparedRecipe = new DAL.PreparedRecipe
            {
                Alias = preparedRecipe.Alias,
                CookId = cook.CookId,
                RecipeId = recipe.RecipeId,
                Complete = false,
                PreparedWhen = DateTime.Now,
            };

            this.cookbookDbContext.preparedRecipes.Add(newPreparedRecipe);
            this.cookbookDbContext.SaveChanges();

            return newPreparedRecipe.PreparedRecipeId;
        }

        public void AddIngredient(int preparedRecipeId, string ingredientName)
        {
            DAL.Ingredient retrievedIngredient = this.cookbookDbContext.ingredients.FirstOrDefault(i => i.Name == ingredientName);
            DAL.PreparedRecipe retrievedPreparedRecipe = this.cookbookDbContext.preparedRecipes.FirstOrDefault(pr => pr.PreparedRecipeId == preparedRecipeId);

            if (!this.cookbookDbContext.recipeIngredients.Any(ri => ri.IngredientId == retrievedIngredient.IngredientId
                     && ri.Recipe.RecipeId == retrievedPreparedRecipe.RecipeId))
                throw new RecordNotFoundException("Record not found.");

            this.cookbookDbContext.preparedRecipeIngredients.Add(new DAL.PreparedRecipeIngredient
            {
                IngredientId = retrievedIngredient.IngredientId,
                PreparedRecipeId = preparedRecipeId
            });
        }

        public void RemoveIngredient(int preparedRecipeId, string ingredientName)
        {
            DAL.PreparedRecipeIngredient retrievedPreparedRecipeIngredient = this.cookbookDbContext.preparedRecipeIngredients.FirstOrDefault(i =>
            i.Ingredient.Name == ingredientName &&
            i.PreparedRecipeId == preparedRecipeId);
            if (retrievedPreparedRecipeIngredient is null)
                throw new RecordNotFoundException("Record not found.");

            this.cookbookDbContext.preparedRecipeIngredients.Remove(retrievedPreparedRecipeIngredient);
        }

        public PreparedRecipe FinishRecipePreparation(int preparedRecipeId)
        {
            DAL.PreparedRecipe retrievedPreparedRecipe = this.cookbookDbContext.preparedRecipes.Find(preparedRecipeId);
            if (retrievedPreparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(pri => pri.PreparedRecipeId == preparedRecipeId)
                .Select(pri => new Ingredient
                {
                    IngredientId=pri.IngredientId,
                    Name = pri.Ingredient.Name
                });

            retrievedPreparedRecipe.Complete = true;
            this.cookbookDbContext.preparedRecipes.Update(retrievedPreparedRecipe);
            return new PreparedRecipe
            {
                PreparedRecipeId = retrievedPreparedRecipe.PreparedRecipeId,
                Alias = retrievedPreparedRecipe.Alias,
                Complete = retrievedPreparedRecipe.Complete,
                PreparedWhen = retrievedPreparedRecipe.PreparedWhen,
                Ingredients = ingredients
            };
        }

        public void AddIngredient(int cookId, int recipeId, int preparedRecipeId, string ingredientName)
        {
            DAL.Ingredient retrievedIngredient = this.cookbookDbContext.ingredients.FirstOrDefault(i => i.Name == ingredientName);
            DAL.PreparedRecipe retrievedPreparedRecipe = this.cookbookDbContext.preparedRecipes.FirstOrDefault(pr => pr.PreparedRecipeId == preparedRecipeId
            && pr.CookId == cookId
            && pr.RecipeId == recipeId);

            if (!this.cookbookDbContext.recipeIngredients.Any(ri => ri.IngredientId == retrievedIngredient.IngredientId
                     && ri.Recipe.RecipeId == retrievedPreparedRecipe.RecipeId))
                throw new RecordNotFoundException("Record not found.");

            this.cookbookDbContext.preparedRecipeIngredients.Add(new DAL.PreparedRecipeIngredient
            {
                IngredientId = retrievedIngredient.IngredientId,
                PreparedRecipeId = preparedRecipeId
            });
        }

        public PreparedRecipe FinishRecipePreparation(int cookId, int recipeId, PreparedRecipe preparedRecipeToFinish)
        {
            DAL.PreparedRecipe retrievedPreparedRecipe = this.cookbookDbContext.preparedRecipes.FirstOrDefault(pr => pr.PreparedRecipeId == preparedRecipeToFinish.PreparedRecipeId
            && pr.CookId == cookId
            && pr.RecipeId == recipeId);
            if (retrievedPreparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(pri => pri.PreparedRecipeId == retrievedPreparedRecipe.PreparedRecipeId
                && pri.PreparedRecipe.CookId == cookId
                && pri.PreparedRecipe.RecipeId == recipeId)
                .Select(pri => new Ingredient
                {
                    IngredientId = pri.IngredientId,
                    Name = pri.Ingredient.Name
                });

            retrievedPreparedRecipe.Alias = preparedRecipeToFinish.Alias;
            retrievedPreparedRecipe.Complete = true;
            this.cookbookDbContext.preparedRecipes.Update(retrievedPreparedRecipe);
            return new PreparedRecipe
            {
                PreparedRecipeId = retrievedPreparedRecipe.PreparedRecipeId,
                Alias = retrievedPreparedRecipe.Alias,
                Complete = retrievedPreparedRecipe.Complete,
                PreparedWhen = retrievedPreparedRecipe.PreparedWhen,
                Ingredients = ingredients.ToList()
            };
        }

        public void RemoveIngredient(int cookId, int recipeId, int preparedRecipeId, string ingredientName)
        {
            DAL.PreparedRecipe retrievedPreparedRecipe = this.cookbookDbContext.preparedRecipes.FirstOrDefault(pr => pr.PreparedRecipeId == preparedRecipeId
            && pr.CookId == cookId
            && pr.RecipeId == recipeId);

            DAL.PreparedRecipeIngredient retrievedPreparedRecipeIngredient = this.cookbookDbContext.preparedRecipeIngredients.FirstOrDefault(i =>
            i.Ingredient.Name == ingredientName &&
            i.PreparedRecipeId == preparedRecipeId);
            if (retrievedPreparedRecipeIngredient is null || retrievedPreparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            this.cookbookDbContext.preparedRecipeIngredients.Remove(retrievedPreparedRecipeIngredient);
        }

        public PreparedRecipe GetPreparedRecipe(int cookId, int recipeId, int preparedRecipeId)
        {
            PreparedRecipe preparedRecipe = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.RecipeId == recipeId &&
                pr.CookId == cookId &&
                pr.PreparedRecipeId == preparedRecipeId)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                }).FirstOrDefault();

            if (preparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                pri => pri.PreparedRecipe.RecipeId == recipeId &&
                pri.PreparedRecipe.CookId == cookId &&
                pri.PreparedRecipe.PreparedRecipeId == preparedRecipeId)
                .Select(pri => new Ingredient
                {
                    IngredientId = pri.IngredientId,
                    Name = pri.Ingredient.Name
                }).ToList();

            if (ingredients.Any())
                preparedRecipe.Ingredients = ingredients;

            return preparedRecipe;
        }

        public PreparedRecipe GetInProgressRecipe(int cookId, int recipeId)
        {
            PreparedRecipe preparedRecipe = this.cookbookDbContext.preparedRecipes.Where(
                pr => pr.RecipeId == recipeId &&
                pr.CookId == cookId &&
                !pr.Complete)
                .Select(pr => new PreparedRecipe
                {
                    PreparedRecipeId = pr.PreparedRecipeId,
                    Alias = pr.Alias,
                    Complete = pr.Complete,
                    PreparedWhen = pr.PreparedWhen
                }).FirstOrDefault();

            if (preparedRecipe is null)
                throw new RecordNotFoundException("Record not found.");

            IEnumerable<Ingredient> ingredients = this.cookbookDbContext.preparedRecipeIngredients.Where(
                pri => pri.PreparedRecipe.RecipeId == recipeId &&
                pri.PreparedRecipe.CookId == cookId &&
                !pri.PreparedRecipe.Complete)
                .Select(pri => new Ingredient
                {
                    IngredientId = pri.IngredientId,
                    Name = pri.Ingredient.Name
                }).ToList();

            if (ingredients.Any())
                preparedRecipe.Ingredients = ingredients;

            return preparedRecipe;
        }
    }
}
