using System;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace LoadingFormsViewFromNative.Droid
{
    public class FormsToNativeDroid
    {
        public static ViewGroup ConvertFormsToNative(Xamarin.Forms.View view, Rectangle size)
        {
            var vRenderer = RendererFactory.GetRenderer (view);
            var viewGroup = vRenderer.ViewGroup;
            vRenderer.Tracker.UpdateLayout ();
            var layoutParams = new ViewGroup.LayoutParams ((int)size.Width, (int)size.Height);
            viewGroup.LayoutParameters = layoutParams;
            view.Layout (size);
            viewGroup.Layout (0, 0, (int)view.WidthRequest, (int)view.HeightRequest);
            return viewGroup; 
        }
    }
}

