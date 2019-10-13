using HLess.Logic.Facades.Interfaces;
using HLess.Logic.Services.Interfaces;
using HLess.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLess.Logic.Facades
{
    public class ContentTypeFacade : IContentTypeFacade
    {
        private readonly IContentTypeService service;

        public ContentTypeFacade(IContentTypeService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<ContentTypeDto>> GetContentTypesForUser(Guid userId, bool includeDeleted = false)
        {
            var results = await this.service.GetContentTypesForUser(userId, includeDeleted);
            return results.Select(x => new ContentTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Fields = x.Fields.Select(f => new ContentFieldDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Slug = f.Slug,
                    FieldType = f.FieldType
                })
            });
        }
    }
}
