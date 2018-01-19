using System.Data.Entity;

namespace WebApiQR.Models
{
    public class WebApiQRContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WebApiQR.Models.WebApiQRContext>());

        public WebApiQRContext() : base("name=WebApiQRContext")
        {
            Configuration.ProxyCreationEnabled = false;//this is line to be added
        }

        public DbSet<QR_CODE> QR_CODE { get; set; }
        public DbSet<INFORMATIONS> INFORMATIONS { get; set; }
    }
}
