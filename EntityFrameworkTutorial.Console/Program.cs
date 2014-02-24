using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;



using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			//var context = new OrdersContext();
			//var categories = context.Categories.Select(x => x.CategoryName).ToList();
			//InsertCategory();

			GetTableAndColumns();
		}

		static void InsertCategory()
		{
			var category = new Category
				{
					CategoryName = "Tempxxxxxx",
					Description = "Temp Descxxxxxx"
				};

			using (var ctx = new OrdersContext())
			{
				ctx.Categories.Add(category);
				ctx.SaveChanges();
			}
		}


		//http://romiller.com/2012/04/20/what-tables-are-in-my-ef-model-and-my-database/
		static void GetTableAndColumns()
		{
			using (var db = new OrdersContext())
			{
				var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;

				var tables = metadata.GetItemCollection(DataSpace.SSpace)
				  .GetItems<EntityContainer>()
				  .Single()
				  .BaseEntitySets
				  .OfType<EntitySet>()
				  .Where(s => !s.MetadataProperties.Contains("Type") || s.MetadataProperties["Type"].ToString() == "Tables");

				var tableNames = new List<string>();

				foreach (var table in tables)
				{
					var tableName = table.MetadataProperties.Contains("Table") && table.MetadataProperties["Table"].Value != null
					  ? table.MetadataProperties["Table"].Value.ToString()
					  : table.Name;

					var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
					tableNames.Add(tableSchema + "." + tableName);
					//System.Console.WriteLine(tableSchema + "." + tableName);
				}

			}
		}

	}
}
