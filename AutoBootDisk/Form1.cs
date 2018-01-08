using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using SevenZip;
using System.Reflection;
using System.Text.RegularExpressions;
namespace AutoBootDisk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string[] LANG_ = File.ReadAllText("EN.lang").Split('\n');
        public bool MouseDown_ = false;
        public int mouseX;
        public int mouseY;
        public bool Custom_;
        public string Distro_;
        public string ISOpath_;
        public Uri Link;
        public string SelectedDrive_;
        public WebClient ISOdownloader = new WebClient();
        Point mouseDownPoint = Point.Empty;
        public string LinusSavePath_;
        private void panel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_ = true;
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {


                this.SetDesktopLocation(mouseX, mouseY);

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_ = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Custom_ = true;
            panel4.Visible = true;
            panel5.Visible = false;
            panel3.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Custom_ = false;
            panel3.Visible = false;




        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_ = true;
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 31; i++)
            {
                string Match_ = Regex.Match(LANG_[i], @"(?<=<)(\w+)(?=>)").ToString();
                string LANG_TEXT = Regex.Match(LANG_[i], @"(?<=>)(.+)(?=<)").ToString();
                Control c_ = Controls.Find(Match_, true)[0];
                c_.Text = LANG_TEXT;
            }
            Process.Start("AutoBootDisk Updater.exe");
            for (int i = 0; i < DriveInfo.GetDrives().Length; i++)
            {
                if (DriveInfo.GetDrives()[i].IsReady == true)
                {
                    comboBox2.Items.Add(DriveInfo.GetDrives()[i]);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a Distribution");
            }
            else
            {

                if (comboBox1.Text == "Ubuntu")
                {
                    Link = new Uri("http://mirror.math.princeton.edu/pub/ubuntu-iso/17.10/ubuntu-17.10-desktop-amd64.iso");
                }
                else if (comboBox1.Text == "Kubuntu")
                {
                    Link = new Uri("http://cdimage.ubuntu.com/kubuntu/releases/17.10/release/kubuntu-17.10-desktop-amd64.iso");
                }
                else if (comboBox1.Text == "Lubuntu")
                {
                    Link = new Uri("http://cdimage.ubuntu.com/lubuntu/releases/artful/release/lubuntu-17.10-desktop-amd64.iso");
                }
                else if (comboBox1.Text == "Xubuntu")
                {
                    Link = new Uri("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/17.10/release/xubuntu-17.10-desktop-amd64.iso");
                }
                else if (comboBox1.Text == "UbuntuStudio")
                {
                    Link = new Uri("http://cdimage.ubuntu.com/ubuntustudio/releases/artful/release/ubuntustudio-17.10-dvd-amd64.iso");
                }
                else if (comboBox1.Text == "Zenwalk")
                {
                    Link = new Uri("http://linuxfreedom.com/zenwalk/zenwalk-gnome-6.4.iso");
                }
                else if (comboBox1.Text == "Slax")
                {
                    Link = new Uri("http://ftp.sh.cvut.cz/slax/Slax-9.x/slax-64bit-9.2.1.iso");
                }
                else if (comboBox1.Text == "SliTaz")
                {
                    Link = new Uri("http://mirror.slitaz.org/iso/rolling/slitaz-rolling.iso");
                }
                else if (comboBox1.Text == "MEPIS")
                {
                    Link = new Uri("http://distro.ibiblio.org/mepis/released/SimplyMEPIS-DVD_11.0.12_64.iso");
                }
                else if (comboBox1.Text == "FrugalwareLinux")
                {
                    Link = new Uri("http://ftp10.frugalware.org/frugalware/frugalware-2.1-iso/fvbe-2.1-kde5-x86_64.iso");
                }
                else if (comboBox1.Text == "LinuxConsole")
                {
                    Link = new Uri("http://jukebox.linuxconsole.org/official/linuxconsole.2.5-x86_64.iso");
                }
                else if (comboBox1.Text == "xPUD")
                {
                    Link = new Uri("http://ftp.ubuntu-tw.org/mirror/download.xpud.org/xpud-0.9.2.iso");
                }
                else if (comboBox1.Text == "Mageia")
                {
                    Link = new Uri("http://mirror.math.princeton.edu/pub/mageia/iso/6/Mageia-6-LiveDVD-Plasma-x86_64-DVD/Mageia-6-LiveDVD-Plasma-x86_64-DVD.iso");
                }
                else if (comboBox1.Text == "SparkyLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/sparkylinux/lxqt/sparkylinux-5.2-x86_64-lxqt.iso?r=&ts=1514509738&use_mirror=versaweb");
                }
                else if (comboBox1.Text == "GentooLinux")
                {
                    Link = new Uri("https://mirrors.kernel.org/gentoo//releases/amd64/20160704/livedvd-amd64-multilib-20160704.iso");
                }
                else if (comboBox1.Text == "Edubuntu")
                {
                    Link = new Uri("http://cdimage.ubuntu.com/edubuntu/releases/14.04.2/release/edubuntu-14.04-dvd-amd64.iso");
                }
                else if (comboBox1.Text == "PCLinuxOS")
                {
                    Link = new Uri("http://spout.ussg.indiana.edu/linux/pclinuxos/pclinuxos/live-cd/64bit/pclinuxos64-MATE-2017.11.iso");
                }
                else if (comboBox1.Text == "LinuxLite")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/linuxlite/3.6/linux-lite-3.6-64bit.iso?r=https%3A%2F%2Fwww.linuxliteos.com%2Fdownload.php&ts=1512002314&use_mirror=cytranet");
                }
                else if (comboBox1.Text == "ElementaryOS")
                {
                    Link = new Uri("http://archive.org/download/elementaryos-0.4.1-stable.20170814/elementaryos-0.4.1-stable.20170814.iso");
                }
                else if (comboBox1.Text == "openSUSE")
                {
                    Link = new Uri("http://download.opensuse.org/tumbleweed/iso/openSUSE-Tumbleweed-Kubic-DVD-x86_64-Current.iso");
                }
                else if (comboBox1.Text == "ArchLinux")
                {
                    Link = new Uri("http://mirrors.acm.wpi.edu/archlinux/iso/2017.12.01/archlinux-2017.12.01-x86_64.iso");
                }
                else if (comboBox1.Text == "Fedora")
                {
                    Link = new Uri("https://download.fedoraproject.org/pub/fedora/linux/releases/27/Workstation/x86_64/iso/Fedora-Workstation-Live-x86_64-27-1.6.iso");
                }
                else if (comboBox1.Text == "UbuntuMATE")
                {
                    Link = new Uri("http://cdimage.ubuntu.com/ubuntu-mate/releases/17.10/release/ubuntu-mate-17.10-desktop-amd64.iso");
                }
                else if (comboBox1.Text == "BodhiLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/bodhilinux/4.4.0/bodhi-4.4.0-64.iso?r=&ts=1513371942&use_mirror=superb-sea2");
                }
                else if (comboBox1.Text == "MandrivaLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/openmandriva/release/3.03/OpenMandrivaLx.3.03-PLASMA.x86_64.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Fopenmandriva%2F&ts=1513371989&use_mirror=ayera");
                }
                else if (comboBox1.Text == "CrunchBang")
                {
                    Link = new Uri("https://ddl.bunsenlabs.org/ddl/bl-Deuterium-amd64_20170429.iso");
                }
                else if (comboBox1.Text == "Peppermint")
                {
                    Link = new Uri("https://peppermintos.com/iso/Peppermint-8-20171130-amd64.iso");
                }
                else if (comboBox1.Text == "BlackArchLinux")
                {
                    Link = new Uri("http://ftp.halifax.rwth-aachen.de/blackarch/iso/blackarchlinux-live-2017.12.11-x86_64.iso");
                }
                else if (comboBox1.Text == "BackBox")
                {
                    Link = new Uri("https://mirror3.mirror.garr.it/2/backbox/backbox-5-amd64.iso");
                }
                else if (comboBox1.Text == "Tails")
                {
                    Link = new Uri("https://tails.tetaneutral.net/stable/tails-amd64-3.3/tails-amd64-3.3.iso");
                }
                else if (comboBox1.Text == "KaliLinux")
                {
                    Link = new Uri("http://cdimage.kali.org/kali-2017.3/kali-linux-2017.3-amd64.iso");
                }
                else if (comboBox1.Text == "SabayonLinux")
                {
                    Link = new Uri("http://dl.sabayon.org/stable/Sabayon_Linux_16.11_amd64_GNOME.iso");
                }
                else if (comboBox1.Text == "PinguyOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/pinguy-os/Pinguy_OS_14.04_LTS/Full/64/Pinguy_OS_14.04.4-1-LTS_x86-64.iso?r=&ts=1513372646&use_mirror=newcontinuum");
                }
                else if (comboBox1.Text == "AlpineLinux")
                {
                    Link = new Uri("http://dl-cdn.alpinelinux.org/alpine/v3.7/releases/x86_64/alpine-standard-3.7.0-x86_64.iso");
                }
                else if (comboBox1.Text == "VoidLinux")
                {
                    Link = new Uri("https://repo.voidlinux.eu/live/current/void-live-x86_64-20171007-cinnamon.iso");
                }
                else if (comboBox1.Text == "NixOS")
                {
                    Link = new Uri("https://d3g5gsiof5omrk.cloudfront.net/nixos/17.09/nixos-17.09.2378.af7e47921c4/nixos-graphical-17.09.2378.af7e47921c4-x86_64-linux.iso");
                }
                else if (comboBox1.Text == "TinHatLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/tinhat/images/th-amd64-fluxbox-20150616.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Ftinhat%2F&ts=1513373081&use_mirror=versaweb");
                }
                else if (comboBox1.Text == "CentOS")
                {
                    Link = new Uri("http://mirrors.umflint.edu/CentOS/7/isos/x86_64/CentOS-7-x86_64-DVD-1708.iso");
                }
                else if (comboBox1.Text == "PuppyLinux")
                {
                    Link = new Uri("http://distro.ibiblio.org/puppylinux/puppy-slacko-6.3.0/64/slacko64-6.3.0.iso");
                }
                else if (comboBox1.Text == "FreeBSD")
                {
                    Link = new Uri("https://download.freebsd.org/ftp/releases/amd64/amd64/ISO-IMAGES/11.1/FreeBSD-11.1-RELEASE-amd64-bootonly.iso");
                }

                if (comboBox1.Text == "KaOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/kaosx/ISO/KaOS-2017.11-x86_64.iso?r=https%3A%2F%2Fkaosx.us%2Fpages%2Fdownload%2F&ts=1514065978&use_mirror=gigenet");
                }
                else if (comboBox1.Text == "SteamOS")
                {
                    Link = new Uri("http://repo.steampowered.com/download/SteamOSDVD.iso");
                }
                else if (comboBox1.Text == "ManjaroLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/manjarolinux/release/17.0.6/kde/manjaro-kde-17.0.6-stable-x86_64.iso?r=https%3A%2F%2Fmanjaro.org%2Fget-manjaro%2F&ts=1514519122&use_mirror=ayera");
                }
                else if (comboBox1.Text == "KasperskyRescueDisk")
                {
                    Link = new Uri("http://rescuedisk.kaspersky-labs.com/rescuedisk/updatable/kav_rescue_10.iso");
                }
                else if (comboBox1.Text == "OPHcrack")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/ophcrack/ophcrack-livecd/3.6.0/ophcrack-notables-livecd-3.6.0.iso?r=&ts=1514066735&use_mirror=superb-sea2");
                }
                else if (comboBox1.Text == "DrWebLiveDisk")
                {
                    Link = new Uri("https://download.geo.drweb.com/pub/drweb/livedisk/drweb-livedisk-900-cd.iso");
                }
                else if (comboBox1.Text == "Parsix")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/xfardic/Parsix-Mirror/8.15r1/parsix_8.15r1-amd64.iso?r=&ts=1514070753&use_mirror=ayera");
                }
                else if (comboBox1.Text == "ArchLabs")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/archlabs-linux-minimo/ArchLabsMinimo/archlabs-2017-12.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Farchlabs-linux-minimo%2F&ts=1514072985&use_mirror=astuteinternet");
                }
                else if (comboBox1.Text == "EndlessOS")
                {
                    Link = new Uri("https://d1anzknqnc1kmb.cloudfront.net/release/3.3.7/eos-amd64-amd64/base/eos-eos3.3-amd64-amd64.171221-010154.base.iso");
                }
                else if (comboBox1.Text == "Solus")
                {
                    Link = new Uri("http://mirror.math.princeton.edu/pub/solus-iso/Solus-3-GNOME.iso");
                }
                else if (comboBox1.Text == "Deepin")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/deepin/15.5/Release/deepin-15.5-amd64.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Fdeepin%2F&ts=1514072337&use_mirror=iweb");
                }
                else if (comboBox1.Text == "MXLinux")
                {
                    Link = new Uri("http://iso.mxrepo.com/Final/MX-17/MX-17_x64.iso");
                }
                else if (comboBox1.Text == "KDEneon")
                {
                    Link = new Uri("https://files.kde.org/neon/images/neon-useredition/current/neon-useredition-current.iso");
                }
                else if (comboBox1.Text == "ParrotSecurityOS")
                {
                    Link = new Uri("https://cdimage.parrotsec.org/parrot/iso/3.10.1/Parrot-security-3.10.1_amd64.iso");
                }
                else if (comboBox1.Text == "LXLE")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/lxle/Final/OS/16.04.3-64/lxle_16.04.3_64.iso?r=http%3A%2F%2Fwww.lxle.net%2Fdownload%2F&ts=1514073444&use_mirror=newcontinuum");
                }
                else if (comboBox1.Text == "Android-x86")
                {
                    Link = new Uri("http://fosshub.com/Android-x86.html/android-x86_64-7.1-rc2.iso");
                }
                else if (comboBox1.Text == "ferenOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/ferenoslinux/feren%20OS%20x64.iso?r=https%3A%2F%2Fferenos.weebly.com%2Fget-it.html&ts=1514073568&use_mirror=gigenet");
                }
                else if (comboBox1.Text == "BlackLabLinux")
                {
                    Link = new Uri("http://distro.ibiblio.org/blacklab/8/bll-8-mate-x86_64.iso");
                }
                else if (comboBox1.Text == "TinyCoreLinux")
                {
                    Link = new Uri("http://www.tinycorelinux.net/8.x/x86_64/release/CorePure64-8.2.1.iso");
                }
                else if (comboBox1.Text == "4MLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/linux4m/23.0/livecd/updates/4MLinux-23.1.iso?r=http%3A%2F%2F4mlinux.com%2Fdownload%2Fstable.html&ts=1514073845&use_mirror=cytranet");
                }
                else if (comboBox1.Text == "BluestarLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/bluestarlinux/distro/bluestar-linux-4.14.6-2017.12.18-x86_64.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Fbluestarlinux%2F&ts=1514073929&use_mirror=phoenixnap");
                }
                else if (comboBox1.Text == "QubesOS")
                {
                    Link = new Uri("https://mirrors.kernel.org/qubes/iso/Qubes-R3.2-x86_64.iso");
                }
                else if (comboBox1.Text == "Netrunner")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/netrunneros/netrunner-1701-core/netrunner-core-1701-64bit.iso?r=&ts=1514074025&use_mirror=superb-sea2");
                }
                else if (comboBox1.Text == "ROSA")
                {
                    Link = new Uri("http://mirror.rosalab.ru/rosa/rosa2016.1/iso/ROSA.Fresh.R10/ROSA.FRESH.PLASMA.R10.x86_64.uefi.iso");
                }
                else if (comboBox1.Text == "KaOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/kaosx/ISO/KaOS-2017.11-x86_64.iso?r=https%3A%2F%2Fkaosx.us%2Fpages%2Fdownload%2F&ts=1514074094&use_mirror=versaweb");
                }
                else if (comboBox1.Text == "ExTiX")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/extix/extix-18.0-64bit-deepin-refracta-calamares-grub-efi-1470mb-171208.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Fextix%2F&ts=1514074163&use_mirror=pilotfiber");
                }
                else if (comboBox1.Text == "ClearOS")
                {
                    Link = new Uri("http://mirror.clearos.com/clearos/7/iso/x86_64/ClearOS-DVD-x86_64.iso");
                }
                else if (comboBox1.Text == "RedcoreLinux")
                {
                    Link = new Uri("http://mirror.math.princeton.edu/pub/redcorelinux/iso/Redcore.Linux.1710.R1.LXQT.amd64.iso");
                }
                else if (comboBox1.Text == "RevengeOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/obrevenge/revengeos-2017.07-.iso?r=&ts=1514074282&use_mirror=superb-sea2");
                }
                else if (comboBox1.Text == "ClonezillaLive")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/clonezilla/clonezilla_live_stable/2.5.2-31/clonezilla-live-2.5.2-31-amd64.iso?r=http%3A%2F%2Fclonezilla.org%2Fdownloads%2Fdownload.php%3Fbranch%3Dstable&ts=1514074339&use_mirror=pilotfiber");
                }
                else if (comboBox1.Text == "ChakraLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/chakra/2017.10/chakra-2017.10-goedel-x86_64.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Fchakra%2F&ts=1514074397&use_mirror=astuteinternet");
                }
                else if (comboBox1.Text == "GeckoLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/geckolinux/Static/422.170302/GeckoLinux_Gnome.x86_64-422.170302.0.iso?r=http%3A%2F%2Fgeckolinux.github.io%2F&ts=1514074420&use_mirror=cfhcable");
                }
                else if (comboBox1.Text == "NuTyX")
                {
                    Link = new Uri("http://downloads.nutyx.org/NuTyX_x86_64-9.93.iso");
                }
                else if (comboBox1.Text == "SharkLinux")
                {
                    Link = new Uri("http://sharklinuxos.org/current/SharkLinux.iso");
                }
                else if (comboBox1.Text == "VectorLinux")
                {
                    Link = new Uri("http://vectorlinux.osuosl.org/veclinux-7.1/iso-release/VL-7.1-STD-FINAL.iso");
                }
                else if (comboBox1.Text == "ScientificLinux")
                {
                    Link = new Uri("http://ftp1.scientificlinux.org/linux/scientific/7x/x86_64/iso/SL-74-x86_64-2017-09-29-LiveDVDgnome.iso");
                }
                else if (comboBox1.Text == "TrisquelLinux")
                {
                    Link = new Uri("http://mirror.fsf.org/trisquel-images/trisquel_7.0_amd64.iso");
                }
                else if (comboBox1.Text == "AbsoluteLinux")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/absolute-linux/Absolute_14.2.2/absolute64-14.2.2.iso?r=https%3A%2F%2Fsourceforge.net%2Fprojects%2Fabsolute-linux%2F&ts=1514074985&use_mirror=phoenixnap");
                }
                if (comboBox1.Text == "Mint Cinnamon")
                {
                    Link = new Uri("http://mirrors.evowise.com/linuxmint/stable/18.3/linuxmint-18.3-cinnamon-64bit.iso");
                }
                if (comboBox1.Text == "Mint KDE")
                {
                    Link = new Uri("http://mirrors.evowise.com/linuxmint/stable/18.3/linuxmint-18.3-kde-64bit.iso");
                }
                if (comboBox1.Text == "Mint MATE")
                {
                    Link = new Uri("http://mirrors.evowise.com/linuxmint/stable/18.3/linuxmint-18.3-mate-64bit.iso");
                }
                if (comboBox1.Text == "Mint Xfce")
                {
                    Link = new Uri("http://mirrors.evowise.com/linuxmint/stable/18.3/linuxmint-18.3-xfce-64bit.iso");
                }
                if (comboBox1.Text == "ZorinOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/zorin-os/12/Zorin-OS-12.2-Core-64.iso?r=&ts=1514516210&use_mirror=superb-sea2");
                }
                if (comboBox1.Text == "Debian")
                {
                    Link = new Uri("https://cdimage.debian.org/debian-cd/current-live/amd64/iso-hybrid/debian-live-9.3.0-amd64-gnome.iso");
                }
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = true;
                saveFileDialog1.Filter = "ISO Images (*.iso)|*.iso";
                saveFileDialog1.DefaultExt = ".iso";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.ShowDialog();


            }
        }

        private void ISOdownloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                button6.Visible = true;
                button12.Visible = false;
            }
            else
            {
                panel5.Visible = true;
            }

        }

        private void ISOdownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            label12.Text = Convert.ToInt64(e.BytesReceived) + " / " + Convert.ToInt64(e.TotalBytesToReceive);
            progressBar1.Maximum = 100;
            progressBar1.Value = e.ProgressPercentage;
            label10.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ISO Images (*.iso)|*.iso";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ISOpath_ = openFileDialog1.FileName;
            richTextBox1.Text = ISOpath_;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            if (ISOpath_ == null)
            {
                MessageBox.Show("Select a file first");
            }
            else
            {

                panel4.Visible = false;
                panel6.Visible = false;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SelectedDrive_ = comboBox2.Text.Replace(@"\", "");
            if (SelectedDrive_ == "")
            {
                MessageBox.Show("Select a drive first!");
            }
            else
            {
                if (MessageBox.Show("This is your last chance to save the date on the drive you selected! Are you SURE you want to continue?", "WARNING : LAST CHANCE", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    Process CMD_ = new Process();

                    CMD_.StartInfo.CreateNoWindow = true;
                    CMD_.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    CMD_.StartInfo.Arguments = "/c echo y|Format " + SelectedDrive_ + " /Q /X";
                    CMD_.StartInfo.FileName = "CMD";
                    CMD_.Start();
                    CMD_.WaitForExit();
                    if (Custom_ == false)
                    {
                        unzip(LinusSavePath_);
                        panel7.Visible = false;
                    }
                    else
                    {
                        unzip(ISOpath_);
                        panel7.Visible = false;
                    }
                    panel8.Visible = true;


                }
            }
        }



        private void unzip(string path)
        {
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;
            progressBar2.Visible = true;

            var progressHandler = new Progress<byte>(percentDone => progressBar2.Value = percentDone);
            progressHandler.ProgressChanged += ProgressHandler_ProgressChanged;

            var progress = progressHandler as IProgress<byte>;

            Task.Run(() =>
            {
                var sevenZipPath = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    Environment.Is64BitProcess ? "x64" : "x86", "7z.dll");
                SevenZipBase.SetLibraryPath(sevenZipPath);


                var file = new SevenZipExtractor(path);
                file.Extracting += (sender, args) =>
                {
                    progress.Report(args.PercentDone);

                };

                file.ExtractArchive(SelectedDrive_);
            });
        }

        private void ProgressHandler_ProgressChanged(object sender, byte e)
        {
            progressBar2.Value = e;
            label20.Text = e.ToString() + "% Copied";
            if (e == 100)
            {
                MessageBox.Show("USB is ready for use.");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {

                this.Location = new Point(this.Location.X + (e.X - mouseDownPoint.X), this.Location.Y + (e.Y - mouseDownPoint.Y));


            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {

            MouseDown_ = false;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {
                this.Location = new Point(this.Location.X + (e.X - mouseDownPoint.X), this.Location.Y + (e.Y - mouseDownPoint.Y));

            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
            MouseDown_ = true;
        }

        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_ = false;
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_ = true;
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {

                this.Location = new Point(this.Location.X + (e.X - mouseDownPoint.X), this.Location.Y + (e.Y - mouseDownPoint.Y));


            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_ = false;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {
                this.Location = new Point(this.Location.X + (e.X - mouseDownPoint.X), this.Location.Y + (e.Y - mouseDownPoint.Y));
            }
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_ = true;
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void panel6_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_ = false;
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {
                this.Location = new Point(this.Location.X + (e.X - mouseDownPoint.X), this.Location.Y + (e.Y - mouseDownPoint.Y));
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_ = true;
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_ = false;
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_ == true)
            {
                this.Location = new Point(this.Location.X + (e.X - mouseDownPoint.X), this.Location.Y + (e.Y - mouseDownPoint.Y));
            }
        }

        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_ = true;
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void panel8_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_ = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            for (int i = 0; i < DriveInfo.GetDrives().Length; i++)
            {
                if (DriveInfo.GetDrives()[i].IsReady == true)
                {
                    comboBox2.Items.Add(DriveInfo.GetDrives()[i]);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("http://paypal.me/DKorennykh");
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ISOdownloader.CancelAsync();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel5.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel5.Visible = true;
            panel4.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = false;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel5.Visible = true;
            panel4.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process.Start("http://bluskript.wixsite.com/autobootdisk");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            LinusSavePath_ = saveFileDialog1.FileName;
            ISOdownloader.DownloadProgressChanged += ISOdownloader_DownloadProgressChanged;
            ISOdownloader.DownloadFileCompleted += ISOdownloader_DownloadFileCompleted;
            ISOdownloader.DownloadFileAsync(Link, LinusSavePath_);

            label11.Text = label11.Text + LinusSavePath_;
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            if (comboBox1.Text == "Ubuntu")
            {

                string LANG_TEXT = Regex.Match(LANG_[32], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Kubuntu")
            {

                string LANG_TEXT = Regex.Match(LANG_[33], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Lubuntu")
            {

                string LANG_TEXT = Regex.Match(LANG_[34], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Xubuntu")
            {

                string LANG_TEXT = Regex.Match(LANG_[35], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "UbuntuStudio")
            {

                string LANG_TEXT = Regex.Match(LANG_[36], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Zenwalk")
            {

                string LANG_TEXT = Regex.Match(LANG_[37], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Slax")
            {

                string LANG_TEXT = Regex.Match(LANG_[38], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "SliTaz")
            {

                string LANG_TEXT = Regex.Match(LANG_[39], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "MEPIS")
            {

                string LANG_TEXT = Regex.Match(LANG_[40], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "FrugalwareLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[41], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "LinuxConsole")
            {

                string LANG_TEXT = Regex.Match(LANG_[42], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "xPUD")
            {

                string LANG_TEXT = Regex.Match(LANG_[43], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Mageia")
            {

                string LANG_TEXT = Regex.Match(LANG_[44], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "SparkyLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[45], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "GentooLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[46], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Edubuntu")
            {

                string LANG_TEXT = Regex.Match(LANG_[47], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "PCLinuxOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[48], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "LinuxLite")
            {

                string LANG_TEXT = Regex.Match(LANG_[49], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ElementaryOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[50], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "openSUSE")
            {

                string LANG_TEXT = Regex.Match(LANG_[51], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ArchLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[52], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Fedora")
            {

                string LANG_TEXT = Regex.Match(LANG_[53], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "UbuntuMATE")
            {

                string LANG_TEXT = Regex.Match(LANG_[54], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "BodhiLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[55], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "MandrivaLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[56], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "CrunchBang")
            {

                string LANG_TEXT = Regex.Match(LANG_[57], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Peppermint")
            {

                string LANG_TEXT = Regex.Match(LANG_[58], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "BlackArchLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[59], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "BackBox")
            {

                string LANG_TEXT = Regex.Match(LANG_[60], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Tails")
            {

                string LANG_TEXT = Regex.Match(LANG_[61], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "KaliLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[62], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "SabayonLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[63], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "PinguyOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[64], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "AlpineLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[65], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "VoidLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[66], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "NixOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[67], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "TinHatLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[68], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "CentOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[69], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "PuppyLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[70], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ZorinOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[71], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "FreeBSD")
            {

                string LANG_TEXT = Regex.Match(LANG_[72], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "KaOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[73], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "SteamOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[74], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ManjaroLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[75], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "KasperskyRescueDisk")
            {

                string LANG_TEXT = Regex.Match(LANG_[76], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "OPHcrack")
            {

                string LANG_TEXT = Regex.Match(LANG_[77], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "DrWebLiveDisk")
            {

                string LANG_TEXT = Regex.Match(LANG_[78], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Parsix")
            {

                string LANG_TEXT = Regex.Match(LANG_[79], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ArchLabs")
            {

                string LANG_TEXT = Regex.Match(LANG_[80], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "EndlessOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[81], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Solus")
            {

                string LANG_TEXT = Regex.Match(LANG_[82], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Deepin")
            {

                string LANG_TEXT = Regex.Match(LANG_[83], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "MXLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[84], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "KDEneon")
            {

                string LANG_TEXT = Regex.Match(LANG_[85], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ParrotSecurityOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[86], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "LXLE")
            {

                string LANG_TEXT = Regex.Match(LANG_[87], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Android-x86")
            {

                string LANG_TEXT = Regex.Match(LANG_[88], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ferenOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[89], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "BlackLabLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[90], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "TinyCoreLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[91], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "4MLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[92], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "BluestarLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[93], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "QubesOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[94], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "Netrunner")
            {

                string LANG_TEXT = Regex.Match(LANG_[95], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ROSA")
            {

                string LANG_TEXT = Regex.Match(LANG_[96], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ExTiX")
            {

                string LANG_TEXT = Regex.Match(LANG_[97], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ClearOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[98], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "RedcoreLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[99], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "RevengeOS")
            {

                string LANG_TEXT = Regex.Match(LANG_[100], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ClonezillaLive")
            {

                string LANG_TEXT = Regex.Match(LANG_[101], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ChakraLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[102], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "GeckoLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[103], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "NuTyX")
            {

                string LANG_TEXT = Regex.Match(LANG_[104], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "SharkLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[105], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "VectorLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[106], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "ScientificLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[107], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "TrisquelLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[108], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            else if (comboBox1.Text == "AbsoluteLinux")
            {

                string LANG_TEXT = Regex.Match(LANG_[109], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            if (comboBox1.Text == "MintCinnamon")
            {

                string LANG_TEXT = Regex.Match(LANG_[110], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            if (comboBox1.Text == "MintKDE")
            {

                string LANG_TEXT = Regex.Match(LANG_[111], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            if (comboBox1.Text == "MintMATE")
            {

                string LANG_TEXT = Regex.Match(LANG_[112], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            if (comboBox1.Text == "MintXfce")
            {

                string LANG_TEXT = Regex.Match(LANG_[113], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
            if (comboBox1.Text == "Debian")
            {
                string LANG_TEXT = Regex.Match(LANG_[114], @"(?<=>)(.+)(?=<)").ToString();
                label21.Text = LANG_TEXT;
            }
        }

        private void panel1_Click_1(object sender, EventArgs e)
        {
            Process LANG_SELECT_ = new Process();
            LANG_SELECT_.EnableRaisingEvents = true;
            LANG_SELECT_.Exited += LANG_SELECT__Exited;
            LANG_SELECT_.StartInfo.FileName = "LanguageSelector.exe";
            LANG_SELECT_.Start();
            
        }

        private void LANG_SELECT__Exited(object sender, EventArgs e)
        {
            if (File.ReadAllText("SelectedLanguage.txt") == "English")
            {
                LANG_ = File.ReadAllText("EN.lang").Split('\n');
            }
            else if (File.ReadAllText("SelectedLanguage.txt") == "русский")
            {
                LANG_ = File.ReadAllText("RU.lang").Split('\n');
            }
            else if (File.ReadAllText("SelectedLanguage.txt") == "Ελληνικά")
            {
                LANG_ = File.ReadAllText("GR.lang").Split('\n');
            }
            else if (File.ReadAllText("SelectedLanguage.txt") == "Deutsche")
            {
                LANG_ = File.ReadAllText("DE.lang").Split('\n');
            }
            else if (File.ReadAllText("SelectedLanguage.txt") == "Français")
            {
                LANG_ = File.ReadAllText("FR.lang").Split('\n');
            }
            else if (File.ReadAllText("SelectedLanguage.txt") == "Română")
            {
                LANG_ = File.ReadAllText("RO.lang").Split('\n');
            }
            else if (File.ReadAllText("SelectedLanguage.txt") == "Polskie")
            {
                LANG_ = File.ReadAllText("PO.lang").Split('\n');
            }
            BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < 31; i++)
                {
                    string Match_ = Regex.Match(LANG_[i], @"(?<=<)(\w+)(?=>)").ToString();
                    string LANG_TEXT = Regex.Match(LANG_[i], @"(?<=>)(.+)(?=<)").ToString();
                    Control c_ = Controls.Find(Match_, true)[0];
                    c_.Text = LANG_TEXT;
                }
            }));

        }
    }
}
