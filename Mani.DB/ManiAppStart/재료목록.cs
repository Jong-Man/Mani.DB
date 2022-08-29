﻿using System;
using System.Collections.Generic;

namespace Mani.DB.maniAppStart
{
    public partial class 재료목록
    {
        public 재료목록()
        {
            요리재료 = new HashSet<요리재료>();
        }

        public int Id { get; set; }
        public string 재료명 { get; set; } = null!;
        public string 단위 { get; set; } = null!;
        public int 중요도 { get; set; }
        public int 사용빈도 { get; set; }
        public double 남은수 { get; set; }
        public bool 구매요망 { get; set; }

        public virtual ICollection<요리재료> 요리재료 { get; set; }
    }
}
