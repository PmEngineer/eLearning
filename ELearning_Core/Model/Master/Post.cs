using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class Post:BaseEntity
    {
      
        public string Image {  get; set; }
        public string? Description {  get; set; }
        public int TotalComment { get; set; }
        public int TotalView { get; set; }
        public bool IsActive {  get; set; }
        public bool IsExplore {  get; set; }
        public bool IsBuyNow { get; set; }
      

    }
}
