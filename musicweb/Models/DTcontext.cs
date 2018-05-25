using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace musicweb.Models
{
    public class DTcontext:DbContext
    {

        public DTcontext() : base("musicwebDatabase")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<song> songList { get; set; }
        public virtual DbSet<album> albumList { get; set; }
        public virtual DbSet<users> userList { get; set; }
        public virtual DbSet<video> videoList { get; set; }
        public virtual DbSet<admins> adminList { get; set; }
        public virtual DbSet<usersong> userSongList { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DTinti());
        }
    }
    
}