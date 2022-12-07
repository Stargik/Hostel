using System;
using HostelDAL.Entities;
using HostelDAL.Models;

namespace HostelDAL.Data
{
	public class HostelContext : JsonContext
	{
		public List<Student>? Students { get; set; }
		public List<HostelAddress>? HostelAddresses { get; set; }
		public List<HostelBookRecord>? HostelBookRecords { get; set; }
		public HostelContext(string path) : base(path)
		{
			Initialize();
		}
		private void Initialize()
		{
			var book = this.GetContent<HostelJson>();
			Students = book?.Students;
			HostelAddresses = book?.HostelAddresses;
			HostelBookRecords = book?.HostelBookRecords;
		}
		public void SaveChanges()
		{
			var book = new HostelJson() { Students = this.Students, HostelBookRecords = this.HostelBookRecords, HostelAddresses = this.HostelAddresses };
			this.SaveContent<HostelJson>(book);

        }
	}
}

