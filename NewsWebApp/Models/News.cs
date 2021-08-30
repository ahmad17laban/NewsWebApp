using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class News
    {
        public int Id { get; set; }
        [DisplayName("Title of the News ")]
        public string Title { get; set; }
        public DataType Date{ get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }

        // relation between News and Category is 1-* A category has many News 
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    
       
    }

}
