using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace System.Web.Mvc
{
    public static class DateTimePickerHelper
    {
        public static MvcHtmlString DateTimePicker<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string maskFormat = "", string cssClass = "", bool disabled = false, bool readOnly = false)
        {
            var strDisabled = (disabled ? " disabled=\"disabled\" " : "");
            var value = Convert.ToDateTime(GetValue(html, expression));
            var strDate = value.ToString();
            if (!string.IsNullOrWhiteSpace(maskFormat))
                strDate = value.ToString(maskFormat);
            var strReadonly = (readOnly ? "readonly=\"true\"" : string.Empty);

            var retorno = new StringBuilder();
            retorno.Append("<div class='input-group date'>");
            retorno.Append(string.Format("<input type=\"text\" id=\"{0}\" name=\"{0}\" value=\"{1}\" class=\"form-control {3}\" data-target=\"datetimepicker\" {2} {3}>", expression.MemberName(), strDate, strDisabled, cssClass, strReadonly));
            retorno.Append("    <span class=\"input-group-addon\">");
            retorno.Append("        <span class=\"glyphicon glyphicon-calendar\"></span>");
            retorno.Append("    </span>");
            retorno.Append("</div>");
            return MvcHtmlString.Create(retorno.ToString());
        }

        private static string GetValue<TModel, TProperty>(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            string propertyName = body.Member.Name;
            TModel model = helper.ViewData.Model;
            string value = typeof(TModel).GetProperty(propertyName).GetValue(model, null).ToString();
            return value;
        }

        private static string MemberName<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.Name;
        }

    }
}