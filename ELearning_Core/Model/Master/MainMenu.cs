using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearning_Core.Shared;

namespace ELearning_Core.Model
{
    public class MainMenu: BaseEntity
    {
        [StringLength(100)]
        public string MainMenuName { get; set; }
        [StringLength(100)]
        public string MenuURL { get; set; }
        [StringLength(100)]
        public string MenuPriority { get; set; }
        
        public bool IsMenuActive { get; set; }
    }
}
