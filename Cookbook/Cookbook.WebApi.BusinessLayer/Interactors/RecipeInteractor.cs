using Cookbook.WebApi.BusinessLayer.Models;
using System.Collections.Generic;

namespace Cookbook.WebApi.BusinessLayer.Interactors
{
    public class RecipeInteractor: IRecipeInteractor
    {
        private readonly IUnitOfWork unitOfWork;

        public RecipeInteractor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddIngredientToPreparedRecipe(int preparedRecipeId, Ingredient ingredient)
        {
            using (this.unitOfWork)
            {
                this.unitOfWork.preparedRecipeRepository.AddIngredient(preparedRecipeId, ingredient.Name);
                this.unitOfWork.SaveChanges();
            }
        }

        public void AddIngredientToPreparedRecipe(int cookId, int recipeId, int preparedRecipeId, Ingredient ingredient)
        {
            using (this.unitOfWork)
            {
                this.unitOfWork.preparedRecipeRepository.AddIngredient(cookId, recipeId, preparedRecipeId, ingredient.Name);
                this.unitOfWork.SaveChanges();
            }
        }

        public int CreateNewRecipe(int cookId, Recipe recipe)
        {
            using (this.unitOfWork)
            {
                int recipeId = 0;
                recipeId = unitOfWork.recipeRepository.Insert(cookId, recipe);
                unitOfWork.recipeRepository.RelateIngredientsToRecipe(recipe.Ingredients, recipeId);
                unitOfWork.SaveChanges();
                return recipeId;
            }
        }

        public int CreateNewRecipe(string email, Recipe recipe)
        {
            using (this.unitOfWork)
            {
                int recipeId = 0;
                recipeId = unitOfWork.recipeRepository.Insert(email, recipe);
                unitOfWork.recipeRepository.RelateIngredientsToRecipe(recipe.Ingredients, recipeId);
                unitOfWork.SaveChanges();
                return recipeId;
            }
        }

        public PreparedRecipe FinishRecipePreparation(int preparedRecipeId)
        {
            using (this.unitOfWork)
            {
                PreparedRecipe finishedRecipe = this.unitOfWork.preparedRecipeRepository.FinishRecipePreparation(preparedRecipeId);
                this.unitOfWork.SaveChanges();
                return finishedRecipe;
            }
        }

        public PreparedRecipe FinishRecipePreparation(int cookId, int recipeId, PreparedRecipe preparedRecipeToComplete)
        {
            using (this.unitOfWork)
            {
                PreparedRecipe finishedRecipe = this.unitOfWork.preparedRecipeRepository.FinishRecipePreparation(cookId, recipeId, preparedRecipeToComplete);
                this.unitOfWork.SaveChanges();
                return finishedRecipe;
            }
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            using (this.unitOfWork)
            {
                return unitOfWork.recipeRepository.GetAllRecipes();
            }
        }

        public PreparedRecipe GetInProgressPreparedRecipe(int recipeId)
        {
            using (this.unitOfWork)
                return unitOfWork.preparedRecipeRepository.GetInProgressRecipe(recipeId);
        }

        public PreparedRecipe GetInProgressPreparedRecipe(string email, string recipeName)
        {
            using (this.unitOfWork)
                return this.unitOfWork.preparedRecipeRepository.GetInProgressRecipe(email, recipeName);
        }

        public PreparedRecipe GetInProgressPreparedRecipe(int cookId, int recipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.preparedRecipeRepository.GetInProgressRecipe(cookId, recipeId);
        }

        public PreparedRecipe GetPreparedRecipe(int preparedRecipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.preparedRecipeRepository.GetPreparedRecipe(preparedRecipeId);
        }

        public PreparedRecipe GetPreparedRecipe(int cookId, int recipeId, int preparedRecipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.preparedRecipeRepository.GetPreparedRecipe(cookId, recipeId, preparedRecipeId);
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipesByCookIdAndRecipeId(int recipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.preparedRecipeRepository.GetPreparedRecipes(recipeId);
        }

        public IEnumerable<PreparedRecipe> GetPreparedRecipesByCookIdAndRecipeId(int cookId, int recipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.preparedRecipeRepository.GetPreparedRecipes(cookId, recipeId);
        }

        public Recipe GetRecipe(string email, int recipeId)
        {
            using (this.unitOfWork)
            {
                var recipe = unitOfWork.recipeRepository.GetRecipeByIdAndCook(recipeId, email);
                return recipe;
            }
        }

        public Recipe GetRecipe(int cookId, int recipeId)
        {
            using (this.unitOfWork)
            {
                var recipe = unitOfWork.recipeRepository.GetRecipeByIdAndCookId(recipeId, cookId);

                return recipe;
            }
        }

        public Recipe GetRecipe(int recipeId, string email)
        {
            using (this.unitOfWork)
            {
                var recipe = unitOfWork.recipeRepository.GetRecipeByIdAndCook(recipeId, email);
                recipe.Ingredients = unitOfWork.ingredientRepository.GetIngredientsByRecipeName(recipe.Name);

                return recipe;
            }
        }

        public Recipe GetRecipe(string recipeName, string email)
        {
            using (this.unitOfWork)
            {
                var recipe = unitOfWork.recipeRepository.GetRecipeByNameAndCook(recipeName, email);
                recipe.Ingredients = unitOfWork.ingredientRepository.GetIngredientsByRecipeName(recipe.Name);

                return recipe;
            }
        }

        public Recipe GetRecipe(int recipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.recipeRepository.GetRecipeById(recipeId);
        }

        public int PrepareRecipe(int cookId, int recipeId, PreparedRecipe preparedRecipe)
        {
            using (this.unitOfWork)
            {
                int preparedRecipeId = 0;
                preparedRecipeId = unitOfWork.preparedRecipeRepository.Insert(cookId, recipeId, preparedRecipe);
                //unitOfWork.SaveChanges();
                return preparedRecipeId;
            }
        }

        public int PrepareRecipe(string email, int recipeId, PreparedRecipe preparedRecipe)
        {
            using (this.unitOfWork)
            {
                int preparedRecipeId = 0;
                preparedRecipeId = unitOfWork.preparedRecipeRepository.Insert(email, recipeId, preparedRecipe);
                //unitOfWork.SaveChanges();
                return preparedRecipeId;
            }
        }

        public int PrepareRecipe(int cookId, string recipeName, PreparedRecipe preparedRecipe)
        {
            using (this.unitOfWork)
            {
                int preparedRecipeId = 0;
                preparedRecipeId = unitOfWork.preparedRecipeRepository.Insert(cookId, recipeName, preparedRecipe);
                //unitOfWork.SaveChanges();
                return preparedRecipeId;
            }
        }

        public int PrepareRecipe(string email, string recipeName, PreparedRecipe preparedRecipe)
        {
            using (this.unitOfWork)
            {
                int preparedRecipeId = 0;
                preparedRecipeId = unitOfWork.preparedRecipeRepository.Insert(email, recipeName, preparedRecipe);
                //unitOfWork.SaveChanges();
                return preparedRecipeId;
            }
        }

        public void RemoveIngredientFromPreparedRecipe(int preparedRecipeId, Ingredient ingredient)
        {
            using (this.unitOfWork)
            {
                this.unitOfWork.preparedRecipeRepository.RemoveIngredient(preparedRecipeId, ingredient.Name);
                this.unitOfWork.SaveChanges();
            }
        }

        public void RemoveIngredientFromPreparedRecipe(int id, int recipeId, int preparedRecipeId, Ingredient ingredient)
        {
            using (this.unitOfWork)
            {
                this.unitOfWork.preparedRecipeRepository.RemoveIngredient(id, recipeId, preparedRecipeId, ingredient.Name);
                this.unitOfWork.SaveChanges();
            }
        }
    }
}
