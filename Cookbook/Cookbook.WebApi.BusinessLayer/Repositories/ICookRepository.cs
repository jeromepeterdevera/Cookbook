using System.Collections.Generic;
using Cookbook.WebApi.BusinessLayer.Models;

namespace Cookbook.WebApi.BusinessLayer.Repositories
{
    public interface ICookRepository
    {
        int Insert(Cook cook);

        Cook GetCookByEmail(string email);

        Cook GetByCookId(int cookId);

        IEnumerable<Cook> GetAllCooks();
    }
}
