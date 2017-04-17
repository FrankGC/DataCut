using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlClient;
namespace DataCut
{
    public class ClasseGlobal
    {
        static Frame FM;
        public Frame fm
        {
            get { return FM; }
            set { FM = value; }
        }

        static ConeccionSQL SQLCMD;
        public ConeccionSQL CM
        {
            get { return SQLCMD; }
            set { SQLCMD = value; }
        }



    }
}
