using Microsoft.EntityFrameworkCore;
using Razor.Introduction.Tag.Helper.Web.Models;
using System;

namespace Razor.Introduction.Tag.Helper.Web.DatabaseContexts
{
    public class UserDatabaseContext: DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
