using proyectoFinalSI.Models;
using System.Web;
using System.Web.Mvc;

namespace proyectoFinalSI
{
    public class IdentityConfig
    {
        private citappDb db = new citappDb();
        private void InitializeIdentityForEF()
        {
            Admin s = new Admin();
            s.Id = 1;
            s.userName = "admin";
            s.password = "admin";
            db.Admin.Add(s);
            db.SaveChanges();
        }
    }
}
