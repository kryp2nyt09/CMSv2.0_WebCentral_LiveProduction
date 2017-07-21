using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Graph
    {
        public static DataSet GetAllMonths(string conSTR)
        {
            return DAL.Graph.GetAllMonths(conSTR);
        }
    }
}
