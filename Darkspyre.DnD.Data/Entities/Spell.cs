using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public partial class Spell : BaseEntity, ISource, IName
    {

        private string nameField;

        private byte levelField;

        private string schoolField;

        private bool ritualField;

        private string timeField;

        private string rangeField;

        private string componentsField;

        private string durationField;

        private string classesField;

        private string textField;

        private string rollField;
        
        /// <remarks/>
        /// 
        public string FormId { get; set; }
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte Level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }

        /// <remarks/>
        public string School
        {
            get
            {
                return this.schoolField;
            }
            set
            {
                this.schoolField = value;
            }
        }

        /// <remarks/>
        public bool Ritual
        {
            get
            {
                return this.ritualField;
            }
            set
            {
                this.ritualField = value;
            }
        }

        /// <remarks/>
        public string Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        public string Range
        {
            get
            {
                return this.rangeField;
            }
            set
            {
                this.rangeField = value;
            }
        }

        /// <remarks/>
        public string Components
        {
            get
            {
                return this.componentsField;
            }
            set
            {
                this.componentsField = value;
            }
        }

        /// <remarks/>
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        public string Classes
        {
            get
            {
                return this.classesField;
            }
            set
            {
                this.classesField = value;
            }
        }

        /// <remarks/>
        
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>        
        public string Roll
        {
            get
            {
                return this.rollField;
            }
            set
            {
                this.rollField = value;
            }
        }

        public string AreaOfEffect { get; set; }
        public bool Locked { get; set; }
        public int MAC { get; set; }
        public int PSPCost { get; set; }
        public int PSPFail { get; set; }
        public string Save { get; set; }
        public string Sphere { get; set; }
        public string ShortDescription { get; set; }
        public string SpellType { get; set; }
        public string SpellResistance { get; set; }
    
        public string Source { get; set; }
        public string SourceBook { get; set; }
        public string SourceBookAbr { get; set; }
        public DateTime ImportDate { get; set; }
        public string ImportSource { get; set; }
    }      
}
