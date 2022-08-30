using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 요리
    {
        public 요리()
        {
            관련내용S = new HashSet<관련내용>();
            레시피S = new HashSet<레시피>();
            요리재료S = new HashSet<요리재료>();
        }

        public int ID { get; set; }
        public string 요리명 { get; set; } = null!;
        public string 요리방법 { get; set; } = null!;
        public string 간단설명 { get; set; } = null!;
        public string 분류 { get; set; } = null!;

        public virtual ICollection<관련내용> 관련내용S { get; set; }
        public virtual ICollection<레시피> 레시피S { get; set; }
        public virtual ICollection<요리재료> 요리재료S { get; set; }
    }
}
