using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Management
    {
        public DataTable dataTable = new DataTable();

        public void TopRecords(List<ProductReview> reviews)
        {
            var recordedData = (from productReview in reviews
                                orderby productReview.Rating descending
                                select productReview).Take(3);

            foreach (var record in recordedData)
                Console.WriteLine("ProductID: "+record.ProductId + " " + " UserId: " + record.UserId + " " + " Rating: " + record.Rating + " " + " Review: " + record.Review+ " Liked: " +record.isLike);
        }
    }
}
