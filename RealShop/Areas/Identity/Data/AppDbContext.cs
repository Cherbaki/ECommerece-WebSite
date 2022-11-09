using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealShop.Models;

namespace RealShop.Areas.Identity.Data;
#nullable disable
public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<IndexPageEntity> IndexPage { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Order>()
            .HasOne(or => or.Product)
            .WithMany(pr => pr.Orders)
            .HasForeignKey(or => or.ProductId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<Order>()
            .HasOne(or => or.User)
            .WithMany(us => us.Orders)
            .HasForeignKey(or => or.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        

        builder.Entity<Product>()
            .HasOne(pr => pr.User)
            .WithMany(us => us.Products)
            .HasForeignKey(pr => pr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //---------------------------------------
        builder.Entity<Image>()
            .HasOne(im => im.Product)
            .WithMany(pr => pr.Images)
            .HasForeignKey(im => im.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.Entity<Image>()
            .HasOne(im => im.ProductForMainIcon)
            .WithOne(pr => pr.MainIcon)
            .OnDelete(DeleteBehavior.NoAction);
        //---------------------------------------

        builder.Entity<Image>()
            .HasOne(im => im.Category)
            .WithOne(ca => ca.MainIcon)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<Image>()
            .HasOne(im => im.IndexPageEntityForTopImage)
            .WithOne(ipe => ipe.TopImage)
            .HasForeignKey<Image>(im => im.IndexPageEntityIdForTopImage)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<Image>()
            .HasOne(im => im.IndexPageEntityForSpecImage)
            .WithOne(ipe => ipe.SpecificImage)
            .HasForeignKey<Image>(im => im.IndexPageEntityIdForSpecImage)
            .OnDelete(DeleteBehavior.Cascade);


    }
}
