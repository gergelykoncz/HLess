﻿using HLess.Data.Repository.Interfaces;
using HLess.Logic.Services.Interfaces;
using HLess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLess.Logic.Services
{
    public class ContentTypeService : IContentTypeService
    {
        private readonly IContentTypeRepository repository;

        public ContentTypeService(IContentTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ContentType>> GetContentTypesForUser(Guid userId, bool includeDeleted = false)
        {
            var contentTypes = await this.repository.GetByAsync(x => x.Site.Account.AccountUsers.Any(au => au.UserId == userId) && includeDeleted ? x.Deleted == true : x.Deleted == false);
            return contentTypes;
        }

        public async Task<ContentType> CreateContentType(ContentType value)
        {
            return await this.repository.InsertAsync(value);
        }
    }
}
