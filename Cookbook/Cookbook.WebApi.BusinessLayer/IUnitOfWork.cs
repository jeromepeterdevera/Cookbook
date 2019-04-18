using Cookbook.WebApi.BusinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        ICookRepository cookRepository { get; }

        IIngredientRepository ingredientRepository { get; }

        IRecipeRepository recipeRepository { get; }

        IPreparedRecipeRepository preparedRecipeRepository { get; }

        int SaveChanges();
    }
}
