using System;
using System.Collections.Generic;
using System.Text;

namespace EST_Arbolito
{
    internal class Nodo
    {
        public string Value;
        public Nodo left;
        public Nodo right;

        public Nodo(string value)
        {
            Value = value;
            left = null;
            right = null;
        }

        public bool Hoja()
        {
            return left == null && right == null;
        }

        public bool Lleno()
        {  
            return left != null && right != null; 
        }
    }
}
