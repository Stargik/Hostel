using System;
namespace HostelDAL.Entities
{
	public class HostelAddress
	{
		public Guid Id { get; set; }
		public string? Address { get; set; }
		public int? RoomNumber { get; set; }
	}
}

