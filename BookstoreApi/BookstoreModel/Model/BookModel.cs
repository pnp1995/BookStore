using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace BookstoreModel.Model
{
    public class BookModel
    {
        private int bookid;
        private string bookname;
        private string description;
        private string author;
        private int price;
        private string image;
        private string review;

        [Key]
        public int Bookid
        {
            set { this.bookid = value; }
            get { return this.bookid; }
        }
        public string Bookname
        {
            set { this.bookname = value; }
            get { return this.bookname; }
        }
        public string Description
        {
            set { this.description = value; }
            get { return this.description; }
        }
        public string Author
        {
            set { this.author = value; }
            get { return this.author; }
        }
        public int Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
        public string Image
        {
            set { this.image = value; }
            get { return this.image; }
        }

        public string Review
        {
            set { this.review = value; }
            get { return this.review; }
        }
    }
}
