using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR12.Classes
{
    internal class PageChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static int cointitems = 10;
        static int countbutton = 2;
        public int[] NPage { get; set; } = new int[cointitems];
        public string[] Visible { get; set; } = new string[cointitems];
        public string[] Bold { get; set; } = new string[cointitems];
        public string[] Button { get; set; } = new string[cointitems];
        int countpages;
        public int CountPages
        {
            get => countpages;
            set
            {
                countpages = value;
                for (int i = 0; i < countpages; i++)
                {
                    if (CountPages <= i)
                    {
                        Visible[i] = "Hidden";
                    }
                    else
                    {
                        Visible[i] = "Visible";
                    }
                }
            }
        }

        int countpage;
        public int CountPage
        {
            get => countpage;
            set
            {
                countpage = value;
                if(Countlist % value == 0)
                {
                    CountPages = Countlist / value;
                }
                else
                {
                    CountPages = Countlist / value + 1;
                }
            }
        }

        int countlist;
        public int Countlist
        {
            get => countlist;
            set
            {
                countlist = value;
                if(value % CountPage == 0)
                {
                    CountPages = value / CountPage;

                }
                else
                {
                    CountPages = 1 + value / CountPage;
                }
            }
        }

        int currentpage;
        public int Currentpage
        {
            get => currentpage;
            set
            {
                currentpage = value;
                if (currentpage <1)
                {
                    currentpage = 1;
                }
                if(currentpage >=CountPages)
                {
                    currentpage = CountPages;
                }
                for(int i = 0; i < cointitems; i++)
                {
                    if (currentpage < (1 + cointitems / 2) || CountPages < cointitems) NPage[i] = i + 1;
                    else if (currentpage > CountPages - (cointitems / 2 + 1)) NPage[i] = CountPages - (cointitems - 1) + i;
                    else NPage[i] = currentpage + i - (cointitems / 2);
                }
                for (int i = 0; i < cointitems; i++)
                {
                    if (NPage[i] == currentpage) Bold[i] = "ExtrsBold";
                    else Bold[i] = "Regular";
                }
                if (cointitems > 10)
                {
                    if (NPage[0]!= 1)
                    {
                        Button[0] = "Visible";
                    }
                    else
                    {
                        Button[0] = "Hidden";
                    }
                    if (NPage[9] != countpages)
                    {
                        Button[1] = "Visible";
                    }
                    else
                    {
                        Button[1] = "Hidden";
                    }
                }
                else
                {
                    Button[0] = "Hidden";
                    Button[1] = "Hidden";
                }
                PropertyChanged(this, new PropertyChangedEventArgs("NPage"));
                PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bold"));
                PropertyChanged(this, new PropertyChangedEventArgs("Button"));
            }
        }

        public PageChange()
        {
            for(int i = 0; i < cointitems; i++)
            {
                if(i == 0)
                {
                    Visible[i] = "Visible";
                    Bold[i] = "ExtraBold";
                }
                else
                {
                    Visible[i] = "Hidden";
                    Bold[i] = "Regular";
                }
                NPage[i] = i + 1;
            }
            currentpage = 1;
            countlist = 1;
        }

    }
}
