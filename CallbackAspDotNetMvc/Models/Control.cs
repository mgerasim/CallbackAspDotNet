using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallbackAspDotNetMvc.Models
{
    public class Control
    {
        List<Benzin> theBenzin = null;
        GroupMonth theGroupMonth = null;
        public Control()
        {
            theBenzin = Benzin.GetAll();
            theGroupMonth = new GroupMonth(theBenzin);
        }
        public double RashodOn100km
        {
            get
            {
                int TotalLitrs = 0;
                int TotalKm = 0;
                if (theBenzin.Count > 0)
                {
                    TotalKm -= theBenzin.Last().probeg - theBenzin.First().probeg;
                }
                foreach (var benzin in theBenzin)
                {
                    TotalLitrs += benzin.litrs;                    
                }
                return (((double)TotalLitrs / (double)TotalKm) * 100);
            }

        }

        public GroupMonth _GroupMonth
        {
            get
            {
                return this.theGroupMonth;
            }
        }

        public class GroupMonth
        {
            public class DataByMonth
            {
                public int Month;
                public int Year;
                public int TotalLitrs;
                public int TotalKm;
                
                public double RashodOn100km
                {
                    get
                    {
                        if (this.TotalKm == 0)
                        {
                            return 0;
                        }
                        return (((double)TotalLitrs / (double)TotalKm) * 100);
                    }

                }
                public DataByMonth()
                {
                    Month = 0;
                    Year = 0;
                    TotalLitrs = 0;
                    TotalKm = 0;
                }


            }

            public List<DataByMonth> theDataList;

            private string _HighchartsCategory = "";
            public string HighchartsCategory
            {
                get
                {
                    return _HighchartsCategory;
                }
            }

            private string _HighchartsSeriesRashodOn100km = "";
            public string HighchartsSeriesRashodOn100km
            {
                get
                {
                    return _HighchartsSeriesRashodOn100km;
                }
            }

            public GroupMonth(List<Benzin> theBenzinList)
            {
                theDataList = new List<DataByMonth>();

                DateTime dateBgn = theBenzinList.Min(x => x.payed_at);
                DateTime dateEnd = theBenzinList.Max(x => x.payed_at);

                for(DateTime dateIdx = dateBgn; dateIdx < dateEnd.AddMonths(1); dateIdx = dateIdx.AddMonths(1))
                {
                    DataByMonth theData = new DataByMonth();

                    theData.Month = dateIdx.Month;
                    theData.Year = dateIdx.Year;
                    theData.TotalLitrs = theBenzinList.Where(x => x.payed_at.Year == dateIdx.Year && x.payed_at.Month == dateIdx.Month).Sum(x => x.litrs);
                    theData.TotalKm = theBenzinList.Where(x => x.payed_at.Year == dateIdx.Year && x.payed_at.Month == dateIdx.Month).OrderBy(x => x.payed_at).Last().probeg - 
                        theBenzinList.Where(x => x.payed_at.Year == dateIdx.Year && x.payed_at.Month == dateIdx.Month).OrderBy(x => x.payed_at).First().probeg ;
                    
                    theDataList.Add(theData);

                    this._HighchartsCategory += "'" + dateIdx.ToString("MM.yyyy") + "'";
                    this._HighchartsSeriesRashodOn100km += theData.RashodOn100km.ToString().Replace(",", ".");
                    if (dateIdx != dateEnd)
                    {
                        this._HighchartsCategory += ", ";
                        this._HighchartsSeriesRashodOn100km += ", ";
                    }
                }
            }


        }
    }
}