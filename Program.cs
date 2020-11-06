using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product review management problem statement");
            List<ProductReview> productReviews = new List<ProductReview>()
            {
                new ProductReview(){ProductId=1,UserId=1,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductId=2,UserId=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductId=3,UserId=2,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductId=3,UserId=2,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductId=4,UserId=2,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductId=5,UserId=3,Rating=2,Review="nice",isLike=false},
                new ProductReview(){ProductId=6,UserId=4,Rating=1,Review="Bad",isLike=false},
                new ProductReview(){ProductId=1,UserId=3,Rating=1.5,Review="Good",isLike=false},
                new ProductReview(){ProductId=1,UserId=3,Rating=1.5,Review="Good",isLike=false},
                new ProductReview(){ProductId=11,UserId=10,Rating=4,Review="nice",isLike=true},
                new ProductReview(){ProductId=10,UserId=10,Rating=8,Review="nice",isLike=true},
                new ProductReview(){ProductId=10,UserId=10,Rating=8,Review="nice",isLike=true},
                new ProductReview(){ProductId=10,UserId=10,Rating=8,Review="nice",isLike=true},
                new ProductReview(){ProductId=12,UserId=10,Rating=7,Review="nice",isLike=true},
                new ProductReview(){ProductId=13,UserId=10,Rating=9,Review="nice",isLike=true},
                new ProductReview(){ProductId=13,UserId=10,Rating=9,Review="nice",isLike=true},
                new ProductReview(){ProductId=14,UserId=10,Rating=4,Review="nice",isLike=true},
                new ProductReview(){ProductId=15,UserId=10,Rating=4,Review="nice",isLike=true},
                new ProductReview(){ProductId=16,UserId=10,Rating=4,Review="nice",isLike=true},
            };

            Management management = new Management();
            management.TopRecords(productReviews);
            Console.WriteLine("---");
            management.SelectRecords(productReviews);
            Console.WriteLine("---");
            management.GetReviewCountByProduct(productReviews);
            Console.WriteLine("---");
            management.GetReviews(productReviews);
            Console.WriteLine("---");
            management.GetFrom6th(productReviews);

            Console.WriteLine("\nDataTable Data");
            ReviewsDataTableDB dB = new ReviewsDataTableDB();
            dB.CreateDataTable();
            Console.WriteLine("---");
            //dB.Add25Defaults();   //UC8
            dB.AddData();
            dB.GetAllLikedReviews();
            Console.WriteLine("---");
            dB.GetAverageRating();
            Console.ReadLine();
        }
    }
}
