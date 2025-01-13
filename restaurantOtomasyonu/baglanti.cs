using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace restaurantOtomasyonu
{
    class baglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-RO4FTV6\SQLEXPRESS;Initial Catalog=restaurantOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
