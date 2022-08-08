using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_linq_country.Models
{
        public class Category
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            public string Name { get; set; }


            public Guid? ParentCategoryId { get; set; }
            virtual public Category ParentCategory { get; set; }

            virtual public ICollection<Category> ChildCategories { get; set; }

        }
}
