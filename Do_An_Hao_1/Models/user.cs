namespace Do_An_Hao_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class user
    {
        private DbModel db = new DbModel();
        public int id { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string pass { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public bool? role { get; set; }

        public bool check_user_name(string name)
        {
            return db.users.Count(x => x.name == name) > 0;
        }

        public bool check_user_email(string email)
        {
            return db.users.Count(x => x.email == email) > 0;
        }
    }
}
