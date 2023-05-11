using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JaguarLibraryControls
{
    // textBox obj with watermark
    public class TextBoxWater : TextBox
    {
        private string waterMark = "";
        private bool waterMarkEnabled = true;
        private Brush tempForeground;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (Equals(e.Property.Name, "IsFocused"))
            {
                if (IsFocused == false && WaterMarkEnabled)
                    ShowWaterMark();
                else
                    RemoveWaterMark();
            }

            base.OnPropertyChanged(e);
        }

        public TextBoxWater()
        {
            tempForeground = this.Foreground.Clone();

            if (IsFocused == false && WaterMarkEnabled)
                ShowWaterMark();
            else
                RemoveWaterMark();
        }


        private void RemoveWaterMark()
        {
            Text = "";
        }
        private void ShowWaterMark()
        {
            if (String.IsNullOrWhiteSpace(Text))
            {
                
                Text = WaterMark;
                Foreground = new SolidColorBrush(Color.FromArgb(40,0,0,0));
            }
        }


        public string WaterMark
        {
            get => waterMark;
            set
            {
                waterMark = value ?? throw new ArgumentNullException(nameof(value));
                if (IsFocused == false && WaterMarkEnabled)
                    ShowWaterMark();
                else
                    RemoveWaterMark();
            }

        }
        public bool WaterMarkEnabled
        {
            get => waterMarkEnabled;
            set
            {
                waterMarkEnabled = value;
                if (IsFocused == false && WaterMarkEnabled)
                    ShowWaterMark();
                else
                    RemoveWaterMark();
            }
        }

    }
}
