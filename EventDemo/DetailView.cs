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
using Android.Media;
using Android.Graphics;
using Android.Provider;

namespace EventDemo
{
	[Activity(Label = "Details", Icon = "@drawable/icon")]
	public class  DetailView : Activity, MediaPlayer.IOnPreparedListener, ISurfaceHolderCallback
	{
		MediaPlayer player;
		VideoView videoView;
		public static  List<TableItem> TableList { get; set; }

		protected override void OnCreate(Bundle bundle)
		{
			try 
			{
				base.OnCreate (bundle);
				
				// Set our view from the "main" layout resource
				SetContentView (Resource.Layout.DetailView);
				
				string text = Intent.GetStringExtra ("Heading");
				var table = TableList.FirstOrDefault (c => c.Heading == text);
				
				FindViewById<TextView> (Resource.Id.Heading).Text = table.Heading;
				FindViewById<TextView> (Resource.Id.SubHeading).Text = table.SubHeading;
				 videoView = FindViewById<VideoView> (Resource.Id.SampleVideoView);




				 play ("TransData/videoviewdemo.mp4");
			} 
			catch (Exception ex) 
			{
				Console.WriteLine (ex.Message);
				throw ex;
			}

//			FindViewById<ImageView>(Resource.Id.branchitem_icon).SetImageURI(Android.Net.Uri.Parse(Branch.ImagePath));
//
//			var img = context.Resources.GetIdentifier ("index" + table.ImageResourceId.ToString (), "drawable", context.PackageName);
//
//			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(img);
		}

		void play(string fullPath)
		{
			ISurfaceHolder holder = videoView.Holder;
			holder.SetType (SurfaceType.PushBuffers);
			holder.AddCallback( this );
			player = new  MediaPlayer ();
			Android.Content.Res.AssetFileDescriptor afd = this.Assets.OpenFd(fullPath);
			if  (afd != null )
			{
				player.SetDataSource (afd.FileDescriptor, afd.StartOffset, afd.Length);
				player.Prepare ();
				player.Start ();
			}
		}

		public void SurfaceCreated(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceCreated");
			player.SetDisplay(holder);
		}
		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceDestroyed");
		}
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine("SurfaceChanged");
		}
		public void OnPrepared(MediaPlayer player)
		{

		}
	}
}

