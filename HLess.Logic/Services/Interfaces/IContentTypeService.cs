using HLess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HLess.Logic.Services.Interfaces
{
    public interface IContentTypeService
    {
        Task<IEnumerable<ContentType>> GetContentTypesForUser(Guid userId, bool includeDeleted = false);
        Task<ContentType> CreateContentType(ContentType value);
    }
}
