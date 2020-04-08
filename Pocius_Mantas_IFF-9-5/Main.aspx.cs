using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pocius_Mantas_IFF_9_5
{
    public partial class Main : System.Web.UI.Page
    {
        private List<Student> students = new List<Student>();
        private MyList modules = new MyList();

        protected void Page_Load(object sender, EventArgs e)
        {
            string studentFileName = (HttpContext.Current.Server.MapPath($"./App_Data/U1a.txt"));
            string moduleFileName = (HttpContext.Current.Server.MapPath($"./App_Data/U1b.txt"));
            students = InOut.ReadStudentData(studentFileName);
            modules = InOut.ReadModuleData(moduleFileName);
            TaskUtils.DisplayModuleData(modules,Table1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}