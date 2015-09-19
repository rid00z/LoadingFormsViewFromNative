using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

namespace LoadingFormsViewFromNative.iOS
{
    public class FormsViewToNativeiOS
    {
        public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
        {
            var renderer = RendererFactory.GetRenderer (view);

            renderer.NativeView.Frame = size;

            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

            renderer.Element.Layout (size.ToRectangle());

            var nativeView = renderer.NativeView;

            nativeView.SetNeedsLayout ();

            return nativeView;
        }
    }
}

