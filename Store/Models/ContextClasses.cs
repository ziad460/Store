using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public enum Size
    {
        size_XL = 0,
        size_L = 1,
        size_S = 2,
        size_M = 4
    }
    public enum Color
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 4,
        Black = 8,
        White = 16
    }
    public enum PaymentMethod
    {
        HandCash = 0,
        Paypal = 1,
    }
    [Table("Blog")]
    public class Blog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Blog_ID { get; set; }

        [Required, MaxLength(100)]
        public string Blog_Title { get; set; }
        [Required]
        public string Blog_Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime Blog_Date { get; set; }
        public virtual List<BlogTags> BlogTags { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<BlogImages> BlogImages { get; set; }
    }
    public class BlogImages
    {
        public int ID { get; set; }
        public int Blog_ID { get; set; }

        [Required, MaxLength(50)]
        public string Image { get; set; }

        [ForeignKey("Blog_ID")]
        public virtual Blog Blog { get; set; }
    }
    public class BlogTags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogTags_ID { get; set; }
        public int? Blog_ID { get; set; }
        public int? Tag_ID { get; set; }

        [ForeignKey("Blog_ID")]
        public virtual Blog Blog { get; set; }

        [ForeignKey("Tag_ID")]
        public virtual Tags Tags { get; set; }
    }
    [Table("Category")]
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }
        [Required, MaxLength(50)]
        public string Category_Name { get; set; }
        public string Category_Describtion { get; set; }

        public virtual List<Product> Products { get; set; }
    }
    [Table("Comment")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Comment_ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Customer_ID { get; set; }

        public int Blog_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Comment_Date { get; set; }

        [ForeignKey("Blog_ID")]
        public virtual Blog Blog { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual ApplicationUser Customer { get; set; }
    }
    [Table("Order")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }
        [Required]
        public string Customer_ID { get; set; }
        public int? Shipping_ID { get; set; }
        public int? Payment_ID { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Order_Total { get; set; }
        public int Order_Status { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual ApplicationUser Customer { get; set; }
        [ForeignKey("Shipping_ID")]
        public virtual Shipping Shipping { get; set; }
        [ForeignKey("Payment_ID")]
        public virtual Payment Payment { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
    public class OrderDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetails_ID { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        [Range(1, 20)]
        public int Product_Quantity { get; set; }
        public Color Product_Color { get; set; }
        public Size? Product_Size { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total_price { get; set; }

        [ForeignKey("Order_ID")]
        public virtual Order Order { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
    [Table("Payment")]
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_ID { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
    [Table("Product")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }
        [Required, MaxLength(50)]
        public string Product_Name { get; set; }
        public int? Category_ID { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Product_Price { get; set; }
        [Required]
        public Size? Product_Size { get; set; }
        public Color Product_Color { get; set; }

        [Column(TypeName = "date")]
        public DateTime Adding_Date { get; set; }
        public int Popularity { get; set; }
        public int Stored_Quantity { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
        public virtual List<ProductTags> ProductTags { get; set; }
        public virtual List<UserWishList> UserWishLists { get; set; }
        public virtual List<ProductsImages> ProductsImages { get; set; }
    }
    public class ProductsImages
    {
        public int ID { get; set; }
        public int Product_ID { get; set; }

        [Required, MaxLength(50)]
        public string Image { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
    public class ProductTags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTags_ID { get; set; }
        public int? Product_ID { get; set; }
        public int? Tag_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        [ForeignKey("Tag_ID")]
        public virtual Tags Tags { get; set; }
    }
    [Table("Shipping")]
    public class Shipping
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shipping_ID { get; set; }
        public string Customer_ID { get; set; }
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string Shipping_Email { get; set; }
        public int? Postal_Code { get; set; }
        public string Notes { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual ApplicationUser Customer { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string Address { get; set; }
    }
    public class Tags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tag_ID { get; set; }
        [Required, MaxLength(50)]
        public string Tag_Name { get; set; }
        public string Tag_Description { get; set; }

        public virtual List<ProductTags> ProductTags { get; set; }

        public virtual List<BlogTags> BlogTags { get; set; }
    }
    [Table("UserWishList")]
    public class UserWishList
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserWishList_ID { get; set; }
        [Required]
        public string Customer_ID { get; set; }
        public int Product_ID { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual ApplicationUser Customer { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
}
