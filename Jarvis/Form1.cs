using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;
using FaceRecognition;

namespace Jarvis
{
    public partial class Form1 : Form
    {
        bool wake = true;
        bool recognise = false;
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        Choices wordlist = new Choices();
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        FaceRec faceRec = new FaceRec();

        public void say(String h)
        {
            s.Speak(h);
        }
        public Form1()
        {
            s.SelectVoiceByHints(VoiceGender.Male);
            start();

            // Szólista
            wordlist.Add(File.ReadAllLines("wordlist.txt"));
            // Vezér parancsok
            list.Add(new string[] { "jarvis hide yourself", "jarvis hide", "jarvis show yourself", "jarvis show", "good morning jarvis", "good afternoon jarvis", "good evening jarvis",
                "jarvis go offline", "jarvis offline mode", "jarvis exit", "jarvis fullscreen mode", "jarvis open google", "jarvis open fortnite", "jarvis open pub g", "jarvis open steam",
                "jarvis open youtube","jarvis play", "jarvis pause", "jarvis play riddim", "jarvis play rap music", "jarvis play trap music", "jarvis play blacktrap", "jarvis wake up", "jarvis fullscreen",
                "jarvis what date is today", "jarvis open facebook", "jarvis open rust", "jarvis open hitman", "jarvis youtube fullscreen", "jarvis close google", "jarvis close tab",
                "jarvis close page", "jarvis new tab", "jarvis new page", "jarvis whats the time", "jarvis what time is it", "jarvis close chrome", "jarvis incognito mode", "jarvis incognito",
                "jarvis open chrome", "jarvis restart", "jarvis update", "jarvis open discord", "jarvis close discord", "jarvis open spotify", "search for", "jarvis whats the date", "jarvis what are you",
                "jarvis who are you","jarvis detect", "jarvis detect face", "jarvis detect faces", "jarvis save face", "jarvis recognise", "jarvis stop recogniseing", "jarvis show log", "jarvis hide log",
                "jarvis stop the recogniseing process", "jarvis store face", "jarvis stop", "jarvis forward", "jarvis backward", "jarvis mute", "jarvis unmute"});

            Grammar gr = new Grammar(new GrammarBuilder(list));
            Grammar grwl = new Grammar(new GrammarBuilder(wordlist));
            try
            {
                rec.SetInputToDefaultAudioDevice();
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.LoadGrammar(grwl);
                rec.SpeechRecognized += rec_SpeeachRecognised;
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }
            InitializeComponent();
        }

        private void rec_SpeeachRecognised(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            if (wake == false) // Ha a rendszer (OFFLINE) akkor ezek a parancsok élnek.
            {
                switch (r)
                {
                    case "good morning jarvis":
                    case "good afternoon jarvis":
                    case "good evening jarvis":
                    case "jarvis wake up":
                        wake = true;
                        offline.Visible = false;
                        pictureBox1.Visible = true;
                        Log.Text = ("System Online");
                        say("All system online");
                        break;
                    case "jarvis exit":
                        stop();
                        Application.Exit();
                        break;
                }
            }

            if (wake == true) // Ha a rendszer (ONLINE) akkor ezek a parancsok élnek a (GOOGLE CHROME)-on belül!
            {
                Process[] pname = Process.GetProcessesByName("opera");
                if (wake == true && pname.Length != 0)
                switch (r)
                {
                    case "jarvis close tab":
                    case "jarvis close page":
                        SendKeys.Send("^w");
                        Log.Text = ("Close tab");
                        break;
                    case "jarvis incognito":
                    case "jarvis incognito mode":
                        SendKeys.Send("^+n");
                        Log.Text = ("Incognito mode");
                        break;
                    case "jarvis close google":
                    case "jarvis close chrome":
                        for (int i = 0; i < pname.Length; i++)
                        pname[i].Kill();
                        Log.Text = ("Google closed");
                        break;
                    case "jarvis new page":
                    case "jarvis new tab":
                        SendKeys.Send("^t");
                        Log.Text = ("New page");
                        break;
                    case "jarvis fullscreen mode":
                    case "jarvis fullscreen":
                        SendKeys.Send("{f11}");
                        Log.Text = ("Fullscreen mode");
                        break;
                    case "jarvis youtube fullscreen":
                    case "jarvis go fullscreen":
                            SendKeys.Send("{f}");
                        Log.Text = ("Youtube fullscreen");
                        break;
                    case "jarvis play":
                    case "jarvis pause":
                    case "jarvis stop":
                        SendKeys.Send("{k}");
                        Log.Text = ("Pause");
                        break;
                    case "jarvis forward":
                        SendKeys.Send("{l}");
                        Log.Text = ("Forwarding in the video 10s");
                        break;
                    case "jarvis backward":
                        SendKeys.Send("{j}");
                        Log.Text = ("Backwarding in the video 10s");
                        break;
                    case "jarvis mute":
                    case "jarvis unmute":
                        SendKeys.Send("{m}");
                        Log.Text = ("Mute/Unmute Video On Youtube");
                        break;
                }
                if (r.StartsWith("jarvis search for"))
                {
                    String search;
                    search = r.Replace("jarvis search for", " ");
                    say("Searching for" + search);
                    search = r.Trim();
                    search = r.Replace(" ", "+");
                    Process.Start("https://www.google.com/search?q=" + search);
                    Log.Text = ("Search.");
                }
            }
            
            if (wake == true) // Ha a rendszer (ONLINE) akkor ezek a parancsok élnek.
            {
                switch (r)
                {
                    case "jarvis restart":
                        restart();
                        break;
                    case "jarvis what are you":
                    case "jarvis who are you":
                        say("Im an Artificial intelligence created by Krypton");
                        break;
                    case "jarvis update":
                        update();
                        break;
                    case "jarvis hide yourself":
                    case "jarvis hide":
                        say("Ok sir.");
                        Log.Text = ("Jarvis hide");
                        this.WindowState = FormWindowState.Minimized;
                        this.ShowInTaskbar = false;
                        break;
                    case "jarvis show yourself":
                    case "jarvis show":
                        say("Ok sir.");
                        Log.Text = ("Jarvis show");
                        this.WindowState = FormWindowState.Normal;
                        this.ShowInTaskbar = true;
                        break;
                    case "jarvis go offline":
                    case "jarvis offline mode":
                        wake = false;
                        pictureBox1.Visible = false;
                        offline.Visible = true;
                        offline.ForeColor = Color.Red;
                        Log.Text = ("Offline mode");
                        say("All system offline");
                        break;
                    case "jarvis exit":
                        stop();
                        Application.Exit();
                        break;
                    case "jarvis open chrome":
                    case "jarvis open google":
                        Process.Start("http://www.google.com");
                        say("Opening google!");
                        Log.Text = ("Google opened");
                        break;
                    case "jarvis open youtube":
                        Process.Start("http://www.youtube.com");
                        say("Opening youtube!");
                        Log.Text = ("Youtube opened");
                        break;
                    case "jarvis play riddim":
                        Process.Start("https://www.youtube.com/watch?v=54WKqm_FEgU&list=PLKKhCYMcdSUhJFpyGo5E20knTX9YuwdSu&index=82");
                        say("Playing riddim!");
                        Log.Text = ("Playing Riddim");
                        break;
                    case "jarvis play rap music":
                        Process.Start("https://www.youtube.com/watch?v=sMPmcJ54_IM&list=PLKKhCYMcdSUjSHNxEuphPM08O6-rSzOxu&index=109");
                        say("Playing rap music!");
                        Log.Text = ("Playing Rap music");
                        break;
                    case "jarvis play trap music":
                        Process.Start("https://www.youtube.com/watch?v=COYQbdVZIW8&list=PLKKhCYMcdSUharTFualK8As_q3yPvASB6&index=2&t=0s");
                        say("Playing trap music!");
                        Log.Text = ("Playing Trap music");
                        break;
                    case "jarvis play blacktrap":
                        Process.Start("https://www.youtube.com/watch?v=JTdbnIvw8hk&list=PLKKhCYMcdSUhLGP90jfgmLtBvb3e297lY&index=2&t=0s");
                        say("Playing blacktrap!");
                        Log.Text = ("Playing BlackTrap");
                        break;
                    case "jarvis open fortnite":
                        Process.Start("com.epicgames.launcher://apps/Fortnite?action=launch&silent=true");
                        say("Opening fortnite!");
                        Log.Text = ("Fortnite opened");
                        break;
                    case "jarvis open pub g":
                        Process.Start("steam://rungameid/578080");
                        say("Opening pub g!");
                        Log.Text = ("Pubg opened");
                        break;
                    case "jarvis open steam":
                        Process.Start("C:\\Program Files (x86)\\Steam\\Steam.exe");
                        say("Opening steam!");
                        Log.Text = ("Steam opened");
                        break;
                    case "jarvis open epic games":
                        Process.Start("C:\\Program Files(x86)\\Epic Games\\Launcher\\Portal\\Binaries\\Win32\\EpicGamesLauncher.exe");
                        say("Opening Epic Games!");
                        Log.Text = ("Epic Games opened");
                        break;
                    case "jarvis what date is today":
                    case "jarvis whats the date":
                        say(DateTime.Now.ToString("MM-dd-yyyy"));
                        Log.Text = ("Date");
                        break;
                    case "jarvis open facebook":
                        say("Opening facebook!");
                        Process.Start("http://www.facebook.com");
                        Log.Text = ("Facebook opened");
                        break;
                    case "jarvis open rust":
                        say("Opening rust!");
                        Process.Start("steam://rungameid/252490");
                        Log.Text = ("Rust opened");
                        break;
                    case "jarvis open hitman":
                        say("Opening hitman 2!");
                        Process.Start("F:\\Hitman 2\\Launcher.exe");
                        Log.Text = ("Hitman 2 opened");
                        break;
                    case "jarvis whats the time":
                    case "jarvis what time is it":
                        say(DateTime.Now.ToString("h-mm tt"));
                        Log.Text = ("Time");
                        break;
                    case "jarvis open discord":
                        Process.Start(@"C:\Users\Krypton\AppData\Local\Discord\app-0.0.305\Discord.exe");
                        Log.Text = ("Discord opened");
                        break;
                    case "jarvis close discord":
                        killProg("Discord.exe");
                        Log.Text = ("Discord closed");
                        break;
                    case "jarvis open spotify":
                        Process.Start(@"C:\Users\Krypton\AppData\Roaming\Spotify\Spotify.exe");
                        Log.Text = ("Spotify opened");
                        break;
                    case "jarvis show log":
                        Log.Text = ("Log Show");
                        say("Showing Log");
                        Log.Visible = true;
                        break;
                    case "jarvis hide log":
                        Log.Text = ("Log Hide");
                        say("Hideing Log");
                        Log.Visible = false;
                        break;
                    case "jarvis recognise":
                        CameraBox.Visible = true;
                        DetectedImageBox.Visible = true;
                        Camera_Label.Visible = true;
                        Captured_Label.Visible = true;
                        Name_Label.Visible = true;
                        FaceName_TextBox.Visible = true;
                        recognise = true;
                        faceRec.openCamera(CameraBox, DetectedImageBox);
                        Log.Text = ("Face Recognition Process Has Been Started");
                        say("Face Recognition Process Has Been Started");
                        break;
                }
            }
            if (wake == true && recognise == true)
            {
                switch (r)
                {
                    case "jarvis detect":
                    case "jarvis detect face":
                    case "jarvis detect faces":
                        faceRec.isTrained = true;
                        Log.Text = ("Detecting face...");
                        say("Detecting Face");
                        break;
                    case "jarvis save face":
                    case "jarvis store face":
                        faceRec.Save_IMAGE(FaceName_TextBox.Text);
                        Log.Text = ("Face saved");
                        say("New Face Added To The Library");
                        break;
                    case "jarvis stop recogniseing":
                    case "jarvis stop the recogniseing process":
                        CameraBox.Visible = false;
                        DetectedImageBox.Visible = false;
                        Camera_Label.Visible = false;
                        Captured_Label.Visible = false;
                        Name_Label.Visible = false;
                        FaceName_TextBox.Visible = false;
                        recognise = false;
                        Log.Text = ("Stopping Face Recognition Process");
                        say("Stopping Face Recognition Process");
                        break;
                    case "jarvis exit":
                        stop();
                        Application.Exit();
                        break;
                }
            }
        }
        public static void killProg(String s) // Program leállítás
        {
            System.Diagnostics.Process[] procs = null;

            try
            {
                procs = Process.GetProcessesByName(s);
                Process prog = procs[0];

                if (!prog.HasExited)
                {
                    prog.Kill();
                }
            }
            finally
            {
                if(procs != null)
                {
                    foreach (Process p in procs)
                    {
                        p.Dispose();
                    }
                }
            }
        }
        public void start() // Napszaknak megfelelő köszönés indításkor (ON START).
        {
            if (DateTime.Now.ToString("tt") == "AM" && int.Parse(DateTime.Now.ToString("hh")) >= 4)
            {
                say("Good Morning sir.");
            }
            else if (DateTime.Now.ToString("tt") == "PM" && int.Parse(DateTime.Now.ToString("hh")) <= 6)
            {
                say("Good afternoon sir.");

            }
            else
            {
                say("Good evening sir.");
            }

        }
        public void stop() // Napszaknak megfelelő elköszönés leállításkor (ON SHUTDOWN).
        {
            if (DateTime.Now.ToString("tt") == "AM" && int.Parse(DateTime.Now.ToString("hh")) >= 4)
            {
                say("have a nice day sir");
            }
            else if (DateTime.Now.ToString("tt") == "PM" && int.Parse(DateTime.Now.ToString("hh")) <= 6)
            {
                say("bye sir");

            }
            else
            {
                say("Good night sir");
            }

        }

        public void restart() // Újraindítás
        {
            Process.Start("Jarvis.exe");
            Environment.Exit(0);
        }

        public void update() // Frissítés
        {
            Process.Start("Jarvis.exe");
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Log.- box megjelenítése
        {
            if (Log.Visible == false)
            {
                Log.Visible = true;
            }
            else
            {
                Log.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void offline_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}