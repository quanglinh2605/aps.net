namespace Modelclass.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model11 : DbContext
    {
        public Model11()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Mailgroup> Mailgroups { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<SendMail> SendMails { get; set; }
        public virtual DbSet<Temp_User> Temp_User { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Occasions)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ImageCate)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Descriptions)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Templates)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeedBack>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<FeedBack>()
                .Property(e => e.Phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<FeedBack>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Mailgroup>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SendMail>()
                .Property(e => e.Sendby)
                .IsUnicode(false);

            modelBuilder.Entity<SendMail>()
                .Property(e => e.Receiver)
                .IsUnicode(false);

            modelBuilder.Entity<Temp_User>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Temp_User>()
                .HasMany(e => e.SendMails)
                .WithRequired(e => e.Temp_User)
                .HasForeignKey(e => e.IDtemp_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.Descriptions)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.ImageTem)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Temp_User)
                .WithRequired(e => e.Template)
                .HasForeignKey(e => e.TempID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FeedBacks)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDMem);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Mailgroups)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IDMem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IDMem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Temp_User)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
