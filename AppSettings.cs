using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

namespace JamaicaFreight
{
	public static class AppSettings
	{
		public static string MySqlConnection
		{
			get { return ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString; }
		}
	}
}