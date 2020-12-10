namespace Framework.MVC
{
    ///// <summary>
    ///// Extensiones para enumerables 
    ///// </summary>
    //public static class EnumExtensions
    //{

    //    private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
    //    {
    //        Type realModelType = modelMetadata.ModelType;

    //        Type underlyingType = Nullable.GetUnderlyingType(realModelType);
    //        if (underlyingType != null)
    //        {
    //            realModelType = underlyingType;
    //        }
    //        return realModelType;
    //    }

    //    private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

    //    public static string GetEnumDescription<TEnum>(TEnum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

    //        if ((attributes != null) && (attributes.Length > 0))
    //            return attributes[0].Description;
    //        else
    //            return value.ToString();
    //    }

    //    /// <summary>
    //    /// Helper para visualizar un listado de enumerables
    //    /// </summary>
    //    /// <typeparam name="TModel"></typeparam>
    //    /// <typeparam name="TEnum"></typeparam>
    //    /// <param name="htmlHelper"></param>
    //    /// <param name="expression"></param>
    //    /// <returns></returns>
    //    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
    //    {
    //        return EnumDropDownListFor(htmlHelper, expression, null);
    //    }

    //    /// <summary>
    //    /// Helper para visualizar un listado de enumerables
    //    /// </summary>
    //    /// <typeparam name="TModel"></typeparam>
    //    /// <typeparam name="TEnum"></typeparam>
    //    /// <param name="htmlHelper"></param>
    //    /// <param name="expression"></param>
    //    /// <param name="htmlAttributes"></param>
    //    /// <returns></returns>
    //    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
    //    {
    //        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
    //        Type enumType = GetNonNullableModelType(metadata);
    //        IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

    //        IEnumerable<SelectListItem> items = from value in values
    //                                            select new SelectListItem
    //                                            {
    //                                                Text = GetEnumDescription(value),
    //                                                Value = value.ToString(),
    //                                                Selected = value.Equals(metadata.Model)
    //                                            };

    //        // If the enum is nullable, add an 'empty' item to the collection
    //        if (metadata.IsNullableValueType)
    //            items = SingleEmptyItem.Concat(items);

    //        return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
    //    }
    //}

}
