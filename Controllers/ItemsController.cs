using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Interfaces;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers{

    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase{
        private readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){
            var items = _repository.GetItemsAsync().Select(item => item.AsDto());

            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = _repository.GetItemAsync(id);

            if(item is null)
                return NotFound();

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = _repository.GetItemAsync(id);

            if(existingItem is null)
                return NotFound();

            Item updatedItem = existingItem with{
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            _repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteItem(Guid id){
            var existingItem = _repository.GetItemAsync(id);

            if(existingItem is null)
                return NotFound();

            _repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
