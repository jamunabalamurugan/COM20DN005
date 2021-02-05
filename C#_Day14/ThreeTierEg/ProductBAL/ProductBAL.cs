using System;
using System.Data;
using ProductDALDemo;


namespace ProductBALDemo
{
    public class ProductBAL
    {
        public ProductDAL dalobj = new ProductDAL();

        public DataSet SelectDataBAL()
        {
            DataSet ds = dalobj.SelectData();
            return ds;
            //if (ds.Tables.Count > 0)
            //    return ds;
            //else
            //    return null;
        }

        public int InsertBAL(Product p)
        {
            if (p.UnitPrice > 5000 || p.UnitPrice < 0)
                return 0;
            else
            {
                int rows = dalobj.InsertData(p);
                return rows;
            }
        }


    }
}
