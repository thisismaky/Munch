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
using System.Net;
using com.refractored.fab;

namespace Munch
{
    [Activity(Label = "CV2_YourOrder", Theme = "@android:style/Theme.Holo.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.SensorPortrait)]
    public class CV2_YourOrder : Activity
    {
        public ListView mListView;
        public static List<CustomerOrderItem> mItems = new List<CustomerOrderItem>();
        

        public static int count = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set view
            SetContentView(Resource.Layout.CV_Your_Order);

            mListView = FindViewById<ListView>(Resource.Id.mngYour_Order_ListView);
            var orderUP = FindViewById<FloatingActionButton>(Resource.Id.ORderUP);

            CV_your_Order_ListViewAdapter adapter = new CV_your_Order_ListViewAdapter(this, (mItems));
            mListView.Adapter = adapter;
            orderUP.AttachToListView(mListView);
             mListView.ItemLongClick += MListView_ItemClick;
            orderUP.Click += OrderUP_Click;

        }

        private void MListView_ItemClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            int pos = e.Position;
            CustomerPortal.CustomerOrderList.RemoveAt(pos);
            mItems.RemoveAt(pos);
            this.Recreate();
            //  mListView.RemoveViewAt(e.Position);
            //  mListView.DeferNotifyDataSetChanged();
        }




        //order button 
        private void OrderUP_Click(object sender, EventArgs e)
        {

            //loop into listview
            for (int i = 0; i < mListView.Count; i++)
            {
                //gets each row view and stores it into V 
                var v = mListView.Adapter.GetView(i, null, null);
                //get the textview of the dish name
                var dishname = (TextView)v.FindViewById(Resource.Id.Manage_Your_Order_Txt_Name);
                var quantity = (TextView)v.FindViewById(Resource.Id.Manage_Your_Order_Txt_Quantity);
                var notes = (TextView)v.FindViewById(Resource.Id.Manage_Your_Order_Txt_Note);
                var price = (TextView)v.FindViewById(Resource.Id.Manage_Your_Order_Txt_Units);

                var loginname = LoginScreen.loginUsername;


                //NEED URL FOR ADDING TO MYSQL
                var webClient = new WebClient();
                webClient.DownloadString("http://54.191.98.63/orders.php?idAccounts=" + loginname + "&&name=" + dishname.Text + "&&Quantity=" + quantity.Text + "&&Note=" + notes.Text + "&&count=" + count + "&&price=" + price.Text);


            }
            for (int i = 0; i < mListView.Count; i++)
            {
                mItems.RemoveAt(count);
                
            }this.Recreate();

                Android.Widget.Toast.MakeText(this, "The kitchen has been notified, hang tight. Grab some refreshments while you wait.", Android.Widget.ToastLength.Long).Show();
        }
    }
}