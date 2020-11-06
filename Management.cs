﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Management
    {
        public DataTable dataTable = new DataTable();


        /// <summary>
        /// Retrieves the Top records.
        /// </summary>
        /// <param name="reviews">The reviews.</param>
        public void TopRecords(List<ProductReview> reviews)
        {
            var recordedData = (from productReview in reviews
                                orderby productReview.Rating descending
                                select productReview).Take(3);

            foreach (var record in recordedData)
                Console.WriteLine("ProductID: " + record.ProductId + " " + " UserId: " + record.UserId + " " + " Rating: " + record.Rating + " " + " Review: " + record.Review + " Liked: " + record.isLike);
        }

        public void SelectRecords(List<ProductReview> reviews)
        {
            var recordedData = (from productReview in reviews
                                where ((productReview.ProductId == 1) || (productReview.ProductId == 4) || (productReview.ProductId == 9)) && (productReview.Rating > 3)
                                select productReview);

            foreach (var record in recordedData)
                Console.WriteLine("ProductID: " + record.ProductId + " " + " UserId: " + record.UserId + " " + " Rating: " + record.Rating + " " + " Review: " + record.Review + " Liked: " + record.isLike);
        }

        public void GetReviewCountByProduct(List<ProductReview> reviews)
        {
            var Data = reviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var product in Data)
            {
                Console.WriteLine("ProductId: "+product.ProductId + " Count: " + product.Count);
            }
        }

        public void GetReviews(List<ProductReview> reviews)
        {
            var Data = from productReview in reviews
                       select new { productReview.ProductId, productReview.Review };
            foreach (var product in Data)
            {
                Console.WriteLine("ProductId: " + product.ProductId + " Count: " + product.Review);
            }
        }
    }
}
