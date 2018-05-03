using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternAdapter
{
    class CabinPlane
    {
        public string SteeringOnYourself()
        {
            return "UP";
        }
        public string SteeringFromYourself()
        {
            return "DOWN";
        }
        public string SteeringLeft()
        {
            return "LEFT";
        }
        public string SteeringRight()
        {
            return "RIGHT";
        }

        public string PlaneStart()
        {
            return "START";
        }
    }

    interface IJostic
    {
        string PressButtonUp();
        string PressButtonDown();
        string PressButtonLeft();
        string PressButtonRight();
        string PressButtonStart();
    }

    class Jostic : IJostic
    {
        public string PressButtonDown()
        {
            return "DOWN";
        }

        public string PressButtonLeft()
        {
            return "LEFT";
        }

        public string PressButtonRight()
        {
            return "RIGHT";
        }

        public string PressButtonStart()
        {
            return "START";
        }

        public string PressButtonUp()
        {
            return "UP";
        }
    }


    class Adapter : IJostic
    {
        private readonly CabinPlane _adapterPlane;
        public Adapter(CabinPlane adapterplane)
        {
            _adapterPlane = adapterplane;
            
        }

        public string PressButtonDown()
        {
            return _adapterPlane.SteeringFromYourself();
        }

        public string PressButtonLeft()
        {
            return _adapterPlane.SteeringLeft();
        }

        public string PressButtonRight()
        {
            return _adapterPlane.SteeringRight();
        }

        public string PressButtonStart()
        {
            return _adapterPlane.PlaneStart();
        }

        public string PressButtonUp()
        {
            return _adapterPlane.SteeringOnYourself();
        }
    }

    class Nintendo
    {
        public static void DownloadCheckSystem(IJostic jostic)
        {
            Console.WriteLine($"System download and Check:\n" +
                $" Check UP: {jostic.PressButtonUp()}\n" +
                $" Check DOWN: {jostic.PressButtonDown()}\n" +
                $" Check LEFT: {jostic.PressButtonLeft()}\n" +
                $" Check RIGHT: {jostic.PressButtonRight()}\n" +
                $" Check START: {jostic.PressButtonStart()}\n");
        }
    }






    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Nintendo with jostic:\n");

           var JosticForNintendo = new Jostic();
            
            //користуємось новою системою без проблем
            Nintendo.DownloadCheckSystem(JosticForNintendo);

            Console.WriteLine($"Nintendo with Cabin Plane:\n");
            //для адаптації до старої системи використовуємо адаптер
            var plane = new CabinPlane();
            //використовуємо адаптер для керування приставкою з літака
            var adapter = new Adapter(plane);
            Nintendo.DownloadCheckSystem(adapter);

        }
    }
}
