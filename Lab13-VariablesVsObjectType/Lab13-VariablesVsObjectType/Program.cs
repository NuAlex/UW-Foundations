using System;

namespace Lab13_VariablesVsObjectType
{
    internal class Program
    {
        static void Main()
        {

            //double fx = 0;
            ////float ix = 0;
            //int objy = 0;

            //double dblx = fx;   // Boxing
            //float fx = ix;      // Boxing
            //object myobjx = fx; // Boxing
            //int ix = objy;      // Boxing

            //double objdblx = 1;
            //float fx = (float) objdblx;
            //Console.WriteLine( fx );

            //float objflx = 5.5f;
            //double dx = objflx;
            //Console.WriteLine( dx );

            //string strx = "1024";
            //double dblx = double.Parse(strx);
            //Console.WriteLine(dblx);

            int ix = 10;
            float fx = ix;
            Console.WriteLine( fx );

            double dblx = 100;
            string strx = dblx.ToString();
            Console.WriteLine(strx);

            double dx = 45.3;
            string objstr = dx.ToString();

            object anything = "anything"; 

            Console.WriteLine(anything);    

            Console.ReadLine(); 
        }
    }
}
