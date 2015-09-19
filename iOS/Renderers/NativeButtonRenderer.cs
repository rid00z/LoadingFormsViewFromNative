using System;
using LoadingFormsViewFromNative;
using LoadingFormsViewFromNative.iOS;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;

[assembly: Xamarin.Forms.ExportRenderer(typeof(NativeButton), typeof(NativeButtonRenderer))]

namespace LoadingFormsViewFromNative.iOS
{
    public class NativeButtonRenderer : Xamarin.Forms.Platform.iOS.ButtonRenderer
    {
        public NativeButtonRenderer ()
        {
        }

        protected override void OnElementChanged (Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged (e);

            if (e.NewElement != null) {
                Control.TouchUpInside += delegate(object sender, EventArgs e2) {

                    var formsView = new CommonFormsView ();

                    var rect = new CGRect (0, 0, 400, 400);
                    var iOSView = FormsViewToNativeiOS.ConvertFormsToNative (formsView, rect);

                    var viewController = new UIViewController();
                    viewController.Add(iOSView);
                    viewController.View.Frame = rect;

                    var popoverController = new UIPopoverController(viewController);
                    popoverController.ContentViewController.View.BackgroundColor = viewController.View.BackgroundColor;
                    popoverController.PopoverContentSize = rect.Size;
                    var frame = UIApplication.SharedApplication.KeyWindow.RootViewController.View.Frame;
                    popoverController.PresentFromRect (Control.Frame, UIApplication.SharedApplication.KeyWindow.RootViewController.View, 0, true);

                };
            }
        }
    }
}

