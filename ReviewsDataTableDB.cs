using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class ReviewsDataTableDB
    {
        static DataTable productReviews=null;
        
        public static void PrintDataTable()
        {
            foreach (var row in productReviews.AsEnumerable())
            {
                foreach (var item in row.ItemArray)
                    Console.Write(item + " ");
                Console.WriteLine();
            }

        }

        public void CreateDataTable()
        {
            productReviews = new DataTable();
            productReviews.Columns.Add("ProductID", Type.GetType("System.Int32"));
            productReviews.Columns.Add("UserID", Type.GetType("System.Int32"));
            productReviews.Columns.Add("Rating", Type.GetType("System.Decimal"));
            productReviews.Columns.Add("Review", Type.GetType("System.String"));
            productReviews.Columns.Add("isLike", Type.GetType("System.Boolean"));

            productReviews.Columns["ProductId"].DefaultValue = 0;
            productReviews.Columns["UserID"].DefaultValue = 0;
            productReviews.Columns["Rating"].DefaultValue = 0;
            productReviews.Columns["Review"].DefaultValue = null;
            productReviews.Columns["isLike"].DefaultValue = false;
        }

        public void Add25Defaults()
        {
            for(int i=0;i<25;i++)
                productReviews.Rows.Add();

            PrintDataTable();
        }
    }
}
