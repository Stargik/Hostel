using System;
namespace HostelDAL.Interfaces
{
	public interface IUnitOfWork
	{
		IStudentRepository StudentRepository { get; }
		IHostelAddressRepository HostelAddressRepository { get; }
		IHostelBookRecordRepository HostelBookRecordRepository { get; }
		void Save();
	}
}

