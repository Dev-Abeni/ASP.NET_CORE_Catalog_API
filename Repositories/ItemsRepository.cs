using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
using Catalog.Interfaces;

namespace Catalog.Repositories{

    public class ItemsRepository : IItemsRepository
    {
        public ItemsRepository()
        {
            
        }

        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}