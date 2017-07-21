using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL = DataAccess;


namespace BusinessLogic
{
    public class Cluster
    {
        public static DataSet GetCluster(string conSTR)
        {
            return DAL.Cluster.GetCluster(conSTR);
        }
        public static DataSet GetClusterVyId(Guid ClusterID, string conSTR)
        {
            return DAL.Cluster.GetClusterbyID(ClusterID, conSTR);
        }
        public static void DeleteCluster(Guid ClusterId, int Flag, string conStr)
        {
            DAL.Cluster.DeleteCluster(ClusterId, Flag, conStr);
        }

        public static void UpdateCluster(Guid ClusterID, Guid BranchCorpID, Guid ModifiedBy, string ClusterName, string conSTR)
        {
            DAL.Cluster.UpdateCluster(ClusterID, BranchCorpID, ModifiedBy, ClusterName, conSTR);


        }
        public static void InsertCluster(Guid BranchCorpID, Guid ModifiedBy, string ClusterName, string conSTR)
        {
            DAL.Cluster.InsertCluster( BranchCorpID, ModifiedBy, ClusterName, conSTR);

        }


    }
}
