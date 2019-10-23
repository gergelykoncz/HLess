using HLess.Logic.Facades.Interfaces;
using HLess.Logic.Services.Interfaces;
using HLess.Models.Entities;
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

        public async Task<ContentTypeDto> CreateContentType(Guid userId, ContentTypeDto model)
        {
            var ctype = new ContentType
            {
                CreatedByUserId = userId,
                CreatedDate = DateTime.Now,
                Fields = model.Fields.Select(f => new ContentField
                {
                    CreatedByUserId = userId,
                    CreatedDate = DateTime.Now,
                    FieldType = f.FieldType,
                    Name = f.Name,
                    Slug = f.Slug
                }).ToList(),
                Name = model.Name,
                Slug = model.Slug,
                SiteId = model.SiteId
            };

            var created = await this.service.CreateContentType(ctype);
            return new ContentTypeDto
            {
                Fields = created.Fields.Select(f => new ContentFieldDto
                {
                    FieldType = f.FieldType,
                    Id = f.Id,
                    Name = f.Name,
                    Slug = f.Slug
                }),
                Id = created.Id,
                Name = created.Name,
                SiteId = created.SiteId,
                Slug = created.Slug
            };
        }
    }
}
