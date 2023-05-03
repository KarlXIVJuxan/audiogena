using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using Path = System.IO.Path;

namespace audio
{
    public partial class MainWindow : Window
    {
        int selectedIndex;
        TimeSpan elapsed;
        static bool repeat = false;
        static bool mix = false;
        static bool isPlaying;
        static List<string> for_mix = new List<string>();
        static List<string> songi = new List<string>();
        private DispatcherTimer timer;
        private TimeSpan duration;
        private TimeSpan position;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsed = media.Position;

            audio_Slider.Value = media.Position.Ticks;
            tbElapsed.Text = string.Format("{0}:{1:D2}",
                (int)elapsed.TotalMinutes, elapsed.Seconds);
            tbRemaining.Text = string.Format("-{0}:{1:D2}",
                (int)(duration.TotalMinutes - elapsed.TotalMinutes),
                duration.Seconds - elapsed.Seconds);
        }

        private void Choose_file(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new() { IsFolderPicker = true };
            CommonFileDialogResult rez = dialog.ShowDialog();
            if (rez == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName, "*.mp3");
                foreach (string file in files)
                {
                    string name;
                    name = Path.GetFileNameWithoutExtension(file);
                    songi.Add(file);
                    songs.Items.Add(name);
                }
            }
            Play(0);
        }

        private void Songs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = songs.SelectedIndex;
            Play(selectedIndex);

        }

        private void Play(int index)
        {
            songs.SelectedIndex = index;
            isPlaying = true;
            media.Source = new Uri(songi[index]);
            media.Play();
        }

        private void Next()
        {
            if (selectedIndex == songi.Count - 1)
            {
                selectedIndex = 0;
                Play(selectedIndex);
            }
            else
            {
                selectedIndex++;
                Play(selectedIndex);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                isPlaying = false;
                position = media.Position;
                media.Stop();
                timer.IsEnabled = false;
            }
            else
            {
                isPlaying = true;
                media.Position = position;
                media.Play();
                timer.IsEnabled = true;               
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }

        private void Mix_Click(object sender, RoutedEventArgs e)
        {
            if (mix == false)
            {
                mix = true;
                Random rnd = new Random();
                for (int i = 0; i < for_mix.Count; i++)
                {
                    string tmp = for_mix[i];
                    for_mix.RemoveAt(i);
                    for_mix.Insert(rnd.Next(for_mix.Count), tmp);
                }


                foreach (string file in for_mix)
                {
                    string name;
                    name = Path.GetFileNameWithoutExtension(file);
                    songi.Add(file);
                    songs.Items.Add(name);
                }

            }
            else
            {
                mix = false;
                foreach (string file in songi)
                {
                    string name;
                    name = Path.GetFileNameWithoutExtension(file);
                    songi.Add(file);
                    songs.Items.Add(name);
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            if (selectedIndex == 0)
            {
                selectedIndex = songi.Count-1;
                Play(selectedIndex);
            }
            else
            {
                selectedIndex--;
                Play(selectedIndex);
            }
        }
        private void Repeat_Click(object sender, RoutedEventArgs e)
        {
            if (repeat)
            {
                repeat = false;                  
            }
            else
            {
                repeat = true;
            }
        }

        private void audio_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            position = new TimeSpan(Convert.ToInt64(audio_Slider.Value));
            media.Position = new TimeSpan(Convert.ToInt64(audio_Slider.Value)); 
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            audio_Slider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
            duration = media.NaturalDuration.TimeSpan;
            timer.Start();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (repeat)
            {
                Play(selectedIndex);
            }
            else
            {
                selectedIndex++;
                Play(selectedIndex);
            }
        }
    }
}
