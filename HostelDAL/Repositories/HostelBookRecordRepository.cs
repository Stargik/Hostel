using System;
using HostelDAL.Data;
using HostelDAL.Entities;
using HostelDAL.Interfaces;

namespace HostelDAL.Repositories
{
    public class HostelBookRecordRepository : IHostelBookRecordRepository
    {
        private HostelContext context;

        public HostelBookRecordRepository(HostelContext context)
        {
            this.context = context;
        }
        public void Create(HostelBookRecord entity)
        {
            context.HostelBookRecords?.Add(entity);
        }

        public void Delete(HostelBookRecord entity)
        {
            HostelBookRecord? record = context.HostelBookRecords?.Find(x => x.Id == entity.Id);

            if (record is not null)
            {
                context.HostelBookRecords?.Remove(record);
            }
        }

        public void DeleteById(Guid id)
        {
            HostelBookRecord? record = context.HostelBookRecords?.Find(x => x.Id == id);

            if (record is not null)
            {
                context.HostelBookRecords?.Remove(record);
            }
        }

        public IEnumerable<HostelBookRecord> GetAll()
        {
            return context.HostelBookRecords;
        }

        public HostelBookRecord? GetById(Guid id)
        {
            return context.HostelBookRecords?.Find(x => x.Id == id);
        }

        public void Update(HostelBookRecord entity)
        {
            HostelBookRecord? record = context.HostelBookRecords?.Find(x => x.Id == entity.Id);

            if (record is not null)
            {
                record = entity;
            }
        }
    }
}

