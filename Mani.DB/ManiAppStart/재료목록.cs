using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 재료목록
    {
        public int Id { get; set; }
        public string 재료명 { get; set; } = null!;
        public string 단위 { get; set; } = null!;
        public int 중요도 { get; set; }
        public int 사용빈도 { get; set; }
        public double 남은수 { get; set; }
        public bool 구매요망 { get; set; }
    }
}
