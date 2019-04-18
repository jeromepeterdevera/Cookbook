using Cookbook.WebApi.BusinessLayer.Models;
using Cookbook.WebApi.BusinessLayer.Repositories;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using DAL = Cookbook.WebApi.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Cookbook.WebApi.BusinessLayer.Exceptions;

namespace Cookbook.WebApi.DataAccessLayer.Repositories
{
    public class CookRepository : ICookRepository
    {
        private readonly CookbookDbContext cookbookDbContext;

        public CookRepository(CookbookDbContext cookbookDbContext)
        {
            this.cookbookDbContext = cookbookDbContext;
        }

        public IEnumerable<Cook> GetAllCooks()
        {
            var cooks = this.cookbookDbContext.cooks.Include(c => c.Recipes);
            if (cooks is null || !cooks.Any())
                throw new RecordNotFoundException($"No record found.");

            var retrievedCooks = new List<Cook>();
            foreach (var cook in cooks)
            {
                List<Recipe> recipes = null;
                if (cook.Recipes.Any())
                {
                    recipes = new List<Recipe>();
                    foreach (var recipe in cook.Recipes)
                    {
                        var ingredients = this.cookbookDbContext.recipeIngredients.Where(ri => ri.RecipeId == recipe.RecipeId)
                            .Select(ri => new Ingredient {
                                IngredientId = ri.IngredientId,
                                Name = ri.Ingredient.Name
                            });

                        var preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(pr => pr.RecipeId == recipe.RecipeId)
                            .Select(pr => new PreparedRecipe {
                                Alias = pr.Alias,
                                Complete = pr.Complete,
                                PreparedWhen = pr.PreparedWhen,
                                PreparedRecipeId = pr.PreparedRecipeId
                            });

                        recipes.Add(new Recipe
                        {
                            RecipeId = recipe.RecipeId,
                            Name = recipe.Name,
                            Description = recipe.Description,
                            Ingredients = ingredients.ToList(),
                            PreparedRecipes = preparedRecipes.ToList()
                        });
                    }
                }

                retrievedCooks.Add(new Cook
                {
                    CookId = cook.CookId,
                    Email = cook.Email,
                    FirstName = cook.FirstName,
                    LastName = cook.LastName,
                    Recipes = recipes
                });
            }

            return retrievedCooks;
        }

        public Cook GetByCookId(int id)
        {
            DAL.Cook cook = this.cookbookDbContext.cooks
                .Include(c => c.Recipes)
                .FirstOrDefault(c => c.CookId == id);
            if (cook is null)
                throw new RecordNotFoundException($"No record found.");

            List<Recipe> recipes = null;
            if (cook.Recipes.Any())
            {
                recipes = new List<Recipe>();
                foreach (var recipe in cook.Recipes)
                {
                    var ingredients = this.cookbookDbContext.recipeIngredients.Where(ri => ri.RecipeId == recipe.RecipeId)
                        .Select(ri => new Ingredient {
                            IngredientId=ri.IngredientId,
                            Name = ri.Ingredient.Name
                        });

                    var preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(pr => pr.RecipeId == recipe.RecipeId)
                        .Select(pr => new PreparedRecipe
                        {
                            Alias = pr.Alias,
                            Complete = pr.Complete,
                            PreparedWhen = pr.PreparedWhen,
                            PreparedRecipeId = pr.PreparedRecipeId
                        });

                    recipes.Add(new Recipe
                    {
                        RecipeId = recipe.RecipeId,
                        Name = recipe.Name,
                        Description = recipe.Description,
                        Ingredients = ingredients.ToList(),
                        PreparedRecipes = preparedRecipes.ToList()
                    });
                }
            }

            return new Cook
            {
                CookId = cook.CookId,
                Email = cook.Email,
                FirstName = cook.FirstName,
                LastName = cook.LastName,
                Recipes = recipes
            };
        }

        public Cook GetCookByEmail(string email)
        {
            DAL.Cook cook = this.cookbookDbContext.cooks
                .Include(c => c.Recipes)
                .FirstOrDefault(c => c.Email == email);
            if (cook is null)
                throw new RecordNotFoundException($"No record found.");

            List<Recipe> recipes = null;
            if (cook.Recipes.Any())
            {
                recipes = new List<Recipe>();
                foreach (var recipe in cook.Recipes)
                {
                    var ingredients = this.cookbookDbContext.recipeIngredients.Where(ri => ri.RecipeId == recipe.RecipeId)
                        .Select(ri => new Ingredient
                        {
                            IngredientId = ri.IngredientId,
                            Name = ri.Ingredient.Name
                        });

                    var preparedRecipes = this.cookbookDbContext.preparedRecipes.Where(pr => pr.RecipeId == recipe.RecipeId)
                        .Select(pr => new PreparedRecipe
                        {
                            Alias = pr.Alias,
                            Complete = pr.Complete,
                            PreparedWhen = pr.PreparedWhen,
                            PreparedRecipeId = pr.PreparedRecipeId
                        });

                    recipes.Add(new Recipe
                    {
                        RecipeId = recipe.RecipeId,
                        Name = recipe.Name,
                        Description = recipe.Description,
                        Ingredients = ingredients.ToList(),
                        PreparedRecipes = preparedRecipes.ToList()
                    });
                }
            }

            return new Cook
            {
                CookId = cook.CookId,
                Email = cook.Email,
                FirstName = cook.FirstName,
                LastName = cook.LastName,
                Recipes = recipes
            };
        }

        public int Insert(Cook cook)
        {
            if (this.cookbookDbContext.cooks.Any(c => c.Email == cook.Email))
                throw new RecordAlreadyExistException("Record already exist.");

            DAL.Cook newCook = new DAL.Cook
            {
                Email = cook.Email,
                FirstName = cook.FirstName,
                LastName = cook.LastName,
            };

            this.cookbookDbContext.cooks.Add(newCook);

            return newCook.CookId;
        }
    }
}
