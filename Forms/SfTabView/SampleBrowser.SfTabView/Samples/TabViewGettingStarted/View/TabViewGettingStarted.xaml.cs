#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleBrowser.SfTabView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabViewGettingStarted : SampleView
    {
        private Syncfusion.XForms.TabView.SfTabView tabView;
        private ObservableCollection<ListView> ListViewCollection = new ObservableCollection<ListView>();
        private TabDataViewModel viewModel = new TabDataViewModel();

        public TabViewGettingStarted()
        {
            InitializeComponent();
            ConfigureListView();
            tabView = GetTabView();
            tabView.TabHeight = 64;
            this.Content = tabView;
        }

        private Syncfusion.XForms.TabView.SfTabView GetTabView()
        {
            var _tabView = new Syncfusion.XForms.TabView.SfTabView();
            _tabView.DisplayMode = TabDisplayMode.ImageWithText;
            _tabView.OverflowMode = OverflowMode.Scroll;
            _tabView.VisibleHeaderCount = 4;
            if (Device.RuntimePlatform == "iOS")
                _tabView.TabHeight = 60;
            var index = 0;
            var iconList = new[] {"A", "C", "F", "H", "K"};
            foreach (var category in viewModel.Categories)
            {
                var tabViewItem = new SfTabItem
                {
                    Title = category,
                    IconFont = iconList[index],
                    FontIconFontFamily = Device.RuntimePlatform == "iOS" ? "TabIcons" : "TabIcons.ttf",
                    Content = ListViewCollection[index],
                    SelectionColor = Color.White,
                    TitleFontColor = Color.LightBlue,
                    FontIconFontColor = Color.LightBlue,
                    TitleFontSize = Device.Idiom == TargetIdiom.Tablet ? 16 : 12
                };
                _tabView.Items.Add(tabViewItem);
                index++;
            }

            _tabView.SelectionIndicatorSettings = new SelectionIndicatorSettings()
            {
                Position = SelectionIndicatorPosition.Bottom,
                Color = Color.White
            };

            _tabView.TabHeaderPosition = TabHeaderPosition.Top;
            return _tabView;
        }


        private void ConfigureListView()
        {
            int i = 0;
            foreach (var item in viewModel.Categories)
            {
                var data = from cust in viewModel.Data
                    where cust.Category == item
                    select cust;
                DataTemplate dataTemplate;
                int rowHeight;
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    dataTemplate = new DataTemplate(typeof(ItemViewTabletMode));
                    rowHeight = 250;
                }
                else
                {
                    dataTemplate = new DataTemplate(typeof(ProductView));
                    rowHeight = 200;
                }
                var listView = new ListView
                {
                    RowHeight = rowHeight,
                    ItemsSource = data,
                    BackgroundColor = Color.White,
                    ItemTemplate = dataTemplate,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    SeparatorColor = Color.Transparent
                };
                //   listView.LayoutManager = new GridLayout() { SpanCount = 3 };
                ListViewCollection.Add(listView);
                i++;
            }
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.OverflowMode = OverflowMode.Scroll;
                    break;
                case 1:
                    tabView.OverflowMode = OverflowMode.DropDown;
                    break;
            }
        }

        private void HeaderTypePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.DisplayMode = TabDisplayMode.Text;
                    tabView.TabHeight = 48;
                    break;
                case 1:
                    tabView.DisplayMode = TabDisplayMode.Image;
                    tabView.TabHeight = 48;
                    break;
                case 2:
                    tabView.DisplayMode = TabDisplayMode.ImageWithText;
                    tabView.TabHeight = 64;
                    break;
                default:
                    tabView.DisplayMode = TabDisplayMode.NoHeader;
                    break;
            }
        }

        private void HeaderPositionPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.TabHeaderPosition = TabHeaderPosition.Top;
                    break;
                default:
                    tabView.TabHeaderPosition = TabHeaderPosition.Bottom;
                    break;
            }
        }

        private void SelectionIndicatorPositionPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if(picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Top;
                    break;
                default:
                    tabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Bottom;
                    break;
            }
        }
    }
}