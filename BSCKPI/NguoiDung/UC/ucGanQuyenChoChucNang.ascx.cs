using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.NguoiDung;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.NguoiDung.UC
{
    public partial class ucGanQuyenChoChucNang : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {

            }
        }

        #region Rieng
        #endregion

        #region Su kien
        protected void DanhSachQuuyenCuaChucNang(object sender, StoreReadDataEventArgs e)
        {

        }
        #endregion
    }
}