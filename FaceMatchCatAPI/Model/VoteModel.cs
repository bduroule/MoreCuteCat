﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VoteModel
    {
        public IEnumerable<Cat> ParticipatingCats { get ; set; }
        public string WinnerCatId { get; set; }
    }
}
