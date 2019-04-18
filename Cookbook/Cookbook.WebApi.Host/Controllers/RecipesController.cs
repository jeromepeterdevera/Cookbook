using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.WebApi.BusinessLayer;
using Cookbook.WebApi.BusinessLayer.Exceptions;
using Cookbook.WebApi.BusinessLayer.Interactors;
using Cookbook.WebApi.BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.WebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeInteractor recipeInteractor;

        public RecipesController(IRecipeInteractor recipeInteractor)
        {
            this.recipeInteractor = recipeInteractor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get()
        {
            ActionResult result;
            try
            {
                IEnumerable<Recipe> recipes = this.recipeInteractor.GetAllRecipes();
                return Ok(recipes);
            }
            catch(RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }
    }
}