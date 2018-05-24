using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace CustomRowView {
    [Activity(Label = "Autod", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeScreen : Activity{//, View.IOnClickListener {

        List<TableItem> tableItems = new List<TableItem>();
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.HomeScreen);
            listView = FindViewById<ListView>(Resource.Id.List);

            tableItems.Add(new TableItem() { Heading = "AUDI", SubHeading = "650 kw", ImageResourceId = Resource.Drawable.logo});
            tableItems.Add(new TableItem() { Heading = "quattro", SubHeading = "170 kw", ImageResourceId = Resource.Drawable.quattro });
            tableItems.Add(new TableItem() { Heading = "RS2", SubHeading = "50 kw", ImageResourceId = Resource.Drawable.RS2 });
            tableItems.Add(new TableItem() { Heading = "RS6", SubHeading = "330 kw", ImageResourceId = Resource.Drawable.RS6 });
            tableItems.Add(new TableItem() { Heading = "R8", SubHeading = "180 kw", ImageResourceId = Resource.Drawable.R8 });
         

            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading+"("+t.SubHeading+")", Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Klikkisid " + t.Heading);
        }
    }
}