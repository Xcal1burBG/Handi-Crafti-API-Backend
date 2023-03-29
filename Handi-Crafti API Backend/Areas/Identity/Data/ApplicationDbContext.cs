using Handi_Crafti_API_Backend.DataBase.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace Handi_Crafti_API_Backend.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Handi-Crafti;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");
    }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>(entity => { entity.ToTable(name: "Users").Property(x => x.Id).HasColumnType("uniqueidentifier"); });
        builder.Entity<Role>(entity => { entity.ToTable(name: "Roles").Property(x => x.Id).HasColumnType("uniqueidentifier"); });
        builder.Entity<IdentityUserRole<Guid>>(entity => { entity.ToTable("UserRoles").HasKey(p => new { p.UserId, p.RoleId }); ; });

        builder.Entity<Offer>()
            .HasOne(x => x.HandiCrafter)
            .WithMany(y => y.Offers)
            .HasForeignKey(x => x.HandiCrafterId)
            .HasConstraintName("FK_Offer_HandiCrafterId");
        builder.Entity<Message>()
            .HasOne(x => x.Receiver)
            .WithMany(y => y.Messages)
            .HasForeignKey(x => x.ReceiverId)
            .HasConstraintName("FK_Message_ReceiverId")
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Review>()
            .HasOne(x => x.HandiCrafter)
            .WithMany(y => y.Reviews)
            .HasForeignKey(x => x.HandiCrafterId)
            .HasConstraintName("FK_Review_HandiCrafterId")
            .OnDelete(DeleteBehavior.NoAction); ;

    }
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }

}
