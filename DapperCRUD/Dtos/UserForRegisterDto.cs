using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD.Dtos
{
    /// <summary>
    /// DTO for match data with sources
    /// </summary>
    public class UserForRegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
