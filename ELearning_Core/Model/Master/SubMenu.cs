using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearning_Core.Shared;
using ELearning_Core.Model;

namespace ELearning_Core.Core.Model
{
    public class SubMenu:BaseEntity
    {
        public int MainMenuId { get; set; }
        [ForeignKey("MainMenuId")]
        public virtual MainMenu MainMenu { get; set; }
        [StringLength(100)]
        public string SubMenuName { get; set; }
        [StringLength(100)]
        public string MenuUrl { get; set;}
        [StringLength(100)]
        public string MenuPriority { get; set;}

        public bool IsSubMenuActive { get; set; }
    }
}
