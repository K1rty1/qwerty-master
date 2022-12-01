using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qwerty.Model
{
    public partial class Product
    {
       
        public string ImagePath
        {
            get
            {
                if (Image == null)
                {
                    return "..\\Assets\\Images\\picture.png";
                }
                else
                {
                    return "../Assets/Images" + Image;
                }

            }
        }
        public string MaterialList
        {
            get
            {
                string materials = "";
                List<string> arrayMaterial = new List<string> { };
                foreach (var item in collection)
                {

                }
                materials = String.Join(",", arrayMaterial);
                return materials;
            }

        }
        public string CostProduct
        {
            get
            {
               
                string materials = "";
                return materials;
            }

        } 

    }
}
