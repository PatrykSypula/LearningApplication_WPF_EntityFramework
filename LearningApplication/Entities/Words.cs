using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Entities
{
    public class Words
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public string WordPolish { get; set; }
        [Column(TypeName = "varchar")]
        public string WordEnglish { get; set; }
        public int CardStackId { get; set; }
        public CardStacks CardStack { get; set; }
    }
}
