using Cookbook.WebApi.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Interactors
{
    public interface ICookInteractor
    {
        int RegisterNewCook(Cook cook);

        Cook GetCookById(int id);

        Cook GetCookByEmail(string email);

        IEnumerable<Cook> GetAllCooks();

        IEnumerable<Recipe> GetRecipesByEmail(string email);

        IEnumerable<Recipe> GetRecipesByCookId(int id);
    }
}
