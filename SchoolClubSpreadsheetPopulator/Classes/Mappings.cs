using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubSpreadsheetPopulator.Classes
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class mappings
    {

        private mappingsTemplatemaster templatemasterField;

        /// <remarks/>
        public mappingsTemplatemaster templatemaster
        {
            get
            {
                return this.templatemasterField;
            }
            set
            {
                this.templatemasterField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class mappingsTemplatemaster
    {

        private mappingsTemplatemasterSpreadsheet[] spreadsheetsField;

        private byte firstDataRowIdField;

        private string countryColumnIdField;

        private string schoolColumnIdField;

        private string yearGroupColumnIdField;

        private string endMonthColumnIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("spreadsheet", IsNullable = false)]
        public mappingsTemplatemasterSpreadsheet[] spreadsheets
        {
            get
            {
                return this.spreadsheetsField;
            }
            set
            {
                this.spreadsheetsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte firstDataRowId
        {
            get
            {
                return this.firstDataRowIdField;
            }
            set
            {
                this.firstDataRowIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string countryColumnId
        {
            get
            {
                return this.countryColumnIdField;
            }
            set
            {
                this.countryColumnIdField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string endMonthColumnId
        {
            get
            {
                return this.endMonthColumnIdField;
            }
            set
            {
                this.endMonthColumnIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schoolColumnId
        {
            get
            {
                return this.schoolColumnIdField;
            }
            set
            {
                this.schoolColumnIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string yearGroupColumnId
        {
            get
            {
                return this.yearGroupColumnIdField;
            }
            set
            {
                this.yearGroupColumnIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class mappingsTemplatemasterSpreadsheet
    {

        private mappingsTemplatemasterSpreadsheetCountry[] countriesField;

        private mappingsTemplatemasterSpreadsheetYeargroup[] yeargroupsField;

        private mappingsTemplatemasterSpreadsheetMapping[] columnMappingsField;

        private string templatenameField;

        private string targetNameField;

        private string targetFirstRowIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("country", IsNullable = false)]
        public mappingsTemplatemasterSpreadsheetCountry[] countries
        {
            get
            {
                return this.countriesField;
            }
            set
            {
                this.countriesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("yeargroup", IsNullable = false)]
        public mappingsTemplatemasterSpreadsheetYeargroup[] yeargroups
        {
            get
            {
                return this.yeargroupsField;
            }
            set
            {
                this.yeargroupsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("mapping", IsNullable = false)]
        public mappingsTemplatemasterSpreadsheetMapping[] columnMappings
        {
            get
            {
                return this.columnMappingsField;
            }
            set
            {
                this.columnMappingsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string templatename
        {
            get
            {
                return this.templatenameField;
            }
            set
            {
                this.templatenameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string targetName
        {
            get
            {
                return this.targetNameField;
            }
            set
            {
                this.targetNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string targetFirstRowId
        {
            get
            {
                return this.targetFirstRowIdField;
            }
            set
            {
                this.targetFirstRowIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class mappingsTemplatemasterSpreadsheetCountry
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class mappingsTemplatemasterSpreadsheetYeargroup
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class mappingsTemplatemasterSpreadsheetMapping
    {

        private string sourceColumnIdField;

        private string targetColumnIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sourceColumnId
        {
            get
            {
                return this.sourceColumnIdField;
            }
            set
            {
                this.sourceColumnIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string targetColumnId
        {
            get
            {
                return this.targetColumnIdField;
            }
            set
            {
                this.targetColumnIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
