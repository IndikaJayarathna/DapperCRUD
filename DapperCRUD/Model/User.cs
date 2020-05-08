using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD.Model
{
    /// <summary>
    /// This is the model that we're using to perform CRUD functions
    /// </summary>
    public class User
    {
        [Key]
        public int UId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
