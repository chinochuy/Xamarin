#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SampleBrowser.Core;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    public class PopupGettingStartedBehavior : Behavior<SampleView>
    {
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        private Picker animatePicker;
        private Picker translationPicker;
        private Button relativePosition;
        private Grid MainLayout;
        private Picker buttonlayoutPicker;
        private Button showPopupCenter;
      
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            popupLayout = bindable.Content.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popupLayout");
            SetDefaultValues();

            animatePicker = bindable.FindByName<Picker>("AnimationTypePicker");
            buttonlayoutPicker = bindable.FindByName<Picker>("ButtonlayoutTypePicker");
            translationPicker = bindable.FindByName<Picker>("RelativePositionPicker");
            relativePosition = bindable.FindByName<Button>("RelativeButton");
            showPopupCenter = bindable.FindByName<Button>("centerPositionButton");
            MainLayout = bindable.FindByName<Grid>("mainLayout");
           
            animatePicker.SelectedIndexChanged += AnimationPicker_SelectedIndexChanged;
            buttonlayoutPicker.SelectedIndexChanged+= ButtonlayoutPicker_SelectedIndexChanged;
            relativePosition.Clicked+= RelativePosition_Clicked;
            showPopupCenter.Clicked+= ShowPopupCenter_Clicked;
            buttonlayoutPicker.SelectedIndex = 1;
            animatePicker.SelectedIndex = 3;
            translationPicker.SelectedIndex = 8;
            LoadPopup();
        }

        private async void LoadPopup()
        {
            await Task.Delay(200);
            if (popupLayout.Content.Width <= 0)
                return;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                popupLayout.PopupView.PopupStyle.BorderThickness = 1;
                popupLayout.PopupView.WidthRequest = popupLayout.Content.Width - 400;
            }
            else
                popupLayout.PopupView.WidthRequest = popupLayout.Content.Width - 40;
            popupLayout.Show();
        }
        private void ShowPopupCenter_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                popupLayout.PopupView.PopupStyle.BorderThickness = 1;
                popupLayout.PopupView.WidthRequest = popupLayout.Content.Width - 400;
            }
            else
                popupLayout.PopupView.WidthRequest = popupLayout.Content.Width - 40;
            popupLayout.Show();
        }

        private void SetDefaultValues()
        {
            popupLayout.PopupView.HeightRequest = 210;     
            if(Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop )
            {
                popupLayout.PopupView.PopupStyle.BorderThickness = 1;
                popupLayout.PopupView.WidthRequest = popupLayout.Content.Width - 400;
            }
            else
            popupLayout.PopupView.WidthRequest = popupLayout.Content.Width - 40;
            popupLayout.PopupView.ShowCloseButton = false;
            popupLayout.PopupView.HeaderTitle = "Popup";
            popupLayout.PopupView.AcceptButtonText = "OK";
            popupLayout.PopupView.DeclineButtonText = "Cancel";
            popupLayout.PopupView.ShowFooter = true;
            popupLayout.PopupView.ShowHeader = true;
            if (Device.RuntimePlatform == Device.Android)
            {
                popupLayout.PopupView.PopupStyle.HeaderTextAlignment = TextAlignment.Start;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                popupLayout.PopupView.PopupStyle.HeaderTextAlignment = TextAlignment.Center;
            }
            if(Device.RuntimePlatform == Device.UWP)
            {
                popupLayout.PopupView.PopupStyle.BorderThickness = 1;
                popupLayout.PopupView.PopupStyle.HeaderTextAlignment = TextAlignment.Start;
            }
            popupLayout.PopupView.AppearanceMode = AppearanceMode.OneButton;
            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                StackLayout stack = new StackLayout();
                stack.Orientation = StackOrientation.Horizontal;
                stack.BackgroundColor = Color.White;
                Label label = new Label();
                Label firstLabel = new Label();
                firstLabel.WidthRequest = 10;
                firstLabel.BackgroundColor = Color.Transparent;
                label.Text = "PopupLayout interface that allows the user to display an alert message with the customizable layouts and to load any desired view inside the pop-up.";
                label.FontSize = 14;
                label.LineBreakMode = LineBreakMode.WordWrap;
                label.HorizontalOptions = LayoutOptions.FillAndExpand;
                label.VerticalOptions = LayoutOptions.FillAndExpand;
                label.HeightRequest = 200;
                label.WidthRequest = popupLayout.PopupView.WidthRequest - (firstLabel.Width + 30);
                label.TextColor = Color.Black;
                label.BackgroundColor = Color.White;
                stack.Children.Add(firstLabel);
                stack.Children.Add(label);
                return stack;
            });
            popupLayout.PopupView.BackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.HeaderBackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.HeaderTextColor = Color.Black;
            popupLayout.PopupView.PopupStyle.HeaderFontAttribute = FontAttributes.Bold;
            popupLayout.PopupView.PopupStyle.HeaderTextAlignment = TextAlignment.Start;
        }

        private void RelativePosition_Clicked(object sender, EventArgs e)
        {
            popupLayout.PopupView.HeightRequest = 210;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                popupLayout.PopupView.WidthRequest = 300;
            }
            else
                popupLayout.PopupView.WidthRequest = 200;
            if (translationPicker != null)
                SetRelativePosition(translationPicker.SelectedIndex);
            else
            popupLayout.Show();
        }

        private void ButtonlayoutPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    popupLayout.PopupView.ShowHeader = true;
                    popupLayout.PopupView.ShowFooter = true;
                    popupLayout.PopupView.HeaderTitle = "One button layout";
                    popupLayout.PopupView.AppearanceMode = AppearanceMode.OneButton;               
                    break;
                case 1:
                    popupLayout.PopupView.ShowHeader = true;
                    popupLayout.PopupView.ShowFooter = true;
                    popupLayout.PopupView.HeaderTitle = "Two button layout";
                    popupLayout.PopupView.AppearanceMode = AppearanceMode.TwoButton;          
                    break;
            }
        }

        private void SetRelativePosition(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignToLeftOf);
                    break;
                case 1:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignTop);
                    break;
                case 2:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignBottom);
                    break;
                case 3:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignToRightOf);
                    break;
                case 4:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignTopLeft);
                    break;
                case 5:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignTopRight);
                    break;
                case 6:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignBottomLeft);
                    break;
                case 7:
                    popupLayout.ShowRelativeToView(relativePosition as View, RelativePosition.AlignBottomRight);
                    break;
                case 8:
                    popupLayout.Show();
                    break;
            }
        }

        private void AnimationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    popupLayout.PopupView.AnimationMode = AnimationMode.Fade;
                    break;
                case 1:
                    popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnLeft;
                    break;
                case 2:
                    popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnTop;
                    break;
                case 3:
                    popupLayout.PopupView.AnimationMode = AnimationMode.Zoom;
                    break;
                case 4:
                    popupLayout.PopupView.AnimationMode = AnimationMode.None;
                    break;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            animatePicker.SelectedIndexChanged -= AnimationPicker_SelectedIndexChanged;
            buttonlayoutPicker.SelectedIndexChanged -= ButtonlayoutPicker_SelectedIndexChanged;
            relativePosition.Clicked -= RelativePosition_Clicked;
            animatePicker = null;
            buttonlayoutPicker = null;
            translationPicker = null;
            popupLayout = null;
            relativePosition = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
