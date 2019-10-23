using HLess.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HLess.Logic.Facades.Interfaces
{
    public interface IContentTypeFacade
    {
        Task<IEnumerable<ContentTypeDto>> GetContentTypesForUser(Guid userId, bool includeDeleted = false);
        Task<ContentTypeDto> CreateContentType(Guid userId, ContentTypeDto model);
    }
}
