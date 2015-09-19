using System;

using Xamarin.Forms;

namespace LoadingFormsViewFromNative
{
    public class App : Application
    {
        public static MasterDetailPage MainNavigation;

        public App ()
        {
            // The root page of your application
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        },
                        new NativeButton() {
                            Text = "Load Forms from Native"
                        }
                    }
                }
            };
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

