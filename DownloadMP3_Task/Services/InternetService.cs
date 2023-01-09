using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMP3_Task.Services
{
    public class InternetService
    {

        public static double CheckInternetSpeed()
 {
        // Create Object Of WebClient
        System.Net.WebClient wc = new System.Net.WebClient();

        //DateTime Variable To Store Download Start Time.
        DateTime dt1 = DateTime.UtcNow;

        //Number Of Bytes Downloaded Are Stored In ‘data’
        byte[] data = wc.DownloadData("http://google.com");

        //DateTime Variable To Store Download End Time.
        DateTime dt2 = DateTime.UtcNow;

        //To Calculate Speed in Kb Divide Value Of data by 1024 And Then by End Time Subtract Start Time To Know Download Per Second.
        return Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);            
    }

    }
}
