﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainActivity.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The main activity of android application
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Droid
{
    using Akvelon.Calendar.Models.Enums;
    using Akvelon.Calendar.Models.Interfaces;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;

    using TinyIoC;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    ///     The main activity.
    /// </summary>
    [Activity(
        Label = "Akvelon.Calendar",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        /// <summary>
        /// The on create.
        /// </summary>
        /// <param name="bundle">
        /// The bundle.
        /// </param>
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabbar;
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;


            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            AppInjection.Register("Calendar", DateRepresentationType.Year);

            IApplicationModel implementation = TinyIoCContainer.Current.Resolve<IApplicationModel>();

            this.LoadApplication(new App(implementation));
        }
    }
}