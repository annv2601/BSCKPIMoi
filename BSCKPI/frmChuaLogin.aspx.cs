using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSCKPI
{
    public partial class frmChuaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangNhap_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
}