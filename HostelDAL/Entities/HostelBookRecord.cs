using System;
namespace HostelDAL.Entities
{
	public class HostelBookRecord
	{
		public Guid Id { get; set; }
		public Guid RoomId { get; set; }
		public Guid StudentId { get; set; }
		public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
		public HostelAddress? HostelAddress { get; set; }
		public Student? Student { get; set; }
    }
}

