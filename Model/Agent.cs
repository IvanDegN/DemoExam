using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
   partial class Agent
    {
        public override string ToString()
        {
            return Title;
        }

        public string NullImage
        {
            get
            {
                if (string.IsNullOrEmpty(Logo) || string.IsNullOrWhiteSpace(Logo))
                {
                    return @"\Images\picture.png";
                }
                else return Logo;
            }
        }
    }
}
