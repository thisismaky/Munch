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

namespace Munch
{
    public class OnSignEventArgs_InventoryManagement : EventArgs
    {
        private string mName;
        private string mUnit;
        private string mThreshold;
        private string mQuant;
        
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Unit
        {
            get { return mUnit; }
            set { mUnit = value; }
        }

        public string Quant
        {
            get { return mQuant; }
            set { mQuant = value; }
        }

        public string Threshold
        {
            get { return mThreshold; }
            set { mThreshold = value; }
        }

        public OnSignEventArgs_InventoryManagement(string name, string unit, string quant, string thres) : base()
        {
            Name = name;
            Unit = unit;
            Quant = quant;
            Threshold = thres;
        }

    }

    class dialog_APManageInventory : DialogFragment
    {
        private EditText name;
        private EditText unit;
        private EditText quant;
        private EditText thres;
        private Button dAddItem;

        public event EventHandler<OnSignEventArgs_InventoryManagement> addItemComplete;
        public event EventHandler<OnSignEventArgs_InventoryManagement> deleteItemComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_APMIAdd, container, false);

            name = view.FindViewById<EditText>(Resource.Id.txtName1);
            unit = view.FindViewById<EditText>(Resource.Id.txtUnit1);
            quant = view.FindViewById<EditText>(Resource.Id.txtQuantity1);
            thres = view.FindViewById<EditText>(Resource.Id.txtMinThreshold);
            dAddItem = view.FindViewById<Button>(Resource.Id.btnAPMIAddItem1);

            dAddItem.Click += dAddItem_Click;

            return view;
        }

        void dAddItem_Click(object sender, EventArgs args)
        {
            addItemComplete.Invoke(this, new OnSignEventArgs_InventoryManagement(name.Text, unit.Text, quant.Text, thres.Text));
            var webClient = new WebClient();
            webClient.DownloadString("http://54.191.98.63/manageinventory.php?name=" + name.Text+"&&unit="+unit.Text+"&&quantity="+quant.Text+"&&threshold=" + thres.Text);
            this.Dismiss();

        }

       
    }
}