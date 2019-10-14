﻿namespace ProductApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}