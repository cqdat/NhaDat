using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bds.Areas.Cpanel.Models;

namespace bds.Models
{
    public class Helper
    {
        DB_BDSEntitiesAdmin db = new DB_BDSEntitiesAdmin();

        public List<MENU> getChildMenu(int? idMenu)
        {
            return db.MENUs.Where(q => q.IdCha == idMenu).ToList();
        }
    }
}