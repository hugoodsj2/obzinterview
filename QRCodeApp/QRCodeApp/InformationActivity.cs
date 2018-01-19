using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace QRCodeApp
{
    [Activity(Label = "InformationActivity")]
    public class InformationActivity : Activity
    {
        WebView webVInformation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Information);
            String idQRCode = Intent.GetStringExtra("idQRCode");

            LoadDataWebView(idQRCode);
        }

        private void LoadDataWebView(string idQRCode) {

            webVInformation = FindViewById<WebView>(Resource.Id.webViewInformation);

            string url = "http://qrcodeapp.azurewebsites.net/api/QRCode/GetInformation/" + idQRCode;
            string json = FetchInformation(url);

            webVInformation.LoadData(json, "text/html; charset=UTF-8", null);

        }

        private string FetchInformation(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // EmptyString return
            string information = String.Empty;

            // Send the request to the server and wait for the response:
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    information = content;
                }
            }

            return information;
        }
    }
}