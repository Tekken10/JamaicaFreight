using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JF.Model;
using Tekken.Web.UI.WebControls;

namespace JamaicaFreight
{
	public class PortGrid : BaseGrid
	{

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			StringBuilder sb = new StringBuilder();

			List<Port> ports = (List<Port>)base.DataSource;

			sb.Append("<table>");

			foreach (Port p in ports)
			{
				sb.Append("<tr ondblclick=\"").Append("").Append("\">");
				sb.Append("<td>").Append(p.Name).Append("</td><td>").Append(p.Country.Code).Append("</td></tr>");

			}

			sb.Append("</table>");

			base.Render(writer);
		}

	}
}