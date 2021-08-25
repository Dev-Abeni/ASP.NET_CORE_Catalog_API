using System;

namespace Catalog.DTOs{
    public class ItemDto{
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}