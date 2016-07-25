﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using SwiftBookingTest.Web.Utilities;
using HtmlTags;
using Humanizer;
using System.Reflection;
using System.Linq;
namespace SwiftBookingTest.Web.Helpers
{
    public class AngularModelHelper<TModel>
    {
        protected readonly HtmlHelper Helper;
        private readonly string _expressionPrefix;

        public AngularModelHelper(HtmlHelper helper, string expressionPrefix)
        {
            Helper = helper;
            _expressionPrefix = expressionPrefix;
        }

        /// <summary>
        /// Converts an lambda expression into a camel-cased string, prefixed
        /// with the helper's configured prefix expression, ie:
        /// vm.model.parentProperty.childProperty
        /// </summary>
        public IHtmlString ngExpressionFor<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var expressionText = ExpressionForInternal(property);
            return new MvcHtmlString(expressionText);
        }

        /// <summary>
        /// Converts a lambda expression into a camel-cased AngularJS binding expression, ie:
        /// {{vm.model.parentProperty.childProperty}} 
        /// </summary>
        public IHtmlString ngBindingFor<TProp>(Expression<Func<TModel, TProp>> property)
        {
            return MvcHtmlString.Create("{{" + ExpressionForInternal(property) + "}}");
        }

        /// <summary>
		/// Creates a div with an ng-repeat directive to enumerate the specified property,
		/// and returns a new helper you can use for strongly-typed bindings on the items
		/// in the enumerable property.
		/// </summary>
		public AngularNgRepeatHelper<TSubModel> ngRepeat<TSubModel>(
            Expression<Func<TModel, IEnumerable<TSubModel>>> property, string variableName)
        {
            var propertyExpression = ExpressionForInternal(property);
            return new AngularNgRepeatHelper<TSubModel>(
                Helper, variableName, propertyExpression);
        }

        public HtmlTag FormGroupFor<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var metadata = ModelMetadata.FromLambdaExpression(property, new ViewDataDictionary<TModel>());
            var name = ExpressionHelper.GetExpressionText(property);
            var expression = ExpressionForInternal(property);
            var propertyInfo = typeof(TModel).GetProperty(name);

            //Hidden fields are decorated with HiddenInputAttribute
            if (propertyInfo.GetCustomAttributes()
                .Where(x => x.GetType().Name == typeof(HiddenInputAttribute).Name)
                .FirstOrDefault() != null)
            {
                return new HtmlTag("input")
                    .Attr("ng-model", expression)
                    .Attr("type", "hidden")
                    .Attr("name", name);
            }

            //Creates <div class="form-group has-feedback"
            //				form-group-validation="Name">
            var formGroup = new HtmlTag("div")
                .AddClasses("form-group", "has-feedback")
                .Attr("form-group-validation", name);

            var labelText = metadata.DisplayName ?? name.Humanize(LetterCasing.Title);

            //Creates <label class="control-label" for="Name">Name</label>
            var label = new HtmlTag("label")
                .AddClass("control-label")
                .Attr("for", name)
                .Text(labelText);

            var tagName = metadata.DataTypeName == "MultilineText"
                ? "textarea"
                : "input";

            var placeholder = metadata.Watermark ??
                              (labelText + "...");

            //Creates <input ng-model="expression"
            //		   class="form-control" name="Name" type="text" >
            var input = new HtmlTag(tagName)
                .AddClass("form-control")
                .Attr("ng-model", expression)
                .Attr("name", name)
                .Attr("type", "text")
                .Attr("placeholder", placeholder);

            ApplyValidationToInput(input, metadata);

            return formGroup
                .Append(label)
                .Append(input);
        }

        private string ExpressionForInternal<TProp>(Expression<Func<TModel, TProp>> property)
        {
            var camelCaseName = ExpressionHelper.GetExpressionText(property);

            var expression = !string.IsNullOrEmpty(_expressionPrefix)
                ? _expressionPrefix + "." + camelCaseName
                : camelCaseName;

            return expression;
        }

        private void ApplyValidationToInput(HtmlTag input, ModelMetadata metadata)
        {
            if (metadata.IsRequired)
                input.Attr("required", "");

            if (metadata.DataTypeName == "EmailAddress")
                input.Attr("type", "email");

            if (metadata.DataTypeName == "PhoneNumber")
                input.Attr("pattern", @"[\ 0-9()-]+");
        }
    }
}