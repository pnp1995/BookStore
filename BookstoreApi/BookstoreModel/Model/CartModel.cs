using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookstoreModel.Model
{
  public class CartModel
  {
        [Key]
        public long Cartid { get; set; }

        //[ForeignKey("BookModel")]
        public long Bookid { get; set; }

        public int Count { get; set; }
  }

}
