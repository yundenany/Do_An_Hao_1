namespace Do_An_Hao_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("book")]
    public partial class book
    {
        public book(int id_book, string title, string author, string decription, string images, int? public_date, string category)
        {
            this.id_book = id_book;
            this.title = title;
            this.author = author;
            this.decription = decription;
            this.images = images;
            this.public_date = public_date;
            this.category = category;
        }

        public book()
        {

        }

        [Key]
        public int id_book { get; set; }

     /*   [StringLength(255)]*/
        public string title { get; set; }

    /*    [StringLength(255)]*/
        public string author { get; set; }

      /*  [StringLength(255)]*/
        public string decription { get; set; }

       /* [StringLength(100)]*/
        public string images { get; set; }

        public int? public_date { get; set; }

   /*     [StringLength(255)]*/
        public string category { get; set; }
    }
}
