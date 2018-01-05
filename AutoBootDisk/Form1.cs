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
namespace AutoBootDisk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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

            
            Process.Start("AutoBootDisk Updater.exe");
            for(int i=0; i<DriveInfo.GetDrives().Length; i++)
            {
                if(DriveInfo.GetDrives()[i].IsReady==true)
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
                if(comboBox1.Text=="ZorinOS")
                {
                    Link = new Uri("https://downloads.sourceforge.net/project/zorin-os/12/Zorin-OS-12.2-Core-64.iso?r=&ts=1514516210&use_mirror=superb-sea2");
                }
                if(comboBox1.Text=="Debian")
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
            
            label12.Text = Convert.ToInt64(e.BytesReceived) + " Bytes Of " + Convert.ToInt64(e.TotalBytesToReceive) + " Received";
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
            if(e==100)
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
                label21.Text = "A very popular Linux distrubution made for beginners. It is based on Debian Linux and uses the Gnome Desktop(Clean UI). It is made for personal computers. It is made for Medium to High end machines.";
            }
            else if (comboBox1.Text == "Kubuntu")
            {
                label21.Text = "A popular Linux distrubution based off of Ubuntu, features KDE and Plasma desktop. It is meant for Medium to High end machines.";
            }
            else if (comboBox1.Text == "Lubuntu")
            {
                label21.Text = "Short for 'Lightweight Ubuntu', it uses the LXDE desktop environment, and is made for low-medium end machines.";
            }
            else if (comboBox1.Text == "Xubuntu")
            {
                label21.Text = "Xubuntu uses the Xfce as the desktop environment, and is made for low-medium end machines.";
            }
            else if (comboBox1.Text == "UbuntuStudio")
            {
                label21.Text = "Ubuntu Studio is a distribution designed for general multimedia production. It is perfect for song artists, video editors, and other media authors. It uses the Xfce desktop. It is made for medium-high end machines";
            }
            else if (comboBox1.Text == "Zenwalk")
            {
                label21.Text = "Zenwalk uses the Gnome desktop environment, and is based on Slackware Linux. Zenwalk's goal is to be a lightweight linux distribution. It is made for low end machines.";
            }
            else if (comboBox1.Text == "Slax")
            {
                label21.Text = "Slax is a tiny operating system requiring only 256MB of storage. It's motto is 'Your Pocket Operating System'. It is only built as a Live USB, so it is not possible to use it as a computer desktop environment. It is made for low end machines";
            }
            else if (comboBox1.Text == "SliTaz")
            {
                label21.Text = "SliTaz is one of the most tiny operating systems possible. It is 46MB in size and uses the OpenBox Window Manager. It is made for low end machines.";
            }
            else if (comboBox1.Text == "MEPIS")
            {
                label21.Text = "MEPIS uses the KDE Plasma Desktop Environment, and is made as an alternative to Mandriva, SUSE Linux, and Red Hat Linux. It is made for medium-high end machines";
            }
            else if (comboBox1.Text == "FrugalwareLinux")
            {
                label21.Text = "Frugalware Linux is made for intermediate users which know how to use the command line. Frugalware Linux uses the KDE Desktop Environment. It is made for medium-high end machines";
            }
            else if (comboBox1.Text == "LinuxConsole")
            {
                label21.Text = "Linux Console is made for children and uses the MATE Desktop. It is made for low-medium end machines.";
            }
            else if (comboBox1.Text == "xPUD")
            {
                label21.Text = "xPUD is a light LiveCD, which uses the LXDE Desktop. It is made for low end machines.";
            }
            else if (comboBox1.Text == "Mageia")
            {
                label21.Text = "Mageia uses the KDE Plasma desktop environment with reasonable security. It is made for medium-high end machines.";
            }
            else if (comboBox1.Text == "SparkyLinux")
            {
                label21.Text = "Sparky Linux is a Desktop-Oriented Debian-based operating system. It uses the LXQT desktop and is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "GentooLinux")
            {
                label21.Text = "Gentoo Linux is mostly credited for it's Portage Package Management System, and uses the Xfce Desktop Environment and is made for low-medium end computers.";
            }
            else if (comboBox1.Text == "Edubuntu")
            {
                label21.Text = "Short for 'Educational Ubuntu', Edubuntu is made to be used in school and institutions. It uses the GNOME Desktop Environment, and is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "PCLinuxOS")
            {
                label21.Text = "PCLinuxOS is made for personal computers and uses the KDE Plasma Desktop Environment. It is made to mimic Windows desktop environment, and is made for medium-high end computers";
            }
            else if (comboBox1.Text == "LinuxLite")
            {
                label21.Text = "Linux Lite is made to introduce Windows users to Linux, and uses the Xfce Desktop. It is designed for low-medium end computers";
            }
            else if (comboBox1.Text == "ElementaryOS")
            {
                label21.Text = "Elementary OS is a very elegant operating system, and is the flagship of the Pantheon Desktop Environment, and is made for medium-high end devices";
            }
            else if (comboBox1.Text == "openSUSE")
            {
                label21.Text = "openSUSE is the best option for Softare Developers and System Administrators. It uses the GNOME Desktop Environment, and is made for medium-high end machines.";
            }
            else if (comboBox1.Text == "ArchLinux")
            {
                label21.Text = "Arch Linux is made for minimalism, simplicity, and elegance. It uses the CLI User Interface, and is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "Fedora")
            {
                label21.Text = "Fedora is a desktop-oriented operating system featuring the GNOME desktop. It is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "UbuntuMATE")
            {
                label21.Text = "Ubuntu with the MATE desktop environment. Made for medium-high end computers.";
            }
            else if (comboBox1.Text == "BodhiLinux")
            {
                label21.Text = "Bodhi linux is a lightweight linux distribution using the Moksha desktop environment.";
            }
            else if (comboBox1.Text == "MandrivaLinux")
            {
                label21.Text = "Mandriva Linux uses the KDE Plasma Desktop and uses the RPM Package Manager. It is a fuse between Mandrake Linux and Conectiva Linux. It is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "CrunchBang")
            {
                label21.Text = "CrunchBang Linux (Abbreviated simply #!), and uses the Openbox Desktop Environment. It is discontinued, but is still available for download as BunsenLabs. it is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "Peppermint")
            {
                label21.Text = "Peppermint is a cloud-focused OS based on Lubuntu. It uses the LXDE Desktop Environment and is made for low-medium end computers.";
            }
            else if (comboBox1.Text == "BlackArchLinux")
            {
                label21.Text = "Arch Linux with a Security-Oriented twist. It is made for Pentesters and Cyberforensics. It uses the FluxBox UI and is made for medium-high end computers. [WARNING : USES UP TO 8GB OF STORAGE]";
            }
            else if (comboBox1.Text == "BackBox")
            {
                label21.Text = "Backbox is a pentesting OS using the XFCE Desktop Environment. It is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "Tails")
            {
                label21.Text = "Tails is a Linux distrubition oriented toward personal security. In fact, this is probably the most secure you can get. Every single connection uses the TOR Relay and all non-anonymous connections are blocked. Tails OS self destructs and leaves no fingerprint unless explicitly told to do so. The Desktop Environment is GNOME and is made for medium-high end machines.";
            }
            else if (comboBox1.Text == "KaliLinux")
            {
                label21.Text = "Kali Linux is a the most popular pentesting linux distribution using the GNOME Desktop. Made for medium-high end computers.";
            }
            else if (comboBox1.Text == "SabayonLinux")
            {
                label21.Text = "Sabayon Linux is an Italian Gentoo-based linux distribution using the GNOME Desktop. It is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "PinguyOS")
            {
                label21.Text = "Pinguy OS includes many pre-installed software and uses the GNOME Desktop Environment. It is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "AlpineLinux")
            {
                label21.Text = "Alpine Linux is a resource efficient, secure, simple operating system. It is made for advanced users who do not require a Graphical User Interface, as this uses Command Line as it's default interface. It is made for low-medium end computers.";
            }
            else if (comboBox1.Text == "VoidLinux")
            {
                label21.Text = "Void Linux is an OS using the XBPS Package Manager and Cinnamon as it's default desktop environment. It has a quick boot time and is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "NixOS")
            {
                label21.Text = "Nix OS uses the KDE Plasma Desktop Environment. It is made for medium-high end computers";
            }
            else if (comboBox1.Text == "TinHatLinux")
            {
                label21.Text = "Tin Hat Linux is made to prevent the government from spying on you. It only exists in RAM, so everything is wiped after shutdown. It is made to be extremely secure, stable, and fast. It uses the GNOME GUI, and is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "CentOS")
            {
                label21.Text = "CentOS is Red Hat Enterprise Linux for free. It uses both GNOME and KDE Plasma, so you can choose what environment you wish to run. Recommended for medium-high end computers";
            }
            else if (comboBox1.Text == "PuppyLinux")
            {
                label21.Text = "Puppy Linux is one of the most popular lightweight linux distributions.";
            }
            else if (comboBox1.Text == "ZorinOS")
            {
                label21.Text = "Zorin OS Core is a modernized, elegant OS made for people arriving from Windows or Macintosh. This may be the best beginner Linux Distribution ever, and uses the Zorin Desktop as its default interface. This is made for medium-high end computers.";
            }
            else if (comboBox1.Text == "FreeBSD")
            {
                label21.Text = "FreeBSD isn't even a linux operating system. It is completely original, and has a Command Line Interface. It is recommended for low-medium end computers.";
            }

            if (comboBox1.Text == "KaOS")
            {
                label21.Text = "KaOS is a standard KDE distribution. It is recommended for medium-high end computers.";
            }
            else if (comboBox1.Text == "SteamOS")
            {
                label21.Text = "SteamOS is made by Valve Inc. and is a custom operating system built to handle the steam launcher and all of its games. It uses the Steam Desktop Environment and is recommended for medium-high end computers.";
            }
            else if (comboBox1.Text == "ManjaroLinux")
            {
                label21.Text = "Manjaro Linux is a Arch-Linux based Linux OS focused on user-friendliness. It uses KDE and is recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "KasperskyRescueDisk")
            {
                label21.Text = "Kaspersky Rescue Disk is a crucial utility for people who may have ransomware that prevents you from booting. We recommend you always have a rescue disk with you at all times just in case.";
            }
            else if (comboBox1.Text == "OPHcrack")
            {
                label21.Text = "OPHcrack is a Windows password cracker that you can boot from USB. It uses the rainbow table algorithm, and is useful if you forgot your password and you cannot access your account. Please consider a different solution, such as saving all your data from Ubuntu, because OPHcrack will look suspicious on your browsing history.";
            }
            else if (comboBox1.Text == "DrWebLiveDisk")
            {
                label21.Text = "The Dr. Web Live Disk will allow you not only to remove malware that makes your computer non-bootable, but also allows you to recover data as well.";
            }
            else if (comboBox1.Text == "Parsix")
            {
                label21.Text = "Parsix is a Debian based OS using the GNOME desktop. The project is now discontinued. It is recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "ArchLabs")
            {
                label21.Text = "ArchLabs is a lightweight rolling Linux version using the Openbox window manager. Recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "EndlessOS")
            {
                label21.Text = "The EndlessOS project is optimized for areas without internet. It has an entire encyclopedia, calculator, dictionary, thesaurus, and other applications you can access without internet. This distrubution uses EOS Shell, and needs a medium-high end machine.";
            }
            else if (comboBox1.Text == "Solus")
            {
                label21.Text = "Solus is an OS that has no defined End Of Life, so if you install it, it will update indefinently. It uses the GNOME Desktop Environment and is recommended for medium-high end computers.";
            }
            else if (comboBox1.Text == "Deepin")
            {
                label21.Text = "Deepin is a chinese Linux distribution based on Debian. They are focused on a user-friendly UI, and is the most popular chinese Linux distribution according to Distrowatch. It uses the Deepin Desktop Environment, and is recommended for a medium-high end machine";
            }
            else if (comboBox1.Text == "MXLinux")
            {
                label21.Text = "MX Linux is a midweight Linux Distribution based on Debian with antiX components. It uses Xfce Desktop Environment, and is recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "KDEneon")
            {
                label21.Text = "KDE Neon is Ubuntu with the latest KDE packages. KDE Neon runs on the KDE Desktop Environment and is recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "ParrotSecurityOS")
            {
                label21.Text = "Parrot Security OS is one of the best Linux Distributions for System Administrators. It is based off of Debian and uses the MATE Desktop Environment, and is focused on vulnerabilities and security. It is recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "LXLE")
            {
                label21.Text = "LXLE is based off of the latest Ubuntu LTS release, and is made to be lightweight. It focuses on making beautiful visual aesthetics that work on both old and new hardware. It uses LXDE as its Desktop Environment, and is recommended for low end machines.";
            }
            else if (comboBox1.Text == "Android-x86")
            {
                label21.Text = "This remarkable operating system has a goal of porting android OS to computers. Because it is basically Android on PC, it does not need any high end hardware, so you should be able to use it just fine on a low end computer.";
            }
            else if (comboBox1.Text == "ferenOS")
            {
                label21.Text = "ferenOS is based on Linux Mint and uses the Cinnamon Desktop Environment. It is recommended to be used on medium-high end machines.";
            }
            else if (comboBox1.Text == "BlackLabLinux")
            {
                label21.Text = "Black Lab does not mean 'Black Laboratory'. It means 'Black Labrador'. It uses the MATE Desktop Environment and is most noted for its support of browser plugins and packages for multimedia production. It is recommended to be used on a medium-high end computer";
            }
            else if (comboBox1.Text == "TinyCoreLinux")
            {
                label21.Text = "Tiny Core Linux is a cute 12MB linux distribution with a Command Line Interface. It is recommended for low end machines.";
            }
            else if (comboBox1.Text == "4MLinux")
            {
                Link = new Uri("4M Linux is a distribution meant for recovery, multimedia, and miniservers. It uses the JWM desktop and is recommended for low end machines.");
            }
            else if (comboBox1.Text == "BluestarLinux")
            {
                label21.Text = "Bluestar Linux is based off of Arch Linux and features the KDE Plasma desktop. It is recommended for medium-high end machines.";
            }
            else if (comboBox1.Text == "QubesOS")
            {
                label21.Text = "Qubes OS is a security oriented operating system using 'Security by isolation' as their main focus. It is based on Fedora and uses the Xfce desktop environment. It is recommended for low-medium end machines.";
            }
            else if (comboBox1.Text == "Netrunner")
            {
                label21.Text = "Netrunner is a debian based linux distribution with a highly customizable KDE desktop environment.";
            }
            else if (comboBox1.Text == "ROSA")
            {
                label21.Text = "ROSA is a Russian Linux distribution using the KDE Plasma Desktop Environment. Recommended for medium-high end computers.";
            }
            else if (comboBox1.Text == "ExTiX")
            {
                label21.Text = "ExTiX is a Linux Distribution featuring KDE Plasma as the Desktop Environment. Recommended for medium-high end computers.";
            }
            else if (comboBox1.Text == "ClearOS")
            {
                label21.Text = "ClearOS is a Server distribution, which means that it should only be used on a high end computer. I still don't know the desktop environment its either GNOME or KDE";
            }
            else if (comboBox1.Text == "RedcoreLinux")
            {
                label21.Text = "Redcore Linux is made to bring the power of Gentoo Linux to the masses. It operates under LXQt Desktop Environment, so it is recommended for low-medium end computers";
            }
            else if (comboBox1.Text == "RevengeOS")
            {
                label21.Text = "Revenge OS is based under Arch Linux and uses the LXQt Desktop Environment, and is recommended for low-medium end computers.";
            }
            else if (comboBox1.Text == "ClonezillaLive")
            {
                label21.Text = "Clonezilla is a disk cloner and data recoverer. It is a utility.";
            }
            else if (comboBox1.Text == "ChakraLinux")
            {
                label21.Text = "Chakra Linux is based on Arch Linux and focuses on KDE Software. It uses KDE Plasma Desktop, so it is recommended for a medium-high end computer.";
            }
            else if (comboBox1.Text == "GeckoLinux")
            {
                label21.Text = "GeckoLinux is a linux distribution based off of openSUSE and features out-of-the-box usability. It uses the GNOME desktop, so it is best for a medium-high end computer.";
            }
            else if (comboBox1.Text == "NuTyX")
            {
                label21.Text = "NuTyX is a French Linux Distribution.";
            }
            else if (comboBox1.Text == "SharkLinux")
            {
                label21.Text = "SharkLinux is a Ubuntu-based Linux distribution that automatically installs updates and security patches.";
            }
            else if (comboBox1.Text == "VectorLinux")
            {
                label21.Text = "Vector Linux is a small distribution that is recommended for low-medium end computers";
            }
            else if (comboBox1.Text == "ScientificLinux")
            {
                label21.Text = "Red Hat Enterprise Linux recoded to be free and built for science!";
            }
            else if (comboBox1.Text == "TrisquelLinux")
            {
                label21.Text = "100% built on Ubuntu. It is made for various audiences such as office and home users. Recommended for low end machines.";
            }
            else if (comboBox1.Text == "AbsoluteLinux")
            {
                label21.Text = "Very Lightweight repackage of Slackware Linux. Uses IceWM Desktop Environment. Recommended for low end machines.";
            }
            if (comboBox1.Text == "MintCinnamon")
            {
                label21.Text = "Linux Mint is an Ubuntu-based distribution focused on a more out-of-the-box experience. Features Cinnamon Desktop Environment. Recommended for medium-high end machines.";
            }
            if (comboBox1.Text == "MintKDE")
            {
                label21.Text = "Linux Mint is an Ubuntu-based distribution focused on a more out-of-the-box experience. Features KDE Plasma Desktop Environment. Recommended for medium-high end machines.";
            }
            if (comboBox1.Text == "MintMATE")
            {
                label21.Text = "Linux Mint is an Ubuntu-based distribution focused on a more out-of-the-box experience. Features MATE Desktop Environment. Recommended for medium-high end machines.";
            }
            if (comboBox1.Text == "MintXfce")
            {
                label21.Text = "Linux Mint is an Ubuntu-based distribution focused on a more out-of-the-box experience. Features Xfce Desktop Environment. Recommended for medium-high end machines.";
            }
            if (comboBox1.Text == "Debian")
            {
                label21.Text = "Suspected to be one of the most popular operating systems, Debian is practically the seed for most Linux Distritutions in the market. It features GNOME desktop environment and is recommended for medium-high end machines.";
            }
        }
    }
}
