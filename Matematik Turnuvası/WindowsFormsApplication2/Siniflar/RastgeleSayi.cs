using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WindowsFormsApplication2
{
    class RastgeleSayi
    {
        //mi
        public static int SayiUret(int min,int max) //min olabilir ama max olamaz
        {
            if (rastgele == null)
                rastgele = new Random();

            return rastgele.Next(min, max);
        }

        internal static object SayiUret(int v, object p)
        {
            throw new NotImplementedException();
        }

        private static Random rastgele;
    }
}
