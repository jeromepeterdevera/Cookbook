using Cookbook.WebApi.BusinessLayer;
using Cookbook.WebApi.BusinessLayer.Repositories;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using Cookbook.WebApi.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CookbookDbContext cookbookDbContext;

        public UnitOfWork(CookbookDbContext cookbookDbContext)
        {
            this.cookbookDbContext = cookbookDbContext;
        }

        public ICookRepository cookRepository { get { return new CookRepository(this.cookbookDbContext); } }
        public IIngredientRepository ingredientRepository { get { return new IngredientRepository(this.cookbookDbContext); } }
        public IRecipeRepository recipeRepository { get { return new RecipeRepository(this.cookbookDbContext); } }
        public IPreparedRecipeRepository preparedRecipeRepository { get { return new PreparedRecipeRepository(this.cookbookDbContext); } }

        public void Dispose()
        {
            this.cookbookDbContext.Dispose();
        }

        public int SaveChanges()
        {
            return this.cookbookDbContext.SaveChanges();
        }
    }
}
