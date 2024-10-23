using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class remove_array
    {
        public static void Remove_array(int[] array, int x, int y )
        {

            x = Array.IndexOf(array, x);
            y = Array.IndexOf(array,y);            
        }
    }
}
