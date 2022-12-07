using System;
using System.Net;
using HostelDAL.Data;
using HostelDAL.Entities;
using HostelDAL.Interfaces;

namespace HostelDAL.Repositories
{
    public class HostelAddressRepository : IHostelAddressRepository
    {
        private HostelContext context;

        public HostelAddressRepository(HostelContext context)
        {
            this.context = context;
        }
        public void Create(HostelAddress entity)
        {
            context.HostelAddresses?.Add(entity);
        }

        public void Delete(HostelAddress entity)
        {
            HostelAddress? address = context.HostelAddresses?.Find(x => x.Id == entity.Id);

            if (address is not null)
            {
                context.HostelAddresses?.Remove(address);
            }
        }

        public void DeleteById(Guid id)
        {
            HostelAddress? address = context.HostelAddresses?.Find(x => x.Id == id);

            if (address is not null)
            {
                context.HostelAddresses?.Remove(address);
            }
        }

        public IEnumerable<HostelAddress> GetAll()
        {
            return context.HostelAddresses;
        }

        public HostelAddress? GetById(Guid id)
        {
            return context.HostelAddresses?.Find(x => x.Id == id);
        }

        public void Update(HostelAddress entity)
        {
            HostelAddress? address = context.HostelAddresses?.Find(x => x.Id == entity.Id);

            if (address is not null)
            {
                address = entity;
            }
        }
    }
}

