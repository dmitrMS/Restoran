namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.ingredient_string")]
    public partial class ingredient_string
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? id_ingredient { get; set; }

        public int? numb_ingr { get; set; }

        public int? price { get; set; }

        public int? id_dish { get; set; }

        public virtual dish dish { get; set; }

        public virtual ingredient ingredient { get; set; }
    }
}
