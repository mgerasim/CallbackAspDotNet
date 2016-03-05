using CallbackAspDotNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateSchema();
            DeleteBenzinAll();
            ImportData();
        }
        static void UpdateSchema()
        {
            CallbackAspDotNetMvc.Common.NHibernateHelper.UpdateSchema();
        }
        static void DeleteBenzinAll()
        {
            foreach (var item in Benzin.GetAll())
            {
                item.Delete();
            }
        }
        static void ImportData()
        {
            Benzin model = null;
            
            model = new Benzin();
            model.probeg = 257811;
            model.summa = 523;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 7, 31);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 257939;
            model.summa = 523;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 2);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 258108;
            model.summa = 523;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 5);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 258228;
            model.summa = 523;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 10);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 258391;
            model.summa = 523;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 17);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 258530;
            model.summa = 529;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 25);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 258651;
            model.summa = 529;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 27);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 258797;
            model.summa = 534;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 8, 30);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 258918;
            model.summa = 529;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 9, 5);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 259056;
            model.summa = 532;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 9, 16);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 259208;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 9, 20);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 259338;
            model.summa = 710;
            model.litrs = 20;
            model.payed_at = new DateTime(2015, 9, 23);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 259499;
            model.summa = 179;
            model.litrs = 5;
            model.payed_at = new DateTime(2015, 9, 29);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 259536;
            model.summa = 502;
            model.litrs = 14;
            model.payed_at = new DateTime(2015, 10, 1);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 259636;
            model.summa = 535;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 10, 4);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 259756;
            model.summa = 535;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 10, 10);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 256853;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 10, 13);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 259987;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 10, 19);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 260080;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 10, 26);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 260192;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 10, 31);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 260321;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 11, 4);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 260424;
            model.summa = 535;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 11, 7);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 260526;
            model.summa = 544;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 11, 12);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 260637;
            model.summa = 544;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 11, 16);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 260702;
            model.summa = 544;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 11, 20);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 260814;
            model.summa = 1302;
            model.litrs = 30;
            model.payed_at = new DateTime(2015, 11, 23);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261030;
            model.summa = 558;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 4);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261108;
            model.summa = 558;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 11);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 261208;
            model.summa = 544;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 16);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261323;
            model.summa = 544;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 20);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261408;
            model.summa = 558;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 23);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261475;
            model.summa = 558;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 27);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261558;
            model.summa = 558;
            model.litrs = 15;
            model.payed_at = new DateTime(2015, 12, 30);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 261644;
            model.summa = 559;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 01, 3);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261738;
            model.summa = 559;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 01, 6);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 261848;
            model.summa = 561;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 01, 11);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 261941;
            model.summa = 559;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 01, 18);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 262044;
            model.summa = 561;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 01, 25);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 262147;
            model.summa = 549;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 01, 30);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 262251;
            model.summa = 549;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 2, 3);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 262344;
            model.summa = 532;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 2, 13);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 262454;
            model.summa = 559+559;
            model.litrs = 15 +15;
            model.payed_at = new DateTime(2016, 2, 21);
            model.SaveOrUpdate();
            model = null;

            model = new Benzin();
            model.probeg = 262630;
            model.summa = 538;
            model.litrs = 15;
            model.payed_at = new DateTime(2016, 2, 26);
            model.SaveOrUpdate();
            model = null;


            model = new Benzin();
            model.probeg = 262732;
            model.summa = 180;
            model.litrs = 5;
            model.payed_at = new DateTime(2016, 2, 29);
            model.SaveOrUpdate();
            model = null;
        }
    }
}
