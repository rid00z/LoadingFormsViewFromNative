# Converting a Xamarin.Forms view into a Native view for each platform (iOS/Android)

Sample repository that shows converting Xamarin.Forms view into a Native view. 

This sample application is a demo of taking a Xamarin.Forms view and turning it into a Native app.

The use cases for this application could be as follows:

* You have a custom renderer and want to show a subview from that custom renderer
* You need to supply a Native view to a 3rd party component

This primary code from this is based on two helper functions. 

### For the iOS project

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

### For the android project

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

