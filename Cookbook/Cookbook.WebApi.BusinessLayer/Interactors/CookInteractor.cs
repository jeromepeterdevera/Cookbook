using System;
using System.Collections.Generic;
using System.Text;
using Cookbook.WebApi.BusinessLayer.Models;

namespace Cookbook.WebApi.BusinessLayer.Interactors
{
    public class CookInteractor : ICookInteractor
    {
        private readonly IUnitOfWork unitOfWork;

        public CookInteractor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Cook GetCookByEmail(string email)
        {
            using (this.unitOfWork)
                return this.unitOfWork.cookRepository.GetCookByEmail(email);
        }

        public Cook GetCookById(int id)
        {
            using (this.unitOfWork)
                return this.unitOfWork.cookRepository.GetByCookId(id);
        }

        public IEnumerable<Cook> GetAllCooks()
        {
            using (this.unitOfWork)
                return this.unitOfWork.cookRepository.GetAllCooks();
        }

        public IEnumerable<Recipe> GetRecipesByCookId(int id)
        {
            using (this.unitOfWork)
                return this.unitOfWork.recipeRepository.GetRecipesByCookId(id);
        }

        public IEnumerable<Recipe> GetRecipesByEmail(string email)
        {
            using (this.unitOfWork)
                return this.unitOfWork.recipeRepository.GetRecipesByCook(email);
        }

        public int RegisterNewCook(Cook cook)
        {
            using (this.unitOfWork)
            {
                int cookId = this.unitOfWork.cookRepository.Insert(cook);
                this.unitOfWork.SaveChanges();
                cook.CookId = cookId;
                return cookId;
            }
        }
    }
}
