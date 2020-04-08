using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pocius_Mantas_IFF_9_5
{
    public sealed class MyNode
    {
        public Module Data { get; set; }

        public MyNode Link { get; set; }

        public MyNode() { }
        public MyNode(Module data)
        {
            this.Data = data;
            Link = null;
        }
    }

}