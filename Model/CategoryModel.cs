using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryModel
    {
        private HocMVCdbConnect context = null;
        public CategoryModel()
        {
            context = new HocMVCdbConnect();
        }
        public List<Category> ListAll()
        {
            var category = context.Database.SqlQuery<Category>("usp_listcategory").ToList();
            return category;
        }
    }
}
