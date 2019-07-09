using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace IPInformer2
{
    public class FormWorker
    {
        private object DataObject = null;
        private object DataForm = null;
        private Type ObjectType = null;

        private List<RadioButton> RadioButtons = null;
        //private Type FormType = null;

        public string ErrorMessage { get; private set; }

        public FormWorker(object dataobject, object dataform)
        {
            DataObject = dataobject;
            DataForm = dataform;

            ObjectType = dataobject.GetType();
            //FormType = dataform.GetType();

            Form form = (Form)DataForm;
            RadioButtons = FindAllRadiobuttons(form.Controls);                        
        }

        private List<RadioButton> FindAllRadiobuttons(Control.ControlCollection collection)
        {
            List <RadioButton> result = new List<RadioButton>();
            foreach (Control ctrl in collection)
            {
                if (ctrl.HasChildren)
                {
                    result.AddRange(this.FindAllRadiobuttons(ctrl.Controls));
                }
                if (ctrl is RadioButton)
                {
                    result.Add((RadioButton)ctrl);
                }
            }

            return result;
        }

        private Control FindControl(string ControlName, Form form)
        {
            Control ctrl = null;

            Control[] buf = form.Controls.Find(ControlName, true);
            if (buf.Length == 0) return null;
            if (buf.Length > 1) return null;

            ctrl = buf[0];

            return ctrl;
        }

        private string GetEnumValFromRb(string PropName)
        {
            string EnumVal = string.Empty;
            string rbName = "rb"+PropName;            
            
            foreach (RadioButton rb in RadioButtons)
            {                
                if (rb.Checked)
                {
                    if (rb.Name.StartsWith(rbName))
                    {
                        EnumVal = rb.Name.Substring(rbName.Length);
                    }
                }
            }

            return EnumVal;
        }

        public void FillForm()
        {
            //получаем поля объекта
            PropertyInfo [] properties = ObjectType.GetProperties();
            Form form = (Form)DataForm;

            foreach (PropertyInfo pr in properties)
            {
                Type propType = pr.PropertyType; //тип свойства - от него и будем танцевать
                object propValue = pr.GetValue(DataObject, null);                

                if (propType == typeof(bool))
                {
                    CheckBox check = (CheckBox)FindControl("chk" + pr.Name, form);

                    if (check != null)
                    {
                        check.Checked = (bool)propValue;
                    }
                }

                if ((propType == typeof(int)) || (propType == typeof(string)))
                {
                    TextBox text = (TextBox)FindControl("txt" + pr.Name, form);

                    if (text != null)
                    {
                        if (propValue != null)
                        {
                            text.Text = propValue.ToString();
                        }
                        else
                        {
                            text.Text = string.Empty;
                        }
                    }
                }

                if (propValue is Enum)
                {
                    string rbname = "rb" + pr.Name + Enum.GetName(propValue.GetType(),propValue);
                    RadioButton rb = (RadioButton)FindControl(rbname,form);

                    if (rb != null)
                    {
                        rb.Checked = true;
                    }
                }
            }
        }

        public bool GetData()
        {
            PropertyInfo [] properties = ObjectType.GetProperties();
            Form form = (Form)DataForm;

            foreach (PropertyInfo pr in properties)
            {
                Type propType = pr.PropertyType;
                object propValue = pr.GetValue(DataObject, null);

                if (propType == typeof(bool))
                {
                    CheckBox check = (CheckBox)FindControl("chk" + pr.Name,form);

                    if (check != null)
                    {
                        pr.SetValue(DataObject, check.Checked, null);
                    }
                }

                if ((propType == typeof(string)) || (propType == typeof(int)))
                {
                    TextBox text = (TextBox)FindControl("txt" + pr.Name,form);

                    if (text != null)
                    {                        
                        if (propType == typeof(string))
                        {
                            pr.SetValue(DataObject, text.Text, null);
                        }
                        if (propType == typeof(int))
                        {
                            int val = 0;
                            try
                            {
                                val = Convert.ToInt32(text.Text);
                                pr.SetValue(DataObject, val, null);
                            }
                            catch (Exception ex)
                            {
                                ErrorMessage = ex.Message;
                                return false;
                            }
                        }
                    }
                }

                if (propValue is Enum)
                {
                    string val = GetEnumValFromRb(pr.Name);
                    object enumObj = Enum.Parse(propValue.GetType(), val);
                    pr.SetValue(DataObject, enumObj, null);                    
                }
            }

            return true;
        }
    }
}
