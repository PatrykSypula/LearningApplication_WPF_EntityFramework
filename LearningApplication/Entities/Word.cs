﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string WordPolish { get; set; }
        public string WordEnglish { get; set; }
        public int CardStackId { get; set; }
        public CardStack CardStack { get; set; }
    }
}
