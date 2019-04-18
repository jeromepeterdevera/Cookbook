using System;
using System.Collections.Generic;
using System.Text;
using Cookbook.WebApi.BusinessLayer.Models;

namespace Cookbook.WebApi.BusinessLayer.Interactors
{
    public class IngredientInteractor : IIngredientInteractor
    {
        private readonly IUnitOfWork unitOfWork;

        public IngredientInteractor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            using (this.unitOfWork)
            {
                int ingredientId= this.unitOfWork.ingredientRepository.Insert(ingredient);
                ingredient.IngredientId = ingredientId;
                this.unitOfWork.SaveChanges();
            }
        }

        public void AddIngredients(IEnumerable<Ingredient> ingredients)
        {
            using (this.unitOfWork)
            {
                foreach (var ingredient in ingredients)
                {
                    this.unitOfWork.ingredientRepository.Insert(ingredient);
                }
                this.unitOfWork.SaveChanges();
            }
        }

        public Ingredient GetIngredient(string ingredientName)
        {
            using (this.unitOfWork)
                return this.unitOfWork.ingredientRepository.GetIngredientByName(ingredientName);
        }

        public IEnumerable<Ingredient> GetIngredientsByRecipe(string recipeName)
        {
            using (this.unitOfWork)
                return this.unitOfWork.ingredientRepository.GetIngredientsByRecipeName(recipeName);
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            using (this.unitOfWork)
                return this.unitOfWork.ingredientRepository.GetAllIngredients();
        }

        public Ingredient GetIngredient(int ingredientId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.ingredientRepository.GetIngredientById(ingredientId);
        }

        public IEnumerable<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            using (this.unitOfWork)
                return this.unitOfWork.ingredientRepository.GetIngredientsByRecipeId(recipeId);
        }
    }
}
