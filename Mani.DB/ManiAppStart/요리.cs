using System;
using System.Collections.Generic;

namespace Mani.DB.maniAppStart
{
    public partial class 요리
    {
        public 요리()
        {
            관련내용s = new HashSet<관련내용>();
            요리재료s = new HashSet<요리재료>();
        }

        public int Id { get; set; }
        public string 요리명 { get; set; } = null!;
        public string 요리방법 { get; set; } = null!;
        public string 간단설명 { get; set; } = null!;
        public string 분류 { get; set; } = null!;

        public virtual ICollection<관련내용> 관련내용s { get; set; }
        public virtual ICollection<요리재료> 요리재료s { get; set; }
    }
}
