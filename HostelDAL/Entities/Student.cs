using System;
namespace HostelDAL.Entities
{
	public class Student
	{
		public Guid Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? SurName { get; set; }
		public string? Email { get; set; }
		public int? Course { get; set; }
		public string? Department { get; set; }
	}
}

