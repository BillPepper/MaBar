using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBar
{
    class Config
    {
        private int iconSize;
        private string[] programList;

        public Config(int iconSize, string[] programList)
        {
            this.iconSize = iconSize;
            this.programList = programList;
        }

        public int getIconSize()
        {
            return this.iconSize;
        }

        public void setIconSize(int size)
        {
            this.iconSize = size;
        }

        public string[] getProgramList()
        {
            return this.programList;
        }

        public void setProgramList(string[] list)
        {
            this.programList = list;
        }
    }

    
}
