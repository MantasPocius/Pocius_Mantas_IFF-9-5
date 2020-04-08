using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pocius_Mantas_IFF_9_5
{
    public class TaskUtils
    {
        public static void DisplayModuleData(MyList list, Table table)
        {
            TableHeaderRow header = new TableHeaderRow();
            header.Cells.Add(new TableHeaderCell() { Text = "ModuleName" });
            header.Cells.Add(new TableHeaderCell() { Text = "Surame" });
            header.Cells.Add(new TableHeaderCell() { Text = "Name" });
            header.Cells.Add(new TableHeaderCell() { Text = "Credits" });
            table.Rows.Add(header);
            for (list.Begin(); list.Exist(); list.Next())
            {
                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell() { Text = list.Get().ModuleName });
                tr.Cells.Add(new TableCell() { Text = list.Get().Surname });
                tr.Cells.Add(new TableCell() { Text = list.Get().Name });
                tr.Cells.Add(new TableCell() { Text = list.Get().Credits.ToString() });
                table.Rows.Add(tr);
            }
        }
    }
}