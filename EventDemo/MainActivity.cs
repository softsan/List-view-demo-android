using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EventDemo
{
    using System.Collections.Generic;

	[Activity(Label = "List",   Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
		List<TableItem> tableItems;
		ListView listView;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);

                //// Set our view from the "main" layout resource
                // SetContentView(Resource.Layout.Main);

                //items = new string[] { "Kick", "Bang Bang", "Enrique", "Legumes", "US Top 10", "UK Top 10" };
                //ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);

				SetContentView(Resource.Layout.Main); // loads the HomeScreen.axml as this activity's view
				var listView = FindViewById<ListView>(Resource.Id.List); // get reference to the ListView in the layout
                // populate the listview with data
				tableItems  = new List<TableItem>();

				for(int i=1;i<=8;i++)
				{
					tableItems.Add(new TableItem()
						{
//							Heading = "वाइब्रेंट नवरात्री  " + i,
//							SubHeading = " इस नवरात्री के पावन अवसर पे माँ के अनूप और अलौलिक गरबा का लुफ्त उठाये " + i,

							Heading = "Vibrant Navratri " + i,
							SubHeading = " Longest dance festival of the universe. Having enchanten colors of clothes, electrifying music makes people very vibrant and enthustics " + i,
							ImageResourceId = i
						});
				}


                listView.Adapter = new HomeScreenAdapter(this, tableItems);
				listView.ItemClick += HandleItemClick;  // to be defined
            }
            catch (Exception ex)
            {
				Console.WriteLine (ex.Message);
                throw ex;
            }
        }

        void HandleItemClick (object sender, AdapterView.ItemClickEventArgs e)
        {
			var listView = sender as ListView;
			var t = tableItems[e.Position];
			Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();

			// Create a branch detail activity
			var branchDetail = new Intent(this, typeof(DetailView));
			DetailView.TableList = tableItems;

			// Pass in the town
			branchDetail.PutExtra("Heading", tableItems[e.Position].Heading);

			// Start the activity
			StartActivity(branchDetail);
        }

		 

        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            //var intent = new Intent(this, activityType);
            //intent.AddFlags(ActivityFlags.NewTask);

            //var spec = TabHost.NewTabSpec(tag);
            //var drawableIcon = Resources.GetDrawable(drawableId);
            //spec.SetIndicator(label, drawableIcon);
            //spec.SetContent(intent);

            //TabHost.AddTab(spec);
        }
    }

    [Activity]
    public class SessionsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textview = new TextView(this);
            textview.Text = "This is the session tab";
            SetContentView(textview);
        }
    }

    [Activity]
    public class MyScheduleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textview = new TextView(this);
            textview.Text = "This is the My Schedule tab";
            SetContentView(textview);
        }
    }

    [Activity]
    public class SpeakersActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textview = new TextView(this);
            textview.Text = "This is the speaker tab";
            SetContentView(textview);
        }
    }

    [Activity]
    public class WhatsOnActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textview = new TextView(this);
            textview.Text = "This is the WhatsOn  tab";
            SetContentView(textview);
        }
    }
}

