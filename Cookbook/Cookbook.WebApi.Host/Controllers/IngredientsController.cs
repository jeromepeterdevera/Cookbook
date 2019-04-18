using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.WebApi.BusinessLayer.Exceptions;
using Cookbook.WebApi.BusinessLayer.Interactors;
using Cookbook.WebApi.BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.WebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientInteractor ingredientInteractor;

        public IngredientsController(IIngredientInteractor ingredientInteractor)
        {
            this.ingredientInteractor = ingredientInteractor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> Get()
        {
            ActionResult result;
            try
            {
                IEnumerable<Ingredient> ingredients = this.ingredientInteractor.GetAllIngredients();
                result = Ok(ingredients);
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

        [HttpGet("{id}")]
        public ActionResult<Ingredient> Get(int id)
        {
            ActionResult result;
            try
            {
                Ingredient ingredient = this.ingredientInteractor.GetIngredient(id);
                result = Ok(ingredient);
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

        [HttpGet("{name:regex(^[[a-zA-Z' ]]*$)}")]
        public ActionResult<Ingredient> Get(string name)
        {
            ActionResult result;
            try
            {
                Ingredient ingredient = this.ingredientInteractor.GetIngredient(name);
                result = Ok(ingredient);
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
        public ActionResult<Ingredient> Post(Ingredient ingredient)
        {
            ActionResult result;
            try
            {
                this.ingredientInteractor.AddIngredient(ingredient);
                result = StatusCode(StatusCodes.Status201Created, ingredient);
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

        [HttpPost("AddMultiple")]
        public ActionResult<IEnumerable<Ingredient>> Post(IEnumerable<Ingredient> ingredients)
        {
            ActionResult result;
            try
            {
                this.ingredientInteractor.AddIngredients(ingredients);
                result = StatusCode(StatusCodes.Status201Created, ingredients);
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
    }
}