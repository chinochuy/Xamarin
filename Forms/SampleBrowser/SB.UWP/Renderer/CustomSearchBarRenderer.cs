#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core.UWP.Renderer;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin.Forms.SearchBar), typeof(CustomSearchBarRenderer))]
namespace SampleBrowser.Core.UWP.Renderer
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        Xamarin.Forms.SearchBar searchBar;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
        {
            base.OnElementChanged(e);

            searchBar = e.NewElement;

            if (Control != null)
                searchBar.SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            Control.Style = (Style)Application.Current.Resources["CustomAutoSuggestBoxStyle"];
            searchBar.SizeChanged -= OnSizeChanged;
        }
    }
}
