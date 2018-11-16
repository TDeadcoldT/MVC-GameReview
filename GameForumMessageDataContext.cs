using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcGameReview.Models
{
    public class GameForumMessagesDataContext : DbContext
    {
        public DbSet<GameForumMessage> GameForumMessages { get; set; }

        static GameForumMessagesDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GameForumMessagesDataContext>());
        }
    }
}