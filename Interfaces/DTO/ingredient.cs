using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces.DTO
{
    public class ingredientDto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ingredient()
        //{
        //    ingredient_string = new HashSet<ingredient_string>();
        //}

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public int price { get; set; }

        public int? storage { get; set; }
        public string name { get; set; }
        public string lost { get; set; }
        public ingredientDto() { }
        public ingredientDto(ingredient o)
        {
            id = o.id;
            storage = o.storage;
            price = (int)o.price;
            name = o.name;
            
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ingredient_string> ingredient_string { get; set; }
    }
}
