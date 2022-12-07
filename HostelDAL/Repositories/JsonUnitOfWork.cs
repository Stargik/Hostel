using System;
using HostelDAL.Data;
using HostelDAL.Interfaces;
using HostelDAL.Models;

namespace HostelDAL.Repositories
{
	public class JsonUnitOfWork : IUnitOfWork
	{
        private HostelContext context;
        private IStudentRepository? studentRepository;
        private IHostelAddressRepository? hostelAddressRepository;
        private IHostelBookRecordRepository? hostelBookRecordRepository;


		public JsonUnitOfWork(string jsonPath)
		{
            context = new HostelContext(jsonPath);
		}

        public IStudentRepository StudentRepository
        {
            get
            {
                if (studentRepository is null)
                {
                    studentRepository = new StudentRepository(context);
                }
                return studentRepository;
            }
        }

        public IHostelAddressRepository HostelAddressRepository
        {
            get
            {
                if (hostelAddressRepository is null)
                {
                    hostelAddressRepository = new HostelAddressRepository(context);
                }
                return hostelAddressRepository;
            }
        }

        public IHostelBookRecordRepository HostelBookRecordRepository
        {
            get
            {
                if (hostelBookRecordRepository is null)
                {
                    hostelBookRecordRepository = new HostelBookRecordRepository(context);
                }
                return hostelBookRecordRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

