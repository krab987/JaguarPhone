using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.String;

namespace JaguarLibraryControls
{
    // textBox obj with watermark
    public class TextBoxWater : TextBox
    {
        private string waterMark;
        private bool waterMarkEnabled = true;
        private Brush tempForeground;

        protected override void OnInitialized(EventArgs e)
        {
            if (WaterMarkEnabled)
                ShowWaterMark();
            base.OnInitialized(e);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "IsFocused")
            {
                if (IsFocused == false && WaterMarkEnabled)
                    ShowWaterMark();
                else
                    RemoveWaterMark();
            }

            base.OnPropertyChanged(e);
        }

        private void RemoveWaterMark()
        {
            if (Text == WaterMark)
            {
                Text = "";
                Foreground = tempForeground;
            }
        }
        private void ShowWaterMark()
        {
            if (IsNullOrWhiteSpace(Text))
            {
                Text = WaterMark;
                tempForeground = this.Foreground.Clone();
                Foreground = new SolidColorBrush(Colors.SlateGray);
                //Foreground = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0));
            }
        }

        public string WaterMark
        {
            get => waterMark;
            set
            {
                waterMark = value ?? throw new ArgumentNullException(nameof(value));
                if (WaterMarkEnabled)
                    ShowWaterMark();
            } 
        }
        public bool WaterMarkEnabled
        {
            get => waterMarkEnabled;
            set => waterMarkEnabled = value;
        }
    }
}
