using System;
using HostelDAL.Entities;

namespace HostelDAL.Models
{
	public class HostelJson
	{
		public List<Student>? Students { get; set; }
		public List<HostelAddress>? HostelAddresses { get; set; }
		public List<HostelBookRecord>? HostelBookRecords { get; set; }
	}
}

