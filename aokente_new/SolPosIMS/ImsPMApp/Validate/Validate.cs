using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Web;
using System.Web.UI;

namespace Ncl.PM
{
    public class ValidateHelper
    {
        public static void ValidateControls(bool isValidate)
        {
            Control container = HttpContext.Current.Handler as Page;
            ValidateControls(container, isValidate);
        }

        private static void ValidateControls(Control container, bool isValidate)
        {
            if (container == null || !container.HasControls())
                return;
            foreach (Control control in container.Controls)
            {
                if (control == container)
                    continue;
                if (control.HasControls())
                    ValidateControls(control, isValidate);
                ValidateControl(control, isValidate);
            }
        }

        private static void ValidateControl(Control control, bool isValidate)
        {
            CustomValidator validator = control as CustomValidator;
            if (validator != null)
            {
                validator.ClientValidationFunction = "validateDate";
                validator.ServerValidate += new ServerValidateEventHandler(validator_ServerValidate);
            }
        }

        static void validator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator customvalidator = source as CustomValidator;
            string controlid = customvalidator.ControlToValidate.ToString();
            Control container = HttpContext.Current.Handler as Page;
            if (container.FindControl(controlid).ToString() == "System.Web.UI.HtmlControls.HtmlInputText")
            {
                HtmlInputText htmtext = container.FindControl(controlid) as HtmlInputText;
                if (htmtext.Value.Length != 3)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }
            else
                args.IsValid = false;
        }

    }
}
