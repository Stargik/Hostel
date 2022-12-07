using System;
using HostelBLL.Models;

namespace HostelBLL.Interfaces
{
	public interface IHostelBookRecordService
	{
		List<HostelBookRecordModel> GetAll();
		HostelBookRecordModel GetById(Guid id);

        List<HostelBookRecordModel> GetByStudent(StudentModel studentModel);
        List<HostelBookRecordModel> GetByAddress(HostelAddressModel hostelAddressModel);
        List<HostelBookRecordModel> GetByDate(FilterDateModel filterDateModel);

		void AddRecord(HostelBookRecordModel hostelBookRecordModel);
		void Remove(Guid id);
		void Update(Guid id, HostelBookRecordModel hostelBookRecordModel);

	}
}

