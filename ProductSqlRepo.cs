using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CodiNovaDal
{   
    public class ProductSqlRepo : IDalProductRepository
    {
        //IDalProductRepository obj = null;
        //public ProductSqlRepo()
        //{
        //    obj = ProductFactory.GetProductDataAccessObj();
        //}
        private string connectionString= ConfigurationManager.ConnectionStrings["CodiNovaEntities"].ConnectionString;
        public bool DeleteProduct(Product product)
        {

            string operation = "D";           
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Add_Edit_Product", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@operation", SqlDbType.VarChar).Value = operation;
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = product.id;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = product.name;
                        cmd.Parameters.Add("@unit_price", SqlDbType.VarChar).Value = product.unit_Price;
                        cmd.Parameters.Add("@available", SqlDbType.VarChar).Value = product.Available;
                        cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = product.Quantity;
                        cmd.Parameters.Add("@image", SqlDbType.VarChar).Value = product.image;
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return true;
        }    

        public IEnumerable<Product> GetProduct()
        {
            List<Product> lp = new List<Product>();
            string sql = "Select * from Product";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand oCmd = new SqlCommand(sql, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Product p = new Product();
                        p.name = oReader["name"].ToString();
                        p.unit_Price = Convert.ToInt32(oReader["unit_Price"].ToString());
                        p.Available = oReader["Available"].ToString();
                        p.Quantity = Convert.ToInt32(oReader["Quantity"].ToString());
                        p.image = oReader["image"].ToString();
                        lp.Add(p);
                    }
                }
            }
            return lp;
        }

        public Product GetProductById(string id)
        {
            Product lp = new Product();
            string sql = "Select * from Product where id=\'"+id+"\'";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand oCmd = new SqlCommand(sql, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Product p = new Product();
                        p.name = oReader["name"].ToString();
                        p.unit_Price = Convert.ToInt32( oReader["unit_Price"].ToString());
                        p.Available = oReader["Available"].ToString();
                        p.Quantity =Convert.ToInt32(oReader["Quantity"].ToString());
                        p.image = oReader["image"].ToString();
                        lp = p;                        
                    }
                }
            }
            return lp;
        }

        public bool Product(Product product)
        {
            string operation = string.Empty;
            if (product.id != 0)
            {
                operation = "U";
            }
            else
            {
                operation = "I";
            }
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Add_Edit_Product", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@operation", SqlDbType.VarChar).Value = operation;
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = product.id;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = product.name;
                        cmd.Parameters.Add("@unit_price", SqlDbType.VarChar).Value = product.unit_Price;
                        cmd.Parameters.Add("@available", SqlDbType.VarChar).Value = product.Available;
                        cmd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = product.Quantity;
                        cmd.Parameters.Add("@image", SqlDbType.VarChar).Value = product.image;
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {                    
                }
            }
            return true;            
        }
    }
    //public class MyContext : DbContext
    //{
    //    public MyContext()
    //        : base("name=CodiNovaEntities")
    //    { Database.SetInitializer<MyContext>(null); }
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        Database.SetInitializer<MyContext>(null);
    //        base.OnModelCreating(modelBuilder);
    //    }
    //    //public virtual DbSet<Sales> Sales { get; set; }
    //    public virtual DbSet<Product> Product { get; set; }       
    //}
}
