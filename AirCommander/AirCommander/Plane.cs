using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCommander
{
    internal class Plane
    {
        private List<String> body;
        private bool aliveStatus;

        public Plane() { 
            body = new List<String>();
            aliveStatus = true;
        }

        public void deleteBody()
        {
            this.body.Clear();
        }

        public int getBodyLength()
        {
            return this.body.Count;
        }

        public String getBodyPart(int j)
        {
            return this.body.ElementAt(j);
        }

        public bool checkForBodyPart(String part)
        {
            if (this.body.Contains(part)) return true;
            else return false;
        }

        public void setBodyPart(String str)
        {
            this.body.Add(str);
        }

        public bool getStatus()
        {
            return this.aliveStatus;
        }

        public void setStatusDead()
        {
            this.aliveStatus = false;
        }
    }
}
