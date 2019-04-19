using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.WebApi.BusinessLayer.Exceptions;
using Cookbook.WebApi.BusinessLayer.Interactors;
using Cookbook.WebApi.BusinessLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.WebApi.Host.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/author")]
    [Route("api/chef")]
    [Route("api/[controller]")]
    [ApiController]
    public class CooksController : ControllerBase
    {
        private readonly ICookInteractor cookInteractor;
        private readonly IRecipeInteractor recipeInteractor;

        public CooksController(ICookInteractor cookInteractor,
            IRecipeInteractor recipeInteractor)
        {
            this.cookInteractor = cookInteractor;
            this.recipeInteractor = recipeInteractor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cook>> Get()
        {
            ActionResult result;
            try
            {
                var cooks = this.cookInteractor.GetAllCooks();
                result = Ok(cooks);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Cook> Get(int id)
        {
            ActionResult result;
            try
            {
                var cook = this.cookInteractor.GetCookById(id);
                result = Ok(cook);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{email:regex(^[[\\w-\\.]]+@([[\\w-]]+\\.)+[[\\w-]]{{2,4}}$)}")]
        public ActionResult<Cook> Get(string email)
        {
            ActionResult result;
            try
            {
                var cook = this.cookInteractor.GetCookByEmail(email);
                result = Ok(cook);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{id:int}/recipes")]
        public ActionResult<IEnumerable<Recipe>> GetRecipes(int id)
        {
            ActionResult result;
            try
            {
                var recipes = this.cookInteractor.GetRecipesByCookId(id);
                result = Ok(recipes);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{email:regex(^[[\\w-\\.]]+@([[\\w-]]+\\.)+[[\\w-]]{{2,4}}$)}/recipes")]
        public ActionResult<IEnumerable<Recipe>> GetRecipes(string email)
        {
            ActionResult result;
            try
            {
                var recipes = this.cookInteractor.GetRecipesByEmail(email);
                result = Ok(recipes);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{id:int}/recipes/{recipeId:int}")]
        public ActionResult<Recipe> GetRecipe(int id, int recipeId)
        {
            ActionResult result;
            try
            {
                var recipe = this.recipeInteractor.GetRecipe(id, recipeId);
                result = Ok(recipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{email:regex(^[[\\w-\\.]]+@([[\\w-]]+\\.)+[[\\w-]]{{2,4}}$)}/recipes/{recipeId:int}")]
        public ActionResult<Recipe> GetRecipe(string email, int recipeId)
        {
            ActionResult result;
            try
            {
                var recipe = this.recipeInteractor.GetRecipe(email, recipeId);
                result = Ok(recipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{id:int}/recipes/{recipeName:regex(^[[a-zA-Z' ]]*$)}")]
        public ActionResult<Recipe> GetRecipe(int id, string recipeName)
        {
            ActionResult result;
            try
            {
                var recipe = this.recipeInteractor.GetRecipe(id, recipeName);
                result = Ok(recipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{email:regex(^[[\\w-\\.]]+@([[\\w-]]+\\.)+[[\\w-]]{{2,4}}$)}/recipes/{recipeName:regex(^[[a-zA-Z' ]]*$)}")]
        public ActionResult<Recipe> GetRecipe(string email, string recipeName)
        {
            ActionResult result;
            try
            {
                var recipe = this.recipeInteractor.GetRecipe(email, recipeName);
                result = Ok(recipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpPost]
        public ActionResult<Cook> Post(Cook cook)
        {
            ActionResult result;
            try
            {
                this.cookInteractor.RegisterNewCook(cook);
                result = StatusCode(StatusCodes.Status201Created, cook);
            }
            catch (RecordAlreadyExistException)
            {
                result = StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpPost("{id:int}/recipes")]
        public ActionResult<Recipe> Post(int id, Recipe recipe)
        {
            ActionResult result;
            try
            {
                var recipeId = this.recipeInteractor.CreateNewRecipe(id, recipe);
                result = Ok(recipe);
            }
            catch (RecordAlreadyExistException)
            {
                result = StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpPost("{email:regex(^[[\\w-\\.]]+@([[\\w-]]+\\.)+[[\\w-]]{{2,4}}$)}/recipes")]
        public ActionResult<Recipe> Post(string email, Recipe recipe)
        {
            ActionResult result;
            try
            {
                var recipeId = this.recipeInteractor.CreateNewRecipe(email, recipe);
                result = Ok(recipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (RecordAlreadyExistException)
            {
                result = StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpPost("{id:int}/recipes/{recipeId:int}/preparedrecipes")]
        public ActionResult<PreparedRecipe> Post(int id, int recipeId, PreparedRecipe preparedRecipe)
        {
            ActionResult result;
            try
            {
                int preparedRecipeId = this.recipeInteractor.PrepareRecipe(id, recipeId, preparedRecipe);
                preparedRecipe.PreparedRecipeId = preparedRecipeId;
                result = Ok(preparedRecipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (RecordAlreadyExistException)
            {
                result = StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpPost("{id:int}/recipes/{recipeId:int}/preparedrecipes/{preparedRecipeId:int}/Ingredients")]
        public ActionResult<PreparedRecipe> Post(int id, int recipeId, int preparedRecipeId, Ingredient ingredient)
        {
            ActionResult result;
            try
            {
                this.recipeInteractor.AddIngredientToPreparedRecipe(id, recipeId, preparedRecipeId, ingredient);
                result = Ok(ingredient);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (RecordAlreadyExistException)
            {
                result = StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpDelete("{id:int}/recipes/{recipeId:int}/preparedrecipes/{preparedRecipeId:int}/Ingredients")]
        public ActionResult<PreparedRecipe> Delete(int id, int recipeId, int preparedRecipeId, Ingredient ingredient)
        {
            ActionResult result;
            try
            {
                this.recipeInteractor.RemoveIngredientFromPreparedRecipe(id, recipeId, preparedRecipeId, ingredient);
                result = Ok(ingredient);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (RecordAlreadyExistException)
            {
                result = StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpGet("{email:regex(^[[\\w-\\.]]+@([[\\w-]]+\\.)+[[\\w-]]{{2,4}}$)}/recipes/{recipeId:int}/preparedrecipes")]
        public ActionResult<IEnumerable<PreparedRecipe>> Get(string email, int recipeId)
        {
            ActionResult result;
            try
            {
                IEnumerable<PreparedRecipe> preparedRecipe = this.recipeInteractor.GetPreparedRecipesByCookAndRecipeId(email, recipeId);
                result = Ok(preparedRecipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpGet("{id:int}/recipes/{recipeId:int}/preparedrecipes")]
        public ActionResult<IEnumerable<PreparedRecipe>> Get(int id, int recipeId)
        {
            ActionResult result;
            try
            {
                IEnumerable<PreparedRecipe> preparedRecipe = this.recipeInteractor.GetPreparedRecipesByCookIdAndRecipeId(id, recipeId);
                result = Ok(preparedRecipe);
            }
            catch (RecordNotFoundException)
            {
                result = NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        [HttpGet("{id:int}/recipes/{recipeId:int}/preparedrecipes/{preparedRecipeId:int}")]
        public ActionResult<PreparedRecipe> Get(int id, int recipeId, int preparedRecipeId)
        {
            ActionResult result;
            try
            {
                PreparedRecipe preparedRecipe = this.recipeInteractor.GetPreparedRecipe(id, recipeId, preparedRecipeId);
                result = Ok(preparedRecipe);
            }
            catch (RecordNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpPut("{id:int}/recipes/{recipeId:int}/preparedrecipes/{preparedRecipeId:int}")]
        public ActionResult<PreparedRecipe> Put(int id, int recipeId, int preparedRecipeId, PreparedRecipe preparedRecipeToComplete)
        {
            ActionResult result;
            try
            {
                if (preparedRecipeId != preparedRecipeToComplete.PreparedRecipeId)
                    result = BadRequest(preparedRecipeToComplete);
                else
                {
                    var preparedRecipe = this.recipeInteractor.FinishRecipePreparation(id, recipeId, preparedRecipeToComplete);
                    result = Ok(preparedRecipe);
                }
            }
            catch (RecordNotFoundException ex)
            {
                result = NotFound(ex.Message);
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        [HttpGet("{id:int}/recipes/{recipeId:int}/preparedrecipes/continue")]
        public ActionResult<PreparedRecipe> Continue(int id, int recipeId)
        {
            ActionResult result;
            try
            {
                PreparedRecipe preparedRecipe = this.recipeInteractor.GetInProgressPreparedRecipe(id, recipeId);
                result = Ok(preparedRecipe);
            }
            catch (RecordNotFoundException)
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