using System;
using HostelDAL.Entities;

namespace HostelBLL.Models
{
	public class HostelBookRecordModel
	{
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public HostelAddressModel? HostelAddress { get; set; }
        public StudentModel? Student { get; set; }
    }
}

