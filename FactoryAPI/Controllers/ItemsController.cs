using FactoryAPI.DTOs;
using FactoryAPI.Entities;
using FactoryAPI.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FactoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemContext _itemContext;
        /// <summary>
        /// Constructor with injected DbContext for database
        /// </summary>
        /// <param name="context"></param>
        public ItemsController(ItemContext context)
        {
            _itemContext = context;
        }

        
        /// <summary>
        /// Creating new item in to a table Items. Used in entire controler entity framework core to take care of queries to database.
        /// </summary>
        /// <param name="item">Dto to add item</param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateNewItem(ItemToAddDTO item)
        {
            var newItem = new Item
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            };

            _itemContext.Items.Add(newItem);
            await _itemContext.SaveChangesAsync();

            return Ok();
        }


        /// <summary>
        /// Retrieve a single item form table Items.
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>Status 200 OK with an item</returns>
        [HttpGet("retrieve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Item>> RetriveOneItem(int id)
        {
            var item = await _itemContext.Items.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(item);
        }

        /// <summary>
        /// Retrieve all items from table Items
        /// </summary>
        /// <returns>Status 200 OK with array of items</returns>
        [HttpGet("retrieveAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Item>>> RetriveAllItems()
        {
            var item = await _itemContext.Items.ToListAsync();
            return Ok(item);
        }

        /// <summary>
        /// Update an existing item in table Items
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <returns>400 Bad request if not found specifed ID or 200 Ok with just updated item</returns>
        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateItem(Item item)
        {
            var result = await _itemContext.Items.SingleOrDefaultAsync(x => x.Id == item.Id);

            if(result == null)
                return BadRequest(new ApiResponse(400));

            result.Name = item.Name;
            result.Description = item.Description;
            result.Price = item.Price;

            await _itemContext.SaveChangesAsync();

            return Ok(item);
        }

        /// <summary>
        /// Delete an item in a table Items.
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>400 Bad request if not found specifed ID or 200 Ok with just deleted item</returns>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var result = await _itemContext.Items.SingleOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return BadRequest();

            _itemContext.Items.Remove(result);

            await _itemContext.SaveChangesAsync();

            return Ok(result);
        }

    }
}
