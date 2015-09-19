using System;
using Xamarin.Forms.Platform.Android;
using LoadingFormsViewFromNative;
using LoadingFormsViewFromNative.Droid;
using Android.App;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportRenderer(typeof(NativeButton), typeof(NativeButtonRenderer))]

namespace LoadingFormsViewFromNative.Droid
{
    public class NativeButtonRenderer : ButtonRenderer
    {
        public NativeButtonRenderer ()
        {
        }

        protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged (e);

            if (e.NewElement != null) {
                this.Control.Click += Control_Click;
            }
        }

        void Control_Click (object sender, EventArgs e)
        {
            var formsView = new CommonFormsView ();

            var nativeConverted = FormsToNativeDroid.ConvertFormsToNative (formsView, new Rectangle (0, 0, 400, 400));
            
            var builder = new AlertDialog.Builder (Forms.Context);

            builder.SetView (nativeConverted);

            builder.SetTitle ("Forms View");

            var dialog = builder.Create ();
            dialog.Show ();
        }
    }
}

