﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MS3_LMS.Enity.Book
{
    public class Image
    {
        [Key]
        public Guid ID { get; set; }
        public string? Image1Path { get; set; }
        public string? Image2Path { get; set; }
        public Guid Bookid { get; set; }
        
        public  Book? Book { get; set; }
    }

}
