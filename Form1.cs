﻿using System;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PGen
{
    public partial class PGen : Form
    {
        public PGen() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e)
        {
            ContextMenu textbox = new ContextMenu();
            MenuItem copy = new MenuItem("&Copy", new EventHandler(Clip));
            MenuItem gen = new MenuItem("Generate &new password", GenerateNew);
            textbox.MenuItems.Add(copy);
            textbox.MenuItems.Add(gen);
            textBox1.ContextMenu = textbox;
        }
        private void Clip(object sender, EventArgs e) { Clipboard.SetText(textBox1.Text); }
        Random Random = new Random(RNG(Lenght));
        static int Lenght = 64;

        #region Charset

        private const string LoCase = "abcdefghijklmnopqrstuvwxyz";
        private const string UpCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numbers = "0123456789";
        private const string Symbols = "!\"#$%'()*+,-./:;<=>?@[\\]^_`~";
        private string[] AmbChars = { "l", "I", "O", "0", "1" };
        private const string RomanNum = "\u2160\u2161\u2162\u2163\u2164\u2165\u2166\u2167\u2168\u2169\u216A\u216B\u216C\u216D\u216E\u216F\u2170\u2171\u2172\u2173\u2174\u2175\u2176\u2177\u2178\u2179\u217A\u217B\u217C\u217D\u217E\u217F\u2180\u2181\u2182\u2183\u2185\u2186\u2187\u2188";
        private const string UniSym = "\u00a1\u00a2\u00a3\u00a4\u00a5\u00a6\u00a7\u00a8\u00a9\u00aa\u00AB\u00AC\u00AD\u00AE\u00AF\u00B0\u00B1\u00B2\u00B3\u00B4\u00B5\u00B6\u00B7\u00B8\u00B9\u00BA\u00BB\u00BC\u00BD\u00BE\u00BF\u00C0\u00C1\u00C2\u00C3\u00C4\u00C5\u00C6\u00C7\u00C8\u00C9\u00CA\u00CB\u00CC\u00CD\u00CE\u00CF\u00D0\u00D1\u00D2\u00D3\u00D4\u00D5\u00D6\u00D7\u00D8\u00D9\u00DA\u00DB\u00DC\u00DD\u00DE\u00DF\u00E0\u00E1\u00E2\u00E3\u00E4\u00E5\u00E6\u00E7\u00E8\u00E9\u00EA\u00EB\u00EC\u00ED\u00EE\u00EF\u00F0\u00F1\u00F2\u00F3\u00F4\u00F5\u00F6\u00F7\u00F8\u00F9\u00FA\u00FB\u00FC\u00FD\u00FE\u00FF\u00FF\u0100\u0101\u0102\u0103\u0104\u0105\u0106\u0107\u0108\u0109\u010A\u010B\u010C\u010D\u010E\u010F\u0110\u0111\u0112\u0113\u0114\u0115\u0116\u0117\u0118\u0119\u011A\u011B\u011C\u011D\u011E\u011F\u0120\u0121\u0122\u0123\u0124\u0125\u0126\u0127\u0128\u0129\u012A\u012B\u012C\u012D\u012E\u012F\u0130\u0131\u0132\u0133\u0134\u0135\u0136\u0137\u0138\u0139\u013A\u013B\u013C\u013D\u013E\u013F\u0140\u0141\u0142\u0143\u0144\u0145\u0146\u0147\u0148\u0149\u014A\u014B\u014C\u014D\u014E\u014F\u0150\u0151\u0152\u0153\u0154\u0155\u0156\u0157\u0158\u0159\u015A\u015B\u015C\u015D\u015E\u015F\u0160\u0161\u0162\u0163\u0164\u0165\u0166\u0167\u0168\u0169\u016A\u016B\u016C\u016D\u016E\u016F\u0170\u0171\u0172\u0173\u0174\u0175\u0176\u0177\u0178\u0179\u017A\u017B\u017C\u017D\u017E\u017F\u01DD\u01DE\u01DF\u01E0\u01E1\u01E2\u01E3\u01E4\u01E5\u01E6\u01E7\u01E8\u01E9\u01EA\u01EB\u01EC\u01ED\u01EE\u01EF\u01F0\u01F1\u01F2\u01F3\u01F4\u01F5\u01F6\u01F7\u01F8\u01F9\u01FA\u01FB\u01FC\u01FD\u01FE\u01FF\u0200\u0201\u0202\u0203\u0204\u0205\u0206\u0207\u0208\u0209\u020A\u020B\u020C\u020D\u020E\u020F\u0210\u0211\u0212\u0213\u0214\u0215\u0216\u0217\u0218\u0219\u021A\u021B\u021C\u021D\u021E\u021F\u0220\u0221\u0222\u0223\u0224\u0225\u0226\u0227\u0228\u0229\u022A\u022B\u022C\u022D\u022E\u022F\u0230\u0231\u0232\u0233\u0234\u0235\u0236\u0237\u0238\u0239\u023A\u023B\u023C\u023D\u023E\u023F\u0240\u0241\u0242\u0243\u0244\u0245\u0246\u0247\u0248\u0249\u024A\u024B\u024C\u024D\u024E\u024F\u0250\u0251\u0252\u0253\u0254\u0255\u0256\u0257\u0258\u0259\u025A\u025B\u025C\u025D\u025E\u025F\u0260\u0261\u0262\u0263\u0264\u0265\u0266\u0267\u0268\u0269\u026A\u026B\u026C\u026D\u026E\u026F\u0270\u0271\u0272\u0273\u0274\u0275\u0276\u0277\u0278\u0279\u027A\u027B\u027C\u027D\u027E\u027F\u0280\u0281\u0282\u0283\u0284\u0285\u0286\u0287\u0288\u0289\u028A\u028B\u028C\u028D\u028E\u028F\u0290\u0291\u0292\u0293\u0294\u0295\u0296\u0297\u0298\u0299\u029A\u029B\u029C\u029D\u029E\u029F\u02A0\u02A1\u02A2\u02A3\u02A4\u02A5\u02A6\u02A7\u02A8\u02A9\u02AA\u02AB\u02AC\u02AD\u02AE\u02AF\u02B0\u02B1\u02B2\u02B3\u02B4\u02B5\u02B6\u02B7\u02B8\u0400\u0401\u0402\u0403\u0404\u0405\u0406\u0407\u0408\u0409\u040A\u040B\u040C\u040D\u040E\u040FBR\u0410\u0411\u0412\u0413\u0414\u0415\u0416\u0417\u0418\u0419\u041A\u041B\u041C\u041D\u041E\u041F\u0420\u0421\u0422\u0423\u0424\u0425\u0426\u0427\u0428\u0429\u042A\u042B\u042C\u042D\u042E\u042F\u0430\u0431\u0432\u0433\u0434\u0435\u0436\u0437\u0438\u0439\u043A\u043B\u043C\u043D\u043E\u043F\u0440\u0441\u0442\u0443\u0444\u0445\u0446\u0447\u0448\u0449\u044A\u044B\u044C\u044D\u044E\u044FC\u0450\u0451\u0452\u0453\u0454\u0455\u0456\u0457\u0458\u0459\u045A\u045B\u045C\u045D\u045E\u045FH\u0460\u0461\u0462\u0463\u0464\u0465\u0466\u0467\u0468\u0469\u046A\u046B\u046C\u046D\u046E\u046F\u0470\u0471\u0472\u0473\u0474\u0475\u0476\u0477H\u0478\u0479H\u047A\u047B\u047C\u047D\u047E\u047F\u0480\u0481H\u0482\u0483\u0484\u0485\u0486\u0487\u0488\u0489EC\u048A\u048B\u048C\u048D\u048E\u048F\u0490\u0491\u0492\u0493\u0494\u0495\u0496\u0497\u0498\u0499\u049A\u049B\u049C\u049D\u049E\u049F\u04A0\u04A1\u04A2\u04A3\u04A4\u04A5\u04A6\u04A7\u04A8\u04A9\u04AA\u04AB\u04AC\u04AD\u04AE\u04AF\u04B0\u04B1\u04B2\u04B3\u04B4\u04B5\u04B6\u04B7\u04B8\u04B9\u04BA\u04BB\u04BC\u04BD\u04BE\u04BF\u04C0\u04C1\u04C2\u04C3\u04C4\u04C5\u04C6\u04C7\u04C8\u04C9\u04CA\u04CB\u04CC\u04CD\u04CE\u04CF\u04D0\u04D1\u04D2\u04D3\u04D4\u04D5\u04D6\u04D7\u04D8\u04D9\u04DA\u04DB\u04DC\u04DD\u04DE\u04DF\u04E0\u04E1\u04E2\u04E3\u04E4\u04E5\u04E6\u04E7\u04E8\u04E9\u04EA\u04EB\u04EC\u04ED\u04EE\u04EF\u04F0\u04F1\u04F2\u04F3\u04F4\u04F5\u04F6\u04F7\u04F8\u04F9AN\u04FA\u04FB\u04FC\u04FD\u04FE\u04FF\u0500\u0501\u0502\u0503\u0504\u0505\u0506\u0507\u0508\u0509\u050A\u050B\u050C\u050D\u050E\u050F\u0510\u0511\u0512\u0513\u0514\u0515\u0516\u0517\u0518\u0519\u051A\u051B\u051C\u051D\u051E\u051F\u0520\u0521\u0522\u0523\u0524\u0525\u0526\u0527\u0528\u0529\u052A\u052B\u052C\u052D\u052E\u052F\u0531\u0532\u0533\u0534\u0535\u0536\u0537\u0538\u0539\u053A\u053B\u053C\u053D\u053E\u053F\u0540\u0541\u0542\u0543\u0544\u0545\u0546\u0547\u0548\u0549\u054A\u054B\u054C\u054D\u054E\u054F\u0550\u0551\u0552\u0553\u0554\u0555\u0556\u0557\u0558\u0559\u055A\u055B\u055C\u055D\u055E\u055F\u0560\u0561\u0562\u0563\u0564\u0565\u0566\u0567\u0568\u0569\u056A\u056B\u056C\u056D\u056E\u056F\u0570\u0571\u0572\u0573\u0574\u0575\u0576\u0577\u0578\u0579\u057A\u057B\u057C\u057D\u057E\u057F\u0580\u0581\u0582\u0583\u0584\u0585\u0586\u0587\u0588\u0589\u058A\u058B\u058C\u058D\u058E\u058F";
//      Emoji

        #endregion

        private bool a, b, c, d, f, g, h;

        private void Generate(int Lenght, bool LCase, bool UCase, bool Num, bool Sym, bool Amb, bool Rom, bool Uni)
        {
            if (!LCase && !UCase && !Num && !Sym && !Rom && !Uni) { System.Media.SystemSounds.Asterisk.Play(); /* add alert */ }
            else
            {
                string aChars = "", password = "";
                char[] pswd = new char[Lenght];
                if (LCase) aChars += LoCase; if (UCase) aChars += UpCase; if (Num) aChars += Numbers; if (Sym) aChars += Symbols; if (Rom) aChars += RomanNum; if (Uni) aChars += UniSym;
                if (Amb) { foreach (string i in AmbChars) { aChars = aChars.Replace(i, string.Empty); } }
                if (aChars.Length != 0)
                {
                    for (int i = 0; i < Lenght; i++) { pswd[i] = aChars[Random.Next(0, aChars.Length)]; }
                    password = new string(pswd);
                }
                textBox1.Text = password;
            }
        }
        private static int RNG(int Lenght) { using (RNGCryptoServiceProvider Random = new RNGCryptoServiceProvider()) { byte[] Se = new byte[Lenght]; Random.GetBytes(Se); int Seed = BitConverter.ToInt32(Se, 0); return Seed; }}
        private void GenerateNew(object sender, EventArgs e) { Generate(Lenght, a, b, c, d, f, g, h); }

        #region UI
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { if (checkBox1.CheckState == CheckState.Checked) a = true; else a = false; }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { if (checkBox2.CheckState == CheckState.Checked) b = true; else b = false; }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { if (checkBox3.CheckState == CheckState.Checked) c = true; else c = false; }
        private void checkBox4_CheckedChanged(object sender, EventArgs e) { if (checkBox4.CheckState == CheckState.Checked) d = true; else d = false; }
        private void checkBox5_CheckedChanged(object sender, EventArgs e) { if (checkBox5.CheckState == CheckState.Checked) f = true; else f = false; }
        private void checkBox6_CheckedChanged(object sender, EventArgs e) { if (checkBox6.CheckState == CheckState.Checked) g = true; else g = false; }
        private void checkBox7_CheckedChanged(object sender, EventArgs e) { if (checkBox7.CheckState == CheckState.Checked) h = true; else h = false; }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { Lenght = Convert.ToInt32(numericUpDown1.Value); }

        #endregion
    }
}
