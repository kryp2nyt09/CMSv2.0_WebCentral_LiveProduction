using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SOA_Generation_Service
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {            
            _timer = new Timer(1000);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            bool isPrinted = false;

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                if (isPrinted == false)
                {
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    if (DateTimeExtensions.GetWeekOfMonth(firstDayOfMonth) == 1 && firstDayOfMonth.DayOfWeek == DayOfWeek.Sunday)
                    {
                        if (DateTimeExtensions.GetWeekOfMonth(DateTime.Now.AddDays(-1)) == 2)
                        {
                            StatementOfAccountGeneration generation = new StatementOfAccountGeneration(15);
                        }
                        else if (DateTimeExtensions.GetWeekOfMonth(DateTime.Now.AddDays(-1)) == DateTimeExtensions.GetLastWeekOfMonth(DateTime.Now))
                        {
                            StatementOfAccountGeneration generation = new StatementOfAccountGeneration(30);
                        }
                        else
                        {
                            StatementOfAccountGeneration generation = new StatementOfAccountGeneration(7);                            
                        }
                    }
                    else
                    {
                        if (DateTimeExtensions.GetWeekOfMonth(DateTime.Now.AddDays(-1)) == 3)
                        {
                            StatementOfAccountGeneration generation = new StatementOfAccountGeneration(15);
                        }
                        else if (DateTimeExtensions.GetWeekOfMonth(DateTime.Now.AddDays(-1)) == DateTimeExtensions.GetLastWeekOfMonth(DateTime.Now))
                        {
                            StatementOfAccountGeneration generation = new StatementOfAccountGeneration(30);
                        }
                        else
                        {
                            StatementOfAccountGeneration generation = new StatementOfAccountGeneration(7);
                        }
                    }
                }
            }

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                if (isPrinted == false)
                {
                    if (DateTimeExtensions.GetWeekOfMonth(DateTime.Now) == 3)
                    {
                        StatementOfAccountGeneration generation = new StatementOfAccountGeneration(15);
                    }
                    else if (DateTimeExtensions.GetWeekOfMonth(DateTime.Now) == 4)
                    {
                        StatementOfAccountGeneration generation = new StatementOfAccountGeneration(30);
                    }
                    else
                    {
                        StatementOfAccountGeneration generation = new StatementOfAccountGeneration(7);
                    }
                }

                isPrinted = true;
            }
            else
            {
                isPrinted = false;
            }

        }

        protected override void OnStop()
        {
        }


    }

    public static class DateTimeExtensions
    {
        static GregorianCalendar _gc = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {

            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        public static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static int GetLastWeekOfMonth(this DateTime time)
        {
            int weekOfMonth = GetWeekOfMonth(time);

            DateTime lastday = new DateTime(time.Year, time.Month, DateTime.DaysInMonth(time.Year, time.Month));

            int lastWeekOfMonth = GetWeekOfMonth(lastday);

            bool isFridayOrAbove = lastday.DayOfWeek == DayOfWeek.Friday || lastday.DayOfWeek == DayOfWeek.Saturday;

            if (weekOfMonth == lastWeekOfMonth && isFridayOrAbove)
            {
                return lastWeekOfMonth;
            }
            else
            {
                return lastWeekOfMonth - 1;
            }

        }

    }
}
