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
            productReviews.Columns.Add("Rating", Type.GetType("System.Int32"));
            productReviews.Columns.Add("Review", Type.GetType("System.String"));
            productReviews.Columns.Add("isLike", Type.GetType("System.Boolean"));

            productReviews.Columns["ProductID"].DefaultValue = 0;
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

        public void AddData()
        {
            productReviews.Rows.Add(1, 1001, 3, "nice", true);
            productReviews.Rows.Add(2, 1002, 4, "Good", true);
            productReviews.Rows.Add(3, 1003, 3, "Old", false);
            productReviews.Rows.Add(1, 1002, 1, "Bad", false);
            productReviews.Rows.Add(4, 1003, 3, "Okay", true);
            productReviews.Rows.Add(3, 1004, 0, "Very Bad", false);
            productReviews.Rows.Add(2, 1004, 5, "Good", true);
            productReviews.Rows.Add(1, 1004, 4, "nice", true);
        }

        public void GetAllLikedReviews()
        {
            var Data = from productReview in productReviews.AsEnumerable()
                       where (bool)productReview["isLike"] == true
                       select productReview;

            foreach (var row in Data)
                Console.WriteLine("User " + row["UserId"] + " liked Product " + row["ProductID"] + " with a rating of " + row["Rating"]+", Review :"+row["Review"]);
        }

        public void GetAverageRating()
        {
            var Data = from productReview in productReviews.AsEnumerable()
                       group productReview by (int)productReview["ProductID"] into newTable
                       select new { ProductId = newTable.Key, Average = newTable.Average(x => (int)x["Rating"]) };

            foreach (var row in Data)
                Console.WriteLine("Product: " + row.ProductId + " Average: " + row.Average);
        }
    }
}
