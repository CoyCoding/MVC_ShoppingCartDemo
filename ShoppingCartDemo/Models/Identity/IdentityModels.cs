using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDemo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Image> Images { get; set; }

        int SaveChanges();

        void SaveProduct(Product product);

        void DeleteProduct(int id);
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Product> Products {get; set;}
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public void SaveProduct(Product product)
        {
            if(product.Id == 0)
            {
                this.Products.Add(product);
                AddImages(product);
            }
            else
            {
                Product dbProduct = this.Products.Find(product.Id);
                if(dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Price = product.Price;
                    dbProduct.Quantity = product.Quantity;
                    dbProduct.Seller = product.Seller;
                    dbProduct.CategoryId = product.CategoryId;
                    dbProduct.Description = product.Description;
                    AddImages(product);
                }
            }
            this.SaveChanges();
        }

       

        public void AddImages(Product product)
        {
            foreach(var image in product.Images)
            {
                var dbImage = this.Images.Find(image.Id);

                if (dbImage != null)
                {
                    dbImage.ImageData = image.ImageData;
                    dbImage.ImageType = image.ImageType;
                    dbImage.ImageName = image.ImageName;
                    dbImage.ProductId = product.Id;
                }
                else
                {
                    this.Images.Add(new Image {
                        ImageData = image.ImageData,
                        ImageType = image.ImageType,
                        ImageName = image.ImageName,
                        ProductId = product.Id
                    });
                }
            }

            this.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            //Product dbProduct = this.Products.Find(id);
            //Image dbImage = this.Images.Find(dbProduct.ImageId);

            //if (dbProduct != null)
            //{
            //    this.Products.Remove(dbProduct);
            //    this.SaveChanges();
            //}
        }

        public void DeleteImage()
        {

        }
    }

}