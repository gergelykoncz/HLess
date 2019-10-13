using HLess.Data.Repository.Base;
using HLess.Data.Repository.Interfaces;
using HLess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HLess.Data.Repository
{
    public class ContentTypeRepository : BaseRepository<ContentType>, IContentTypeRepository
    {
        public ContentTypeRepository(HLessDataContext context) : base(context)
        {
        }

        protected override IQueryable<ContentType> CreateQuery()
        {
            return base.CreateQuery().Include(x => x.Fields);
        }
    }
}
