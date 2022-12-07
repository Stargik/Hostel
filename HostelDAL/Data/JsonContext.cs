using System;
using System.Text.Json;

namespace HostelDAL.Data
{
	public class JsonContext
	{
		private string path;
		public JsonContext(string path)
		{
			this.path = path;
		}
		public T? GetContent<T>()
		{
			using (FileStream readStream = new FileStream(path, FileMode.Open))
			{
				var book = JsonSerializer.Deserialize<T>(readStream);
				return book;
			}
		}
		public void SaveContent<T>(T entity)
		{
            using (FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate))
            {
				JsonSerializer.Serialize<T>(writeStream, entity);
            }
        }
	}
}

