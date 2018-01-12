using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_BackupCopy
{
    abstract class Storage
    {
        //protected string _name;
        //protected string _model;
        //protected string Name { get; set; } // TODO public
        //protected string Model { get; set; }    // TODO public
        public string Name { get; set; }
        public string Model { get; set; }


        public Storage(string name, string model)
        {
            Name = name;
            Model = model;
        }


        public abstract void GettingTheAmountOfMemory();    // TODO int !?
        public abstract void CopyingDataToTheDevice();
        public abstract void FreeMemoryOnTheDevice();   // TODO int !?
        public abstract void GettingFullInformationAboutTheDevice();

        public override string ToString()
        {
            return $" Name: {Name}\n Model: {Model}";
        }
    }


    class Flash : Storage
    {
        int _speed_USB_3;
        int _memory;

        public Flash(string name, string model) : base(name, model) {}
        public Flash(string name, string model, int speed) : base(name, model)
        {
            _speed_USB_3 = speed;
        }
        public Flash(string name, string model, int speed, int memory) : base(name, model)
        {

        }


        public override void GettingTheAmountOfMemory()
        {
            throw new NotImplementedException();
        }

        public override void CopyingDataToTheDevice()
        {
            throw new NotImplementedException();
        }

        public override void FreeMemoryOnTheDevice()
        {
            throw new NotImplementedException();
        }

        public override void GettingFullInformationAboutTheDevice()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + $" Speed: {_speed_USB_3}\n Memory: {_memory}";
        }
    }
}
