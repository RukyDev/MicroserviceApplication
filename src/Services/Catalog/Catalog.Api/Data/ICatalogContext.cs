﻿using Catalog.Api.ENtities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Products> Products { get; }
    }
}
