using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qwerty.Model
{
    public partial class Core
    {
        public TiresCompanyEntities context = new TiresCompanyEntities();
        public string ImagePath { get {
                if (Image==null)
                {
                    return "..\\Assets\\Images\\picture.png";
                }
                else
                {
                return ""+Image;
                }

            } }
    }
}
