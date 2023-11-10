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
using BASE;
using EntryCustomRenderer.Driod;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using EntryCustomRenderer;


[assembly: ExportRenderer(typeof(MiEntry), typeof(MiEntryRenderer))]
namespace EntryCustomRenderer.Driod
{
    class MiEntryRenderer:EntryRenderer
    {
        public MiEntryRenderer(Context context):base(context)
        { 
            
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}