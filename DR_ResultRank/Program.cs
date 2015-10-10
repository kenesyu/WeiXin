using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using DBHelper;
using System.Data;
using System.IO;
using System.Net;
using System.Timers;
using System.Threading;
namespace DR_ResultRank
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 1000 * 60 *15; //每15分钟执行
            aTimer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
            // Keep the timer alive until the end of Main.
            GC.KeepAlive(aTimer);

        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dtResult = dbHelper.ExecuteDataTable("", "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY Result desc) AS rowNum, id FROM dr_bm) AS t ");
            DataTable dtCountNum = dbHelper.ExecuteDataTable("", "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY countnum desc) AS rowNum, id FROM dr_bm) AS t ");
            foreach (DataRow dr in dtResult.Rows)
            {
                dbHelper.ExecuteNonQuery("update dr_bm set OrdResult = " + dr["rowNum"].ToString() + " where id = " + dr["id"].ToString());
            }
            foreach (DataRow dr in dtCountNum.Rows)
            {
                dbHelper.ExecuteNonQuery("update dr_bm set OrdRQ = " + dr["rowNum"].ToString() + " where id = " + dr["id"].ToString());
            }
            dbHelper.Dispose();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
    }
