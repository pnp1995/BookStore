using BookstoreModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepository.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<UserModel> UserTable { get; set; }
        public DbSet<BookModel> BookTable { get; set; }

        public DbSet<CartModel> CartTable { get; set; }

        public DbSet<CustomerModel> CustomerTable { get; set; }
    }
}
